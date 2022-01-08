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

namespace Musilu.Eshop.Tests
{
    public class HomeControllerTests
    {
        private readonly ILogger<HomeController> _logger;
        private Mock<IWebHostEnvironment> _mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
        private DbContextOptions _options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
        private EshopDbContext _databaseContext;
        private HomeController _controller;

        public HomeControllerTests()
        {
            _logger = Mock.Of<ILogger<HomeController>>();
            _mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            _databaseContext = new EshopDbContext(_options);

            _databaseContext.Database.EnsureCreated();

            _controller = new HomeController(_logger, _databaseContext, _mockIWebHostEnvironment.Object);
        }
        [Fact]
        public async Task Index_Success()
        {
            // Arrange
            IActionResult iActionResult = _controller.Index();

            Assert.IsType<ViewResult>(iActionResult);

        }
        
        [Fact]
        public async Task Privacy_Success()
        {
            IActionResult iActionResult = _controller.Privacy();

            Assert.IsType<ViewResult>(iActionResult);

        }
        

    }
}
