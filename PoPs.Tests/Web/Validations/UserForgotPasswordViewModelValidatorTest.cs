using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoPs.Service;
using PoPs.Domain;
using PoPs.Web.Validations;
using PoPs.Web.Models;
using SharpTestsEx;

namespace PoPs.Tests.Web.Validations
{
    [TestClass]
    public class UserForgotPasswordViewModelValidatorTest
    {
        [TestMethod]
        public void EmptyEmail()
        {
            var mock = new Mock<IUserService>();
            var target = new UserForgotPasswordViewModelValidator(mock.Object);

            var result = target.Validate(new UserForgotPasswordViewModel());

            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("'Email' deve ser preenchido.");
        }

        [TestMethod]
        public void InvalidEmail()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(x => x.FindByEmail(It.IsAny<string>())).Returns<User>(null);

            var target = new UserForgotPasswordViewModelValidator(mock.Object);

            var result = target.Validate(new UserForgotPasswordViewModel { Email = "testing" });

            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("'Email' não cadastrado.");
        }
    }
}
