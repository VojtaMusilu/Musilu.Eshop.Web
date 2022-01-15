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
using Musilu.Eshop.Tests.Helpers;

namespace Musilu.Eshop.Tests
{
    public class CustomerOrdersControllerTests : IClassFixture<OrdersFixture>
    {
        private readonly ILogger<HomeController> _logger;
        OrdersFixture fixture;

        public CustomerOrdersControllerTests(OrdersFixture fixture)
        {

            _logger = Mock.Of<ILogger<HomeController>>();

            this.fixture = fixture;

        }

        [Fact]
        public async Task Index_Success()
        {

            fixture._ordersController.ControllerContext = new ControllerContext
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
                ID = 5
            };

            List<OrderItem> orderItems = new List<OrderItem>()
            {
                new OrderItem { OrderID = 5,ID = 5,ProductID=5, Product = product}
            };


            await fixture._databaseContext.AddAsync(new Order { 
                UserId = 5, 
                ID = 5, 
                TotalPrice=100, 
                OrderNumber= "55567", 
                User = getTestUser(),
                OrderItems = orderItems

            });

            await fixture._databaseContext.AddAsync(new Order
            {
                UserId = 20,
                ID = 20,
                TotalPrice = 2000,
                OrderNumber = "45679822",
                User = getTestUser2(),
                OrderItems = orderItems
            });

            await fixture._databaseContext.SaveChangesAsync();


            IActionResult iActionResult = await fixture._ordersController.Index();

            ViewResult viewResult = Assert.IsType<ViewResult>(iActionResult);
            Assert.IsAssignableFrom<IList<Order>>(viewResult.ViewData.Model);

            IList<Order> orderList = viewResult.ViewData.Model as List<Order>;
            Assert.Equal(1, orderList.Count);
        } 




        [Fact]
        public async Task Index_Fail()
        {

            fixture._ordersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    
                }
            };


            IActionResult iActionResult = await fixture._ordersController.Index();

            Assert.IsType<NotFoundResult>(iActionResult);

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
