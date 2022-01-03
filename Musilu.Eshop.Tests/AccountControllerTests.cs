using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Xunit;
using Moq;

using Musilu.Eshop.Web.Areas.Security.Controllers;
using Musilu.Eshop.Web.Controllers;
using Musilu.Eshop.Web.Models.ApplicationServices.Abstraction;
using Musilu.Eshop.Web.Models.ViewModels;
using Musilu.Eshop.Web.Models.Identity;
using Musilu.Eshop.Web.Models.Database;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Musilu.Eshop.Web.Models.ApplicationServices.Implementation;

namespace Musilu.Eshop.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public async Task Login_ValidSuccess()
        {
            // Arrange
            var mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
                                                                      //první verze, kdy prostě řekneme, že login projde a hotovo :-)
                                                                      .Returns(() => Task<bool>.Run(() => true));
            //druhá verze, kdy si můžeme testovat, co je v LoginViewModel:
            //.Returns<LoginViewModel>((loginVM) => {return Task<bool>.Run(() =>
            //{
            //    if (loginVM.Username == "superadmin" && loginVM.Password == "123")
            //    { return true; }
            //    else
            //    { return false; }
            //});});


            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = "superadmin",
                Password = "123"
            };


            AccountController controller = new AccountController(mockISecurityApplicationService.Object);
            //pokud chci vypnout validaci, tak nenastavuju ObjectValidator
            //(je to na vás, jak to u Unit Testů uděláte, ale pokud v controlleru používáte TryValidateModel(model), tak jej nějak nastavit musíte ... stejně tak pokud chcete testovat případ, kdy objekt není validní)
            //controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;


            //Act
            iActionResult = await controller.Login(loginViewModel);


            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(HomeController.Index));
            Assert.Matches(redirect.ControllerName, nameof(HomeController).Replace("Controller", String.Empty));
            Assert.Matches(redirect.RouteValues.Single((pair) => pair.Key == "area").Value.ToString(), String.Empty);


        }



        [Fact]
        public async Task Register_ValidSuccess()
        {
            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            var mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            var mockSecurityIdentityApplicationService = new Mock<SecurityIdentityApplicationService>();

            RegisterViewModel rVM = new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtesting@email.cz"
            };

            mockISecurityApplicationService.Setup(security => security.Register(rVM, Roles.Customer));
            

            AccountController controller = new AccountController(mockISecurityApplicationService.Object);
            IActionResult iActionResult = null;



            iActionResult = await controller.Register(rVM);



            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(AccountController.Login));

            int userCount = (await databaseContext.Users.ToListAsync()).Count;
            Assert.Equal(1, userCount);

            Assert.Single(await databaseContext.Users.ToListAsync());

        }


        [Fact]
        public async Task Register()
        {
            RegisterViewModel user = new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtesting@email.cz"
            };

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            mockPrincipal.Setup(x => x.IsInRole(It.IsAny<string>())).Returns(true);

            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(m => m.User).Returns(claimsPrincipal);
        }
    }
}
