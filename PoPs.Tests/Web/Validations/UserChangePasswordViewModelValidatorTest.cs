using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoPs.Service;
using PoPs.Web.Validations;
using PoPs.Web.Models;
using SharpTestsEx;
using PoPs.Domain;
using PoPs.Infrasctructure;

namespace PoPs.Tests.Web.Validations
{
    [TestClass]
    public class UserChangePasswordViewModelValidatorTest
    {
        [TestMethod]
        public void TryToChangePasswordWithoutData()
        {
            var mock = new Mock<IUserService>();

            var target = new UserChangePasswordViewModelValidator(mock.Object, "pops.pops");

            var result = target.Validate(new UserChangePasswordViewModel());

            result.Errors.Count.Should().Be(3);
            result.Errors[0].ErrorMessage.Should().Be("'Senha Atual' deve ser preenchido.");
            result.Errors[1].ErrorMessage.Should().Be("'Senha' deve ser preenchido.");
            result.Errors[2].ErrorMessage.Should().Be("'Repetir Senha' deve ser preenchido.");

        }

        [TestMethod]
        public void TryToChangePasswordWithWrongData()
        {
            var login = "pops.pops";

            var mock = new Mock<IUserService>();

            mock.Setup(m => m.FindByLogin(login)).Returns(new User
            {
                Login = "pops"
            });

            var target = new UserChangePasswordViewModelValidator(mock.Object, login);

            var changePassword = new UserChangePasswordViewModel
            {
                OldPassword = "1234",
                NewPassword = "123456",
                NewPasswordRepeated = "123457",
            };

            var result = target.Validate(changePassword);

            result.Errors.Count.Should().Be(3);
            result.Errors[0].ErrorMessage.Should().Be("'Senha Atual' inválida.");
            result.Errors[1].ErrorMessage.Should().Be("As senhas informadas devem ser iguais.");
            result.Errors[2].ErrorMessage.Should().Be("As senhas informadas devem ser iguais.");

        }

        [TestMethod]
        public void TryToChangePasswordWithValidData()
        {
            var login = "pops.pops";

            var mock = new Mock<IUserService>();

            mock.Setup(m => m.FindByLogin(login)).Returns(new User
            {
                Login = "pops.posps",
                Password = PasswordHash.GetMD5Hash("1234")
            });

            var target = new UserChangePasswordViewModelValidator(mock.Object, login);

            var changePassword = new UserChangePasswordViewModel
            {
                OldPassword = "1234",
                NewPassword = "123456",
                NewPasswordRepeated = "123456",
            };

            var result = target.Validate(changePassword);

            result.Errors.Count.Should().Be(0);

        }
    }
}
