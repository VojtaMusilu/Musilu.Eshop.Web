using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

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
using Musilu.Eshop.Tests.Helpers;

namespace Musilu.Eshop.Tests
{

    


    public class CustomerOrderNotCartControllerTests : IClassFixture<OrdersFixture>
    {
        private readonly ILogger<HomeController> _logger;
        OrdersFixture fixture;

        public CustomerOrderNotCartControllerTests(OrdersFixture fixture)
        {
            _logger = Mock.Of<ILogger<HomeController>>();
            this.fixture = fixture;
        }




        [Fact]
        public async Task AddOrderItemsToSession_Success()
        {
            //Arrange


            Product product = new Product()
            {
                ID = 1,
                Price = 111,
                Name = "something"
            };
            await fixture._databaseContext.AddAsync(product);

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem { OrderID = 1,ID = 1,ProductID=1, Product = product}
            };
            await fixture._databaseContext.AddAsync(new Order
            {
                UserId = 1,
                ID = 1,
                TotalPrice = 100,
                OrderNumber = "123",
                User = getTestUser(),
                OrderItems = orderItems

            });

            await fixture._databaseContext.AddAsync(new Order
            {
                UserId = 2,
                ID = 2,
                TotalPrice = 200,
                OrderNumber = "456",
                User = getTestUser2(),
                OrderItems = orderItems
            });

            await fixture._databaseContext.SaveChangesAsync();



            //Act

            double iActionResult = fixture._notCartController.AddOrderItemsToSession(1);



            //Assert

            Assert.Equal(111, iActionResult);

        }




        [Fact]
        public async Task ApproveOrderInSession_Success()
        {



            Product product = new Product()
            {
                ID = 2,
                Price = 222,
                Name = "something else",

            };
            await fixture._databaseContext.AddAsync(product);

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem { OrderID = 2,ID = 2,ProductID=2, Product = product, Amount = 2}
            };



            var orderItemsSerialized = JsonConvert.SerializeObject(orderItems, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            byte[] sessionValue = Encoding.UTF8.GetBytes(orderItemsSerialized);
            fixture._mockSession.Setup(x => x.TryGetValue(It.IsAny<string>(), out sessionValue)).Returns(true).Verifiable();


            var iActionResult = await fixture._notCartController.ApproveOrderInSession();

            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(nameof(CustomerOrdersController.Index), redirect.ActionName);
            Assert.Matches(nameof(CustomerOrdersController).Replace("Controller", ""), redirect.ControllerName);


            int ordersInDB = (await fixture._databaseContext.Orders.ToListAsync()).Where(o => o.ID == 2).Count();
            
            Assert.Equal(1, ordersInDB);
        }

        User getTestUser()
        {
            return new User
            {
                Id = fixture._UserID,
                FirstName = fixture._UserFName,
                LastName = fixture._UserLName
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

