using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoPs.Web.Models;
using SharpTestsEx;

namespace PoPs.Tests.Web.Models
{
    [TestClass]
    public class UserRegisterViewModelTest
    {
        [TestMethod]
        public void ConvertToDomain()
        {
            var viewModel = new UserRegisterViewModel()
            {
                Login = "abcd",
                Email = "abcd@gmail.com",
                Password = "1234",
                PasswordRepeated = "1234"
            };

            var user = viewModel.ConvertToDomain();

            user.Login.Should().Be(viewModel.Login);
            user.Email.Should().Be(viewModel.Email);
            user.Password.Should().Be("81DC9BDB52D04DC20036DBD8313ED055");
        }
    }
}
