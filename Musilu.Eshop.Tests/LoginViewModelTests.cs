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
            LoginViewModel sut = GetLoginVM_Valid();
            // Set some properties here

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.True(isModelStateValid);
        }
        
        [Fact]
        public void LoginViewModel_MissingUsername_Invalid()
        {
            LoginViewModel sut = GetLoginVM_MissingUsername();
            // Set some properties here

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }

        [Fact]
        public void LoginViewModel_MissingPassword_Invalid()
        {
            LoginViewModel sut = GetLoginVM_MissingPassword();
            // Set some properties here

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

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
