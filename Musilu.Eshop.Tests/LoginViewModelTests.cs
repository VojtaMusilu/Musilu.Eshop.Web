using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Xunit;

using Musilu.Eshop.Web.Models.ViewModels;


namespace Musilu.Eshop.Tests
{
    public class LoginViewModelTests
    {
        [Fact]
        public void LoginViewModel_Valid()
        {
            //Arrange
            LoginViewModel loginVM = GetLoginVM_Valid();
            var context = new ValidationContext(loginVM, null, null);
            var results = new List<ValidationResult>();

            //Act
            var isModelStateValid = Validator.TryValidateObject(loginVM, context, results, true);

            // Assert
            Assert.True(isModelStateValid);
        }
        
        [Fact]
        public void LoginViewModel_MissingUsername_Invalid()
        {
            //Arrange
            LoginViewModel loginVM = GetLoginVM_MissingUsername();
            var context = new ValidationContext(loginVM, null, null);
            var results = new List<ValidationResult>();

            //Act
            var isModelStateValid = Validator.TryValidateObject(loginVM, context, results, true);

            // Assert
            Assert.False(isModelStateValid);
        }

        [Fact]
        public void LoginViewModel_MissingPassword_Invalid()
        {
            //Arrange
            LoginViewModel loginVM = GetLoginVM_MissingPassword();
            var context = new ValidationContext(loginVM, null, null);
            var results = new List<ValidationResult>();

            //Act
            var isModelStateValid = Validator.TryValidateObject(loginVM, context, results, true);

            // Assert
            Assert.False(isModelStateValid);
        }


        LoginViewModel GetLoginVM_Valid()
        {
            return new LoginViewModel
            {
                Username = "asdfghjkl",
                Password = "qwertzuiop_123456",
                LoginFailed = false
            };
        }
        
        LoginViewModel GetLoginVM_MissingUsername()
        {
            return new LoginViewModel
            {
                Username = null,
                Password = "qwertzuiop_123456",
                LoginFailed = false
            };
        }
        LoginViewModel GetLoginVM_MissingPassword()
        {
            return new LoginViewModel
            {
                Username = "asdfghjkl",
                Password = null,
                LoginFailed = false
            };
        }
    }
}
