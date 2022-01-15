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
using Musilu.Eshop.Web.Areas.Admin.Controllers;

using Musilu.Eshop.Tests.Helpers;

namespace Musilu.Eshop.Tests
{

    public class CarouselFixture
    {

        public Mock<IWebHostEnvironment> _mockIWebHostEnvironment;
        public CarouselFixture()
        {

            _mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            _mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

        }
    }

    public class CarouselControllerTests : IClassFixture<CarouselFixture>
    {
        CarouselFixture fixture;

        const string relativeCarouselDirectoryPath = "/img/CarouselItems";
        const string content = "‰PNG" + "FakeImageContent";
        const string fileName = "UploadImageFile.png";

        private readonly ITestOutputHelper _testOutputHelper;
        public CarouselControllerTests(ITestOutputHelper testOutputHelper, CarouselFixture fixture)
        {
            _testOutputHelper = testOutputHelper;
            this.fixture = fixture;

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + relativeCarouselDirectoryPath));

        }


        [Fact]
        public async Task CarouselCreate_Success()
        {
            // Arrange

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            CarouselController controller = new CarouselController(databaseContext, fixture._mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    CarouselItem testCarousel = GetTestCarouselItem(iffMock.Object);

                    //Act
                    iActionResult = await controller.Create(testCarousel);

                }
            }

            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(CarouselController.Select));

            int carouselCount = (await databaseContext.CarouselItems.ToListAsync()).Count;
            Assert.Equal(1, carouselCount);

            Assert.Single(await databaseContext.CarouselItems.ToListAsync());

        }


        [Fact]
        public async Task CarouselCreate_Fail()
        {
            // Arrange

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();

            CarouselController controller = new CarouselController(databaseContext, fixture._mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            CarouselItem testCarousel = GetTestCarouselItemInvalid();

           
            // Act
            iActionResult = await controller.Create(testCarousel);
            
            
            // Assert
            var viewResult = Assert.IsType<ViewResult>(iActionResult);
            var model = Assert.IsAssignableFrom<CarouselItem>(viewResult.ViewData.Model);


            int carouselCount = (await databaseContext.CarouselItems.ToListAsync()).Count;
            Assert.Equal(0, carouselCount);
            Assert.Empty(await databaseContext.CarouselItems.ToListAsync());

        }




        [Fact]
        public async Task CarouselEdit_Success()
        {
            // Arrange
            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();

            CarouselController controller = new CarouselController(databaseContext, fixture._mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;

            CarouselItem testCarousel = null;
            CarouselItem testCarousel_Edit = null;


            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testCarousel = GetTestCarouselItem(iffMock.Object);
                    testCarousel_Edit = GetTestCarouselItem_EditAlt(iffMock.Object);

                    databaseContext.Add(testCarousel);
                    databaseContext.SaveChanges();


                    //Act
                    iActionResult = await controller.Edit(testCarousel_Edit);

                    testCarousel = GetTestCarouselItem(iffMock.Object);
                    testCarousel.ImageSource = relativeCarouselDirectoryPath + @"\" + fileName;


                }
            }

            // Assert


            var redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(CarouselController.Select));


            int carouselCount = (await databaseContext.CarouselItems.ToListAsync()).Count;
            Assert.Equal(1, carouselCount);
            Assert.Single(await databaseContext.CarouselItems.ToListAsync());

            var carouselFromDb = (await databaseContext.CarouselItems.ToListAsync()).FirstOrDefault();
            Assert.Equal(testCarousel.ID, carouselFromDb.ID);
            Assert.Equal(testCarousel.Image, carouselFromDb.Image);
            Assert.Equal(testCarousel.ImageSource, carouselFromDb.ImageSource);
            Assert.Equal(testCarousel_Edit.ImageAlt, carouselFromDb.ImageAlt);

        }




        [Fact]
        public async Task CarouselEdit_Fail()
        {
            // Arrange
            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            CarouselController controller = new CarouselController(databaseContext, fixture._mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;


            CarouselItem testCarousel = null;
            CarouselItem testCarousel_Edit = null;


            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testCarousel = GetTestCarouselItem(iffMock.Object);
                    testCarousel_Edit = GetTestCarouselItem_EditInvalid(iffMock.Object);

                    databaseContext.Add(testCarousel);
                    databaseContext.SaveChanges();


                    //Act
                    iActionResult = await controller.Edit(testCarousel_Edit);

                    testCarousel = GetTestCarouselItem(iffMock.Object);


                }
            }


            // Assert


            Assert.IsType<ViewResult>(iActionResult);

            int carouselCount = (await databaseContext.CarouselItems.ToListAsync()).Count;
            Assert.Equal(1, carouselCount);
            Assert.Single(await databaseContext.CarouselItems.ToListAsync());

            var carouselFromDb = (await databaseContext.CarouselItems.ToListAsync()).FirstOrDefault();
            Assert.Equal(testCarousel.ID, carouselFromDb.ID);
            Assert.Equal(testCarousel.Image, carouselFromDb.Image);
            Assert.Equal(testCarousel.ImageSource, carouselFromDb.ImageSource);
            Assert.Equal(testCarousel.ImageAlt, carouselFromDb.ImageAlt);

        }





        [Fact]
        public async Task CarouselDelete_Success()
        {
            // Arrange
            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            CarouselController controller = new CarouselController(databaseContext, fixture._mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;

            CarouselItem testCarousel = null;


            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testCarousel = GetTestCarouselItem(iffMock.Object);

                    databaseContext.Add(testCarousel);
                    databaseContext.SaveChanges();

                }
            }



            //Act
            iActionResult = await controller.Delete(1);


            // Assert


            var redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(CarouselController.Select));


            int carouselCount = (await databaseContext.CarouselItems.ToListAsync()).Count;
            Assert.Equal(0, carouselCount);
            Assert.Empty(await databaseContext.CarouselItems.ToListAsync());


        }


        [Fact]
        public async Task CarouselDelete_Fail()
        {
            // Arrange
            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            CarouselController controller = new CarouselController(databaseContext, fixture._mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            CarouselItem testCarousel = null;


            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testCarousel = GetTestCarouselItem(iffMock.Object);

                    databaseContext.Add(testCarousel);
                    databaseContext.SaveChanges();

                }
            }



            //Act
            iActionResult = await controller.Delete(2);


            // Assert


            var redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(CarouselController.Select));


            int carouselCount = (await databaseContext.CarouselItems.ToListAsync()).Count;
            Assert.Equal(1, carouselCount);
            Assert.Single(await databaseContext.CarouselItems.ToListAsync());


        }






        CarouselItem GetTestCarouselItem(IFormFile iff)
        {
            return new CarouselItem()
            {
                ID = 1,
                ImageSource = null,
                ImageAlt = "image",
                Image = iff
            };
        }

        CarouselItem GetTestCarouselItem_EditAlt(IFormFile iff)
        {
            return new CarouselItem()
            {
                ID = 1,
                ImageSource = null,
                ImageAlt = "imageEdited",
                Image = iff
            };
        }
        CarouselItem GetTestCarouselItem_EditInvalid(IFormFile iff)
        {
            return new CarouselItem()
            {
                ID = 2,
                ImageSource = null,
                ImageAlt = "imageEdited",
                Image = iff
            };
        }

        CarouselItem GetTestCarouselItemInvalid()
        {
            return new CarouselItem()
            {
                ID = 1,
                ImageSource = null,
                ImageAlt = "imageNull"

            };
        }

    }
}