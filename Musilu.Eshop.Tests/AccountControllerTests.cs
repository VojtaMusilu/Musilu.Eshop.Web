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
    public class AccountControllerTests
    {
      
        [Fact]
        public async Task Login_Success()
        {
            // Arrange
            var mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
           .Returns<LoginViewModel>((loginVM) => {
               return Task<bool>.Run(() =>
               {
                   if (loginVM.Username == "superadmin" && loginVM.Password == "123")
                   { return true; }
                   else
                   { return false; }

               });
           });


            LoginViewModel loginViewModel = GetLoginVM_Valid();


            AccountController controller = new AccountController(mockISecurityApplicationService.Object);
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
            var mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            mockISecurityApplicationService.Setup(security => security.Login(It.IsAny<LoginViewModel>()))
            .Returns<LoginViewModel>((loginVM) => { return Task<bool>.Run(() =>
               {
                   if (loginVM.Username == "superadmin" && loginVM.Password == "123")
                   { return true; }
                   else
                   { return false; }

               });
            });

            LoginViewModel loginViewModel = GetLoginVM_Invalid();


            AccountController controller = new AccountController(mockISecurityApplicationService.Object);
            controller.ObjectValidator = new ObjectValidator();
            IActionResult iActionResult = null;


            //Act
            iActionResult = await controller.Login(loginViewModel);


            // Assert
            ViewResult redirect = Assert.IsType<ViewResult>(iActionResult);


            var model = Assert.IsAssignableFrom<LoginViewModel>(redirect.ViewData.Model);
            

            Assert.True(model.LoginFailed);

        }


        /*
        
        // validace že RegisterViewModel má všechny atributy v poho (required, regex hesla atd...) udělat mimo

        [Fact]
        public void test_validation()
        {
            RegisterViewModel sut = GetRegisterVM_Valid();
            // Set some properties here

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert here

        }
        */


        [Fact]
        public async Task Register_Success()
        {

            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            var mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            var mockSecurityIdentityApplicationService = new Mock<SecurityIdentityApplicationService>();


            RegisterViewModel rVM = GetRegisterVM_Valid();


            AccountController controller = new AccountController(mockISecurityApplicationService.Object);
            IActionResult iActionResult = null;




            mockISecurityApplicationService.Setup(security => security.Register(It.IsAny<RegisterViewModel>(), Roles.Customer))
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
                        var result = databaseContext.Users.AddAsync(user);
                        databaseContext.SaveChanges();

                        if (result.IsCompletedSuccessfully == false)
                        {
                            errors.Append("couldnt insert into db");
                        }


                        return errors;

                    });
                });


            controller.ModelState.Clear();

            iActionResult = await controller.Register(rVM);



            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(iActionResult);
            Assert.Matches(redirect.ActionName, nameof(AccountController.Login));

            int userCount = (await databaseContext.Users.ToListAsync()).Count;
            Assert.Equal(1, userCount);

            Assert.Single(await databaseContext.Users.ToListAsync());


        }




        [Fact]
        public async Task Register_Fail()
        {
            DbContextOptions options = new DbContextOptionsBuilder<EshopDbContext>()
                                       .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                                       .Options;
            var databaseContext = new EshopDbContext(options);
            databaseContext.Database.EnsureCreated();


            var mockISecurityApplicationService = new Mock<ISecurityApplicationService>();
            var mockSecurityIdentityApplicationService = new Mock<SecurityIdentityApplicationService>();


            RegisterViewModel rVM = GetRegisterVM_Invalid();


            
            mockISecurityApplicationService.Setup(security => security.Register(It.IsAny<RegisterViewModel>(), Roles.Customer))
                .Returns((RegisterViewModel vm, Roles role) => {
                    return Task<string[]>.Run(() =>
                    {
                        // nafejkování metody security.Register(registerVM, Models.Identity.Roles.Customer)
                        User user = new User()
                        {
                            UserName = vm.Username,
                            FirstName = vm.FirstName,
                            LastName = vm.LastName,
                            Email = vm.Email,
                            PhoneNumber = vm.Phone
                        };

                        // asi by se to nemělo takhle napřímo dávat do databáze, a měl by se spíš namockovat userManager ?????
                        // ale to mi furt nejde :)))))))
                        string[] errors = null;
                        var result = databaseContext.Users.AddAsync(user);
                        databaseContext.SaveChanges();
                        
                        if (result.IsCompletedSuccessfully == false)
                        {
                            errors.Append("couldnt insert into db");
                        }


                        return errors;

                    });
                });


            AccountController controller = new AccountController(mockISecurityApplicationService.Object);
            IActionResult iActionResult = null;


            // explicitní nastavení že registerViewModel je invalid,
            // protože controller ho validovat neumí,
            // takže i když se mu pošle blbej registerViewModel, tak bez tohodle nastavení test vždy projde
            // https://stackoverflow.com/a/22563585
            controller.ModelState.AddModelError("test", "test");



            iActionResult = await controller.Register(rVM);



            // Assert
            ViewResult redirect = Assert.IsType<ViewResult>(iActionResult);

            int userCount = (await databaseContext.Users.ToListAsync()).Count;
            Assert.Equal(0, userCount);

            Assert.Empty(await databaseContext.Users.ToListAsync());


        }




        LoginViewModel GetLoginVM_Valid()
        {
            return new LoginViewModel()
            {
                Username = "superadmin",
                Password = "123"
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
