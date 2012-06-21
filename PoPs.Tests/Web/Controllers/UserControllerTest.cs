﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoPs.Service;
using PoPs.Web.Controllers;
using System.Web.Mvc;
using SharpTestsEx;
using PoPs.Domain;
using PoPs.Web.Models;
using System.Transactions;
using PoPs.Web.Infrastructure;

namespace PoPs.Tests.Web.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void GetRegister()
        {
            var userService = new Mock<IUserService>();
            var authProvider = new Mock<IAuthProvider>();
            var target = new UserController(userService.Object, authProvider.Object);

            ViewResult result = (ViewResult) target.Register();

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void TryToRegisterWithValidData()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var userService = new Mock<IUserService>();
                var authProvider = new Mock<IAuthProvider>();
                var target = new UserController(userService.Object, authProvider.Object);

                var user = new UserRegisterViewModel()
                {
                    Login = "abcd",
                    Email = "abcd@gmail.com",
                    Password = "1234",
                    PasswordRepeated = "1234"
                };

                target.Register(user);

                userService.Verify(x => x.Create(It.IsAny<User>()), Times.Once());
            }
        }

        [TestMethod]
        public void TryToRegisterWithInvalidData()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var userService = new Mock<IUserService>();
                var authProvider = new Mock<IAuthProvider>();
                var target = new UserController(userService.Object, authProvider.Object);

                target.ModelState.AddModelError("error", "error");

                var user = new UserRegisterViewModel();

                target.Register(user);

                userService.Verify(x => x.Create(It.IsAny<User>()), Times.Never());
            }
        }

        [TestMethod]
        public void TryToLoginWithFalseAuthentication()
        {
            var userService = new Mock<IUserService>();

            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            var target = new UserController(userService.Object, authProvider.Object);

            var result = target.Login(new UserLoginViewModel() { Login = "abcd", Password="1234" });

            result.GetType().Should().Be(typeof(ViewResult));
        }

        [TestMethod]
        public void TryToLoginWithValidData()
        {
            var userService = new Mock<IUserService>();

            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var target = new UserController(userService.Object, authProvider.Object);

            var result = target.Login(new UserLoginViewModel() { Login = "abcd", Password = "1234" });

            result.GetType().Should().Be(typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void TryToLoginInvalidData()
        {
            var userService = new Mock<IUserService>();

            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var target = new UserController(userService.Object, authProvider.Object);

            target.ModelState.AddModelError("error", "error");
            var result = target.Login(new UserLoginViewModel() { Login = "abcd", Password = "1234" });

            result.GetType().Should().Be(typeof(ViewResult));
        }

        [TestMethod]
        public void TryToRecoverPasswordWithValidData()
        {
            var userService = new Mock<IUserService>();

            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var target = new UserController(userService.Object, authProvider.Object);

            var result = target.Forgot(new UserForgotPasswordViewModel() { });

            result.GetType().Should().Be(typeof(ViewResult));
        }

        [TestMethod]
        public void TryToRecoverPasswordWithInvalidData()
        {
            var userService = new Mock<IUserService>();

            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var target = new UserController(userService.Object, authProvider.Object);
            target.ModelState.AddModelError("error", "error");

            var result = target.Forgot(new UserForgotPasswordViewModel() { });

            result.GetType().Should().Be(typeof(ViewResult));
        }
    }
}
