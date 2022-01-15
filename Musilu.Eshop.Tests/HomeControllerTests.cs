using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Musilu.Eshop.Web.Controllers;
using Musilu.Eshop.Web.Models;
using Musilu.Eshop.Web.Models.Database;
using Musilu.Eshop.Web.Models.Entity;
using Musilu.Eshop.Web.Models.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Musilu.Eshop.Tests
{
    public class HomeFixture
    {
        public Mock<IWebHostEnvironment> _mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
        public DbContextOptions _options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
        public EshopDbContext _databaseContext;
        public HomeController _controller;
        private readonly ILogger<HomeController> _logger;


        public readonly string _traceIdentifier = "traceIdentifierTest";

        public HomeFixture()
        {
            _logger = Mock.Of<ILogger<HomeController>>();

            _mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            _databaseContext = new EshopDbContext(_options);

            _databaseContext.Database.EnsureCreated();

            _databaseContext.Add(new CarouselItem() { ID = 1, ImageSource = "src", ImageAlt = "alt" });
            _databaseContext.Add(new Product() { ID = 1, Name = "name", Price = 10 });
            _databaseContext.SaveChanges();

            _controller = new HomeController(_logger, _databaseContext, _mockIWebHostEnvironment.Object);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    TraceIdentifier = _traceIdentifier
                }
            };
        }
    }



    public class HomeControllerTests : IClassFixture<HomeFixture>
    {
        HomeFixture fixture;

        public HomeControllerTests(HomeFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public async Task Index_Success()
        {
            // Arrange
            IActionResult iActionResult = fixture._controller.Index();

            var viewResult = Assert.IsType<ViewResult>(iActionResult);

            var indexVM = Assert.IsAssignableFrom<IndexViewModel>(viewResult.Model);
            Assert.Equal(1, indexVM.CarouselItems.Count);
            Assert.Equal(1, indexVM.Products.Count);
        }

        [Fact]
        public async Task Privacy_Success()
        {
            IActionResult iActionResult = fixture._controller.Privacy();

            Assert.IsType<ViewResult>(iActionResult);

        }

        [Fact]
        public async Task Error_Success()
        {
            IActionResult iActionResult = fixture._controller.Error();

            var viewResult = Assert.IsType<ViewResult>(iActionResult);
            var error = Assert.IsAssignableFrom<ErrorViewModel>(viewResult.Model);
            Assert.Equal(fixture._traceIdentifier, error.RequestId);

        }


    }
}
