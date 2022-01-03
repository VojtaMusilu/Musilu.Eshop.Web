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
    public class ProductControllerTests
    {
        const string relativeProductDirectoryPath = "/img/Products";

        private readonly ITestOutputHelper _testOutputHelper;
        public ProductControllerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        [Fact]
        public async Task CarouselCreate_Success()
        {
            // Arrange
            var mockIWebHostEnvironment = new Mock<IWebHostEnvironment>();
            mockIWebHostEnvironment.Setup(webHostEnv => webHostEnv.WebRootPath).Returns(Directory.GetCurrentDirectory());

            //Nainstalován Nuget package: Microsoft.EntityFrameworkCore.InMemory
            //databazi vytvori v pameti
            //Jsou zde konkretni tridy, takze to neni uplne OK - mely by se vyuzit interface jako treba pres IUnitOfWork, IRepository<T>, nebo pres vlastni IDbContext (je pak ale nutne vyuzivat interface i v hlavnim projektu, jinak v unit testech nebude spravne fungovat mockovani)
            //takto to ale v krizovych situacich taky jde :-)
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
                    Product testCarousel = GetTestProduct(iffMock.Object);

                    //Act
                    iActionResult = await controller.Create(testCarousel);

                }
            }

            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(ProductController.Select));


            int carouselCount = (await databaseContext.Products.ToListAsync()).Count;
            Assert.Equal(1, carouselCount);

            Assert.Single(await databaseContext.Products.ToListAsync());

        }

        Product GetTestProduct(IFormFile iff)
        {
            return new Product()
            {
                ImageSource = null,
                ImageAlt = "image",
                Image = iff,
                Name = "testProduct",
                Description = "testDescription",
                Category = "testCategory",
                Price = 100
                
            };
        }
    }
}
