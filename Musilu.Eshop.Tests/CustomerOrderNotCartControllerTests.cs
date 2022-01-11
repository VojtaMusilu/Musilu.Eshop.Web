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
using System.Text;
using Newtonsoft.Json;

namespace Musilu.Eshop.Tests
{
    public class CustomerOrderNotCartControllerTests
    {
        private readonly ILogger<HomeController> _logger;
        private Mock<IWebHostEnvironment> _mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();

        private CustomerOrderNotCartController _controller;

        private Mock<ISecurityApplicationService> _mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
        private DbContextOptions _options = new DbContextOptionsBuilder<EshopDbContext>()
                               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                               .Options;
        private EshopDbContext _databaseContext;
        private Mock<ISession> _mockSession = new Mock<ISession>();
        public CustomerOrderNotCartControllerTests()
        {
            _mockIWebHostEnvironment
                .Setup(webHostEnv => webHostEnv.WebRootPath)
                .Returns(Directory.GetCurrentDirectory());


            _logger = Mock.Of<ILogger<HomeController>>();

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

            _controller = new CustomerOrderNotCartController(_mockISecurityApplicationService.Object, _databaseContext);

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

            var key = "OrderItems";
            var value = new byte[0];

            //_mockSession.Setup(s => s.GetObject<List<OrderItem>>("OrderItems")).Returns(_orderItems);
            _mockSession.Object.SetObject("OrderItems", _orderItems);



            //_mockSession.Setup(s => s.GetString("OrderItems")).Returns(_orderItems.ToString());

            //_mockSession.Setup(s => s.TryGetValue(key, out value)).Returns(true);


            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Session = _mockSession.Object
                }
            };
        }


        [Fact]
        public async Task AddOrderItemsToSession_Success()
        {
            


            Product product = new Product()
            {
                ID = 1,
                Price = 111,
                Name = "something"
            };
            await _databaseContext.AddAsync(product);

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem { OrderID = 1,ID = 1,ProductID=1, Product = product}
            };
            await _databaseContext.AddAsync(new Order
            {
                UserId = 1,
                ID = 1,
                TotalPrice = 100,
                OrderNumber = "123",
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

            double iActionResult = _controller.AddOrderItemsToSession(1);

            Assert.Equal(111, iActionResult);

        }




        [Fact]
        public async Task ApproveOrderInSession_Success()
        {
            


            Product product = new Product()
            {
                ID = 1,
                Price = 111,
                Name = "something",
                
            };
            await _databaseContext.AddAsync(product);

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem { OrderID = 1,ID = 1,ProductID=1, Product = product, Amount = 2}
            };

            //_mockSession.Object.SetObject("OrderItems", orderItems);

            /*
            await _databaseContext.AddAsync(new Order
            {
                UserId = 1,
                ID = 1,
                TotalPrice = 100,
                OrderNumber = "123",
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
            */

            var orderItemsSerialized = JsonConvert.SerializeObject(orderItems, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            byte[] sessionValue = Encoding.UTF8.GetBytes(orderItemsSerialized) ;
            _mockSession.Setup(x => x.TryGetValue(It.IsAny<string>(), out sessionValue)).Returns(true).Verifiable();


            var iActionResult = await _controller.ApproveOrderInSession();

            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(nameof(CustomerOrdersController.Index), redirect.ActionName);
            Assert.Matches(nameof(CustomerOrdersController).Replace("Controller", ""), redirect.ControllerName);


            int ordersInDB = (await _databaseContext.Orders.ToListAsync()).Count;
            Assert.Equal(1, ordersInDB);

            Assert.Single(await _databaseContext.Orders.ToListAsync());

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
