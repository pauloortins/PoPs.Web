using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoPs.Repository.Repositories;
using PoPs.Domain;
using PoPs.Service;
using SharpTestsEx;

namespace PoPs.Tests.Service
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetById()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetById(1)).Returns(new User{ Id=1, Login="Login"});

            var target = new UserService(mock.Object);

            User user = target.GetById(1);

            user.Id.Should().Be(1);
            user.Login.Should().Be("Login");
        }

        [TestMethod]
        public void Create()
        {
            var mock = new Mock<IUserRepository>();
            var target = new UserService(mock.Object);

            target.Create(new User());

            mock.Verify(x => x.Create(It.IsAny<User>()), Times.Once());
        }

        [TestMethod]
        public void LoginWithInvalidUser()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetAll()).Returns(new User[] {
                new User{ Login = "abcd", Password="1234"}
            });

            var target = new UserService(mock.Object);

            var isLogged = target.Login("abdcde", "12345");

            isLogged.Should().Be(false);
        }

        [TestMethod]
        public void LoginWithValidUser()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetAll()).Returns(new User[] {
                new User{ Login = "abcd", Password="1234"}
            });

            var target = new UserService(mock.Object);

            var isLogged = target.Login("abcd", "1234");

            isLogged.Should().Be(true);
        }
    }
}
