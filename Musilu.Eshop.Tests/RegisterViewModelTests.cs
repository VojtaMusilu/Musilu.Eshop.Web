using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Xunit;

using Musilu.Eshop.Web.Models.ViewModels;


namespace Musilu.Eshop.Tests
{
    public class RegisterViewModelTests
    {

        
        // validace že RegisterViewModel má všechny atributy v poho (required, regex hesla atd...) udělat mimo

        [Fact]
        public void RegisterViewModel_Valid()
        {
            RegisterViewModel sut = GetRegisterVM_Valid();
            // Set some properties here

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.True(isModelStateValid);
        }

        [Fact]
        public void RegisterViewModel_InvalidUsername()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidUsername();
            

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }

        [Fact]
        public void RegisterViewModel_InvalidPassword_Short()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPassword_Short();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        [Fact]
        public void RegisterViewModel_InvalidPassword_NoNumbers()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPassword_NoNumbers();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        [Fact]
        public void RegisterViewModel_InvalidPassword_NoSpecialCharacters()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPassword_NoSpecialCharacters();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        [Fact]
        public void RegisterViewModel_InvalidPassword_NoLowercase()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPassword_NoLowercase();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        [Fact]
        public void RegisterViewModel_InvalidPassword_NoUppercase()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPassword_NoUppercase();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        [Fact]
        public void RegisterViewModel_InvalidRepeatedPassword()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidRepeatedPassword();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        

        [Fact]
        public void RegisterViewModel_InvalidEmail()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidEmail();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        [Fact]
        public void RegisterViewModel_InvalidPhone_Short()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPhone_Short();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
        }
        
        
        [Fact]
        public void RegisterViewModel_InvalidPhone_Letters()
        {
            RegisterViewModel sut = GetRegisterVM_InvalidPhone_Letters();


            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            // Assert

            Assert.False(isModelStateValid);
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


        RegisterViewModel GetRegisterVM_InvalidUsername()
        {
            return new RegisterViewModel()
            {
                Username = null,
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtesting@email.cz"
            };
        }
        
        RegisterViewModel GetRegisterVM_InvalidPassword_Short()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc",
                RepeatedPassword = "Abc",
                Email = "utbtesting@email.cz"
            };
        }
        
        RegisterViewModel GetRegisterVM_InvalidPassword_NoNumbers()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "ABC_def",
                RepeatedPassword = "ABC_def",
                Email = "utbtesting@email.cz"
            };
        }
        
        RegisterViewModel GetRegisterVM_InvalidPassword_NoSpecialCharacters()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "ABCdef123",
                RepeatedPassword = "ABCdef123",
                Email = "utbtesting@email.cz"
            };
        }


        RegisterViewModel GetRegisterVM_InvalidPassword_NoUppercase()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "abc_123",
                RepeatedPassword = "abc_123",
                Email = "utbtesting@email.cz"
            };
        }
        
        RegisterViewModel GetRegisterVM_InvalidPassword_NoLowercase()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "ABC_123",
                RepeatedPassword = "ABC_123",
                Email = "utbtesting@email.cz"
            };
        }

        RegisterViewModel GetRegisterVM_InvalidRepeatedPassword()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_122",
                Email = "utbtesting@email.cz"
            };
        }

        RegisterViewModel GetRegisterVM_InvalidEmail()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "123456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtestingemail.cz"
            };
        }
        
        RegisterViewModel GetRegisterVM_InvalidPhone_Short()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "12345678",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtestingemail.cz"
            };
        }
        
        RegisterViewModel GetRegisterVM_InvalidPhone_Letters()
        {
            return new RegisterViewModel()
            {
                Username = "testUser",
                FirstName = "Adam",
                LastName = "Tester",
                Phone = "ab3456789",
                Password = "Abc_123",
                RepeatedPassword = "Abc_123",
                Email = "utbtestingemail.cz"
            };
        }

    }
}
