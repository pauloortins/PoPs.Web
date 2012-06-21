using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoPs.Web.Models;
using PoPs.Web.Validations;
using SharpTestsEx;
using PoPs.Service;
using Moq;
using PoPs.Domain;

namespace PoPs.Tests.Web.Validations
{
    [TestClass]
    public class UserRegisterViewModelValidatorTest
    {
        [TestMethod]
        public void TestingWithAllFieldsEmpty()
        {
            var viewModel = new UserRegisterViewModel();
            var userService = new Mock<IUserService>();
            userService.Setup(x => x.FindByLogin(It.IsAny<string>())).Returns<User>(null);
            userService.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns<User>(null);

            var validator = new UserRegisterViewModelValidator(userService.Object);
            var results = validator.Validate(viewModel);

            results.Errors.Count.Should().Be(4);
            results.Errors[0].ErrorMessage.Should().Be("'Login' deve ser preenchido.");
            results.Errors[1].ErrorMessage.Should().Be("'Email' deve ser preenchido.");
            results.Errors[2].ErrorMessage.Should().Be("'Senha' deve ser preenchido.");
            results.Errors[3].ErrorMessage.Should().Be("'Repetir Senha' deve ser preenchido.");
        }

        [TestMethod]
        public void TestingWithDifferentsPasswords()
        {
            var viewModel = new UserRegisterViewModel()
            {
                Login = "abcd",
                Email = "abcd@gmail.com",
                Password = "1234",
                PasswordRepeated = "12345"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.FindByLogin(It.IsAny<string>())).Returns<User>(null);
            userService.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns<User>(null);
            
            var validator = new UserRegisterViewModelValidator(userService.Object);
            var results = validator.Validate(viewModel);

            results.Errors.Count.Should().Be(2);
            results.Errors[0].ErrorMessage.Should().Be("As senhas informadas devem ser iguais.");
            results.Errors[1].ErrorMessage.Should().Be("As senhas informadas devem ser iguais.");
        }

        [TestMethod]
        public void TestingWithInvalidEmail()
        {
            var viewModel = new UserRegisterViewModel()
            {
                Login = "abcd",
                Email = "abcd",
                Password = "1234",
                PasswordRepeated = "1234"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.FindByLogin(It.IsAny<string>())).Returns<User>(null);
            userService.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns<User>(null);

            var validator = new UserRegisterViewModelValidator(userService.Object);
            var results = validator.Validate(viewModel);

            results.Errors.Count.Should().Be(1);
            results.Errors[0].ErrorMessage.Should().Be("'Email' deve ser um endereço de email válido.");
        }

        [TestMethod]
        public void TestingWithValidData()
        {
            var viewModel = new UserRegisterViewModel()
            {
                Login = "abcd",
                Email = "abcd@gmail.com",
                Password = "1234",
                PasswordRepeated = "1234"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.FindByLogin(It.IsAny<string>())).Returns<User>(null);
            userService.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns<User>(null);

            var validator = new UserRegisterViewModelValidator(userService.Object);
            var results = validator.Validate(viewModel);

            results.Errors.Count.Should().Be(0);
        }

        [TestMethod]
        public void TestingWithInvalidEmailAndLogin()
        {
            var viewModel = new UserRegisterViewModel()
            {
                Login = "abcd",
                Email = "abcd@gmail.com",
                Password = "1234",
                PasswordRepeated = "1234"
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.FindByLogin(It.IsAny<string>())).Returns(
                new User{ Login = "abcd"}
            );
            userService.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns(
                new User{ Login = "abcd@gmail.com"}
            );

            var validator = new UserRegisterViewModelValidator(userService.Object);
            var results = validator.Validate(viewModel);

            results.Errors.Count.Should().Be(2);
            results.Errors[0].ErrorMessage.Should().Be("'Login' já existente.");
            results.Errors[1].ErrorMessage.Should().Be("'Email' já existente.");
        }
    }
}
