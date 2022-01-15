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
    public class ProductControllerAdminTests
    {
        const string relativeProductDirectoryPath = "/img/Products";

        private readonly ITestOutputHelper _testOutputHelper;
        public ProductControllerAdminTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        [Fact]
        public async Task ProductCreate_Success()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            ProductController controller = new ProductController(databaseContext, mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            string content = "‰PNG" + "FakeImageContent";
            string fileName = "UploadImageFile.png";

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + relativeProductDirectoryPath));

            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    Product testProduct = GetTestProduct(iffMock.Object);

                    //Act
                    iActionResult = await controller.Create(testProduct);

                }
            }




            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(ProductController.Select));


            int ProductCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(1, ProductCount);

            Assert.Single(await databaseContext.Products.ToListAsync());

        }






        [Fact]
        public async Task ProductCreate_Fail()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            ProductController controller = new ProductController(databaseContext, mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;

            
            Product testProduct = GetTestProductInvalid();


            
            //Act
            
            iActionResult = await controller.Create(testProduct);


            // Assert

            var viewResult = Assert.IsType<ViewResult>(iActionResult);
            var model = Assert.IsAssignableFrom<Product>(viewResult.ViewData.Model);

            int productCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(0, productCount);
            Assert.Empty(await databaseContext.Products.ToListAsync());

        }






        [Fact]
        public async Task ProductEdit_Success()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            ProductController controller = new ProductController(databaseContext, mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            string content = "‰PNG" + "FakeImageContent";
            string fileName = "UploadImageFile.png";
            
            string contentEdit = "‰PNG" + "FakeImageContentEdited";
            string fileNameEdit = "UploadImageFileEdit.png";

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + relativeProductDirectoryPath));

            Product testProduct = null;
            Product testProduct_Edit = null;


            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    Mock<IFormFile> iffMockEdit = iffMockHelper.MockIFormFile(ms, writer, fileNameEdit, contentEdit, "image/png");
                    testProduct = GetTestProduct(iffMock.Object);
                    testProduct_Edit = GetTestProduct_EditAll(iffMockEdit.Object);

                    databaseContext.Add(testProduct);
                    databaseContext.SaveChanges();


                    //Act
                    iActionResult = await controller.Edit(testProduct_Edit);

                }
            }





            // Assert


            var redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(ProductController.Select));


            int ProductCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(1, ProductCount);
            Assert.Single(await databaseContext.Products.ToListAsync());

            var ProductFromDb = (await databaseContext.Products.ToListAsync()).FirstOrDefault();
            Assert.Equal(testProduct_Edit.ID, ProductFromDb.ID);
            Assert.Equal(testProduct_Edit.ImageSource, ProductFromDb.ImageSource);
            Assert.Equal(testProduct_Edit.ImageAlt, ProductFromDb.ImageAlt);
            Assert.Equal(testProduct_Edit.Name, ProductFromDb.Name);
            Assert.Equal(testProduct_Edit.Price, ProductFromDb.Price);
            Assert.Equal(testProduct_Edit.Description, ProductFromDb.Description);
            Assert.Equal(testProduct_Edit.Category, ProductFromDb.Category);

        }


        [Fact]
        public async Task ProductEdit_Fail()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            ProductController controller = new ProductController(databaseContext, mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            string content = "‰PNG" + "FakeImageContent";
            string fileName = "UploadImageFile.png";
            

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + relativeProductDirectoryPath));

            Product testProduct = null;
            Product testProduct_Edit = null;


            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testProduct = GetTestProduct(iffMock.Object);

                    databaseContext.Add(testProduct);
                    databaseContext.SaveChanges();

                    testProduct.ID = 2;

                    //Act
                    iActionResult = await controller.Edit(testProduct);

                    testProduct.ID = 1;


                }
            }

            // Assert


            var redirect = Assert.IsType<NotFoundResult>(iActionResult);


            int ProductCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(1, ProductCount);
            Assert.Single(await databaseContext.Products.ToListAsync());

            var ProductFromDb = (await databaseContext.Products.ToListAsync()).FirstOrDefault();
            Assert.Equal(testProduct.ID, ProductFromDb.ID);
            Assert.Equal(testProduct.ImageSource, ProductFromDb.ImageSource);
            Assert.Equal(testProduct.ImageAlt, ProductFromDb.ImageAlt);
            Assert.Equal(testProduct.Name, ProductFromDb.Name);
            Assert.Equal(testProduct.Price, ProductFromDb.Price);
            Assert.Equal(testProduct.Description, ProductFromDb.Description);
            Assert.Equal(testProduct.Category, ProductFromDb.Category);

        }





        [Fact]
        public async Task ProductDelete_Success()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            ProductController controller = new ProductController(databaseContext, mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            string content = "‰PNG" + "FakeImageContent";
            string fileName = "UploadImageFile.png";

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + relativeProductDirectoryPath));

            Product testProduct = null;


            //nastavení fakeové IFormFile pomocí MemoryStream
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testProduct = GetTestProduct(iffMock.Object);

                    databaseContext.Add(testProduct);
                    databaseContext.SaveChanges();

                }
            }



            //Act
            iActionResult = await controller.Delete(1);


            // Assert

            var redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(ProductController.Select));

            int ProductCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(0, ProductCount);
            Assert.Empty(await databaseContext.Products.ToListAsync());


        }


        [Fact]
        public async Task ProductDelete_Fail()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            ProductController controller = new ProductController(databaseContext, mockIWebHostEnvironment.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;



            string content = "‰PNG" + "FakeImageContent";
            string fileName = "UploadImageFile.png";

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + relativeProductDirectoryPath));

            Product testProduct = null;


            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms))
                {
                    IFormFileMockHelper iffMockHelper = new IFormFileMockHelper(_testOutputHelper);
                    Mock<IFormFile> iffMock = iffMockHelper.MockIFormFile(ms, writer, fileName, content, "image/png");
                    testProduct = GetTestProduct(iffMock.Object);

                    databaseContext.Add(testProduct);
                    databaseContext.SaveChanges();

                }
            }



            //Act
            iActionResult = await controller.Delete(2);


            // Assert


            var redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(ProductController.Select));


            int ProductCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(1, ProductCount);
            Assert.Single(await databaseContext.Products.ToListAsync());


        }





        Product GetTestProduct(IFormFile iff)
        {
            return new Product()
            {
                ID = 1,
                ImageSource = null,
                ImageAlt = "image",
                Image = iff,
                Name = "testProduct",
                Description = "testDescription",
                Category = "testCategory",
                Price = 100
                
            };
        }
        
        Product GetTestProduct_EditAll(IFormFile iff)
        {
            return new Product()
            {
                ID = 1,
                ImageSource = null,
                ImageAlt = "image edited",
                Image = iff,
                Name = "testProduct edited",
                Description = "testDescription edited",
                Category = "testCategory edited",
                Price = 50
                
            };
        }
        
        Product GetTestProductInvalid()
        {
            return new Product()
            {
                ImageSource = null,
                ImageAlt = "image",
                Name = "testProduct",
                Description = "testDescription",
                Category = "testCategory",
                
            };
        }
    }
}
