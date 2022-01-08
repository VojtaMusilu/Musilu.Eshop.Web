using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Xunit;
using Moq;

using Musilu.Eshop.Web.Controllers;
using Musilu.Eshop.Web.Models.Database;

using Microsoft.Extensions.Logging;
using Musilu.Eshop.Web.Models.Identity;
using Musilu.Eshop.Web.Models.ApplicationServices.Abstraction;
using System.Security.Claims;
using Musilu.Eshop.Web.Areas.Customer.Controllers;
using Musilu.Eshop.Web.Models.Entity;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using System.Collections.Generic;

namespace Musilu.Eshop.Tests
{
    public class CustomerOrdersControllerTests
    {
        private readonly ILogger<HomeController> _logger;
        private Mock<IWebHostEnvironment> _mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();

        private CustomerOrdersController _controller;

        private Mock<ISecurityApplicationService> _mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
        private DbContextOptions _options = new DbContextOptionsBuilder<EshopDbContext>()
                               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                               .Options;
        private EshopDbContext _databaseContext;
        public CustomerOrdersControllerTests()
        {
            _mockIWebHostEnvironment
                .Setup(webHostEnv => webHostEnv.WebRootPath)
                .Returns(Directory.GetCurrentDirectory());


            _logger = Mock.Of<ILogger<HomeController>>();


            /*
             _mockISecurityApplicationService
                .Setup(security => security.GetCurrentUser(It.IsAny<ClaimsPrincipal>()))
                .Returns<User>((loginVM) => {
                    return Task<bool>.Run(() =>
                    {
                        return new User
                        {
                            Id = 1,
                            FirstName = "testFirst",
                            LastName = "testLast"
                        };

                    });
                });
            
             */

            _mockISecurityApplicationService
                .Setup(security => security.GetCurrentUser(It.IsAny<ClaimsPrincipal>()))
                .Returns(() => {
                    return Task<bool>.Run(() =>
                    {
                        return getTestUser();

                    });
                });

            _databaseContext = new EshopDbContext(_options);

            _databaseContext.Database.EnsureCreated();

            _controller = new CustomerOrdersController(_mockISecurityApplicationService.Object, _databaseContext);

        }

        [Fact]
        public async Task Index_Success()
        {

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "username")
                    }, 
                    "someAuthTypeName"))
                }
            };

            Product product = new Product()
            {
                ID = 1
            };

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem { OrderID = 1,ID = 1,ProductID=1, Product = product}
            };


            await _databaseContext.AddAsync(new Order { 
                UserId = 1, 
                ID = 1, 
                TotalPrice=100, 
                OrderNumber= "123", 
                User = getTestUser(),
                OrderItems = orderItems

            });

            await _databaseContext.AddAsync(new Order
            {
                UserId = 2,
                ID = 2,
                TotalPrice = 200,
                OrderNumber = "456",
                User = getTestUser2(),
                OrderItems = orderItems
            });

            await _databaseContext.SaveChangesAsync();


            IActionResult iActionResult = await _controller.Index();

            ViewResult viewResult = Assert.IsType<ViewResult>(iActionResult);
            Assert.IsAssignableFrom<IList<Order>>(viewResult.ViewData.Model);

            IList<Order> orderList = viewResult.ViewData.Model as List<Order>;
            Assert.Equal(1, orderList.Count);
        } 



        User getTestUser()
        {
            return new User
            {
                Id = 1,
                FirstName = "testFirst",
                LastName = "testLast"
            };
        }
        
        User getTestUser2()
        {
            return new User
            {
                Id = 2,
                FirstName = "testFirstOther",
                LastName = "testLastOther"
            };
        }
    }
}
