using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Moq;

using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.Identity;
using Musilu.Eshop.Web.Models.ApplicationServices.Abstraction;
using System.Security.Claims;
using Musilu.Eshop.Web.Areas.Customer.Controllers;
using Musilu.Eshop.Web.Models.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Musilu.Eshop.Tests.Helpers
{
    public class OrdersFixture
    {
        public int _UserID = 1;
        public string _UserFName = "testFirst";
        public string _UserLName = "testLast";



        public Mock<IWebHostEnvironment> _mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();

        public CustomerOrderNotCartController _notCartController;
        public CustomerOrdersController _ordersController;

        public Mock<ISecurityApplicationService> _mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
        public DbContextOptions _options = new DbContextOptionsBuilder<EshopDbContext>()
                               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                               .Options;
        public EshopDbContext _databaseContext;
        public Mock<ISession> _mockSession = new Mock<ISession>();
        public OrdersFixture()
        {
            _mockIWebHostEnvironment
                .Setup(webHostEnv => webHostEnv.WebRootPath)
                .Returns(Directory.GetCurrentDirectory());



            _mockISecurityApplicationService
            .Setup(security => security.GetCurrentUser(It.IsAny<ClaimsPrincipal>()))
            .Returns(() =>
            {
                return Task<bool>.Run(() =>
                {
                    return new User
                    {
                        Id = _UserID,
                        FirstName = _UserFName,
                        LastName = _UserLName
                    };

                });
            });

            _databaseContext = new EshopDbContext(_options);

            _databaseContext.Database.EnsureCreated();

            _notCartController = new CustomerOrderNotCartController(_mockISecurityApplicationService.Object, _databaseContext);
            _ordersController = new CustomerOrdersController(_mockISecurityApplicationService.Object, _databaseContext);


            _mockSession.Setup(s => s.IsAvailable).Returns(true);


            List<OrderItem> _orderItems = new List<OrderItem>()
            {
                new OrderItem {
                    OrderID = 1,
                    ID = 100,
                    ProductID=1,
                    Product = new Product()
                    {
                        ID = 1,
                        Price = 111,
                        Name = "something"
                    }
                }
            };


            _mockSession.Object.SetObject("OrderItems", _orderItems);


            _notCartController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Session = _mockSession.Object
                }
            };
        }
    }
}
