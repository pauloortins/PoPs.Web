using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoPs.Web.Models;
using PoPs.Web.Validations;
using SharpTestsEx;

namespace PoPs.Tests.Web.Validations
{
    [TestClass]
    public class UserLoginViewModelValidatorTest
    {
        [TestMethod]
        public void TestingWithAllFieldsEmpty()
        {
            var viewModel = new UserLoginViewModel();
            var validator = new UserLoginViewModelValidator();
            var results = validator.Validate(viewModel);

            results.Errors.Count.Should().Be(2);
            results.Errors[0].ErrorMessage.Should().Be("'Login' deve ser preenchido.");
            results.Errors[1].ErrorMessage.Should().Be("'Senha' deve ser preenchido.");
        }
    }
}
