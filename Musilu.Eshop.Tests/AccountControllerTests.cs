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
using Musilu.Eshop.Tests.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Musilu.Eshop.Tests
{

    public class AccountFixture
    {
        public string _ValidUsername = "superadmin";
        public string _ValidPassword = "123";

        public Mock<ISecurityApplicationService> _mockISecurityApplicationService;
        public EshopDbContext _databaseContext;


        public AccountFixture()
        {

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            _databaseContext = new EshopDbContext(options);
            _databaseContext.Database.EnsureCreated();




            _mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            _mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
           .Returns<LoginViewModel>((loginVM) => {
               return Task<bool>.Run(() =>
               {
                   if (loginVM.Username == _ValidUsername && loginVM.Password == _ValidPassword)
                   { return true; }
                   else
                   { return false; }

               });
           });

            _mockISecurityApplicationService.Setup(security => security.Register(It.IsAny<RegisterViewModel>(), Roles.Customer))
                .Returns((RegisterViewModel vm, Roles role) => {
                    return Task<string[]>.Run(() =>
                    {

                        User user = new User()
                        {
                            UserName = vm.Username,
                            FirstName = vm.FirstName,
                            LastName = vm.LastName,
                            Email = vm.Email,
                            PhoneNumber = vm.Phone
                        };

                        string[] errors = null;
                        var result = _databaseContext.Users.AddAsync(user);
                        _databaseContext.SaveChanges();

                        if (result.IsCompletedSuccessfully == false)
                        {
                            errors.Append("couldnt insert into db");
                        }


                        return errors;

                    });
                });






        }



    }



    public class AccountControllerTests : IClassFixture<AccountFixture>
    {
        AccountFixture fixture;

        public AccountControllerTests(AccountFixture fixture){

            this.fixture = fixture;

        }

        [Fact]
        public async Task Login_Success()
        {
            // Arrange
            LoginViewModel loginViewModel = GetLoginVM_Valid();

            AccountController controller = new AccountController(fixture._mockISecurityApplicationService.Object);
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
        public async Task Login_Fail()
        {
            // Arrange
            LoginViewModel loginViewModel = GetLoginVM_Invalid();
            AccountController controller = new AccountController(fixture._mockISecurityApplicationService.Object);
            IActionResult iActionResult = null;


            //Act
            iActionResult = await controller.Login(loginViewModel);


            // Assert
            ViewResult redirect = Assert.IsType<ViewResult>(iActionResult);
            
            var model = Assert.IsAssignableFrom<LoginViewModel>(redirect.ViewData.Model);
            Assert.True(model.LoginFailed);

        }


        


        [Fact]
        public async Task Register_Success()
        {

            //Arrange
            RegisterViewModel rVM = GetRegisterVM_Valid();

            AccountController controller = new AccountController(fixture._mockISecurityApplicationService.Object);
            controller.ModelState.Clear();

            IActionResult iActionResult = null;


            //Act
            iActionResult = await controller.Register(rVM);


            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(AccountController.Login));

            int userCount = (await fixture._databaseContext.Users.ToListAsync()).Count;
            Assert.Equal(1, userCount);

            Assert.Single(await fixture._databaseContext.Users.ToListAsync());


        }




        [Fact]
        public async Task Register_Fail()
        {
           
            //Arrange
            RegisterViewModel rVM = GetRegisterVM_Invalid();
            AccountController controller = new AccountController(fixture._mockISecurityApplicationService.Object);
            IActionResult iActionResult = null;

            // nastavení že registerViewModel není valid,
            controller.ModelState.AddModelError("test", "test");


            // Act
            iActionResult = await controller.Register(rVM);



            // Assert
            Assert.IsType<ViewResult>(iActionResult);

            int userCount = (await fixture._databaseContext.Users.ToListAsync()).Count;
            Assert.Equal(0, userCount);

            Assert.Empty(await fixture._databaseContext.Users.ToListAsync());


        }



        [Fact]
        public async Task Logout_Success()
        {
            // Arrange
            LoginViewModel loginViewModel = GetLoginVM_Valid();

            AccountController controller = new AccountController(fixture._mockISecurityApplicationService.Object);
            IActionResult iActionResult = null;


            //Act
            iActionResult = await controller.Logout();


            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(AccountController.Login));


        }



        LoginViewModel GetLoginVM_Valid()
        {
            return new LoginViewModel()
            {
                Username = fixture._ValidUsername,
                Password = fixture._ValidPassword
            };
        }
        
        LoginViewModel GetLoginVM_Invalid()
        {
            return new LoginViewModel()
            {
                Username = "userInvalid",
                Password = "xxx",
                LoginFailed = false
            };
        }

        RegisterViewModel GetRegisterVM_Valid()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtesting@email.cz"
            };
        }
        
        
        RegisterViewModel GetRegisterVM_Invalid()
        {
            return new RegisterViewModel()
            {
                Username = null,
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "A",
                RepeatedPassword = "A",
                Email = "utbtesting@email.cz"
            };
        }

    }
}
