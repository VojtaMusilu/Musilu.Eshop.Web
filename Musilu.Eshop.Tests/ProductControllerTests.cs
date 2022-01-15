using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Xunit;
using Xunit.Abstractions;
using Moq;

using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Controllers;

using Musilu.Eshop.Tests.Helpers;
using Microsoft.Extensions.Logging;

namespace Musilu.Eshop.Tests
{
    public class ProductControllerTests
    {

        public ILogger<ProductController> logger;

        public ProductControllerTests()
        {
            this.logger = Mock.Of<ILogger<ProductController>>();
        }

        [Fact]
        public async Task ProductDetail_Success()
        {
            // Arrange

            Product insert = new Product()
            {
                ID = 1,
                ImageSource = null,
                ImageAlt = "image",
                Name = "testProduct",
                Description = "testDescription",
                Category = "testCategory",
                Price = 100
            };


            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();

            await databaseContext.AddAsync(insert);
            await databaseContext.SaveChangesAsync();


            ProductController controller = new ProductController(logger, databaseContext);



            // Act

            var iActionResult = controller.Detail(1);


            // Assert

            var result = Assert.IsType<ViewResult>(iActionResult);
            var model = Assert.IsAssignableFrom<Product>(result.ViewData.Model);
            Assert.Equal(insert.ImageAlt, model.ImageAlt);
            Assert.Equal(insert.ImageSource, model.ImageSource);
            Assert.Equal(insert.ID, model.ID);
            Assert.Equal(insert.Name, model.Name);
            Assert.Equal(insert.Price, model.Price);
            Assert.Equal(insert.Category, model.Category);


        }
        
        [Fact]
        public async Task ProductDetail_Fail()
        {
            // Arrange

            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();

            ProductController controller = new ProductController(logger, databaseContext);


            // Act

            var iActionResult = controller.Detail(1);


            // Assert

            var result = Assert.IsType<NotFoundResult>(iActionResult);


        }
    }
}
