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

        [TestMethod]
        public void FindByEmail()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetAll()).Returns(new User[] {
                new User() { Email = "earth@gmail.com"},
                new User() { Email = "sun@gmail.com"},
                new User() { Email = "wind@gmail.com"},
                new User() { Email = "heart@gmail.com"}
            });

            var target = new UserService(mock.Object);
            var result = target.FindByEmail("earth@gmail.com");

            result.Email.Should().Be("earth@gmail.com");
        }

        [TestMethod]
        public void FindByLogin()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetAll()).Returns(new User[] {
                new User() { Login = "earth"},
                new User() { Login = "sun"},
                new User() { Login = "wind"},
                new User() { Login = "heart"}
            });

            var target = new UserService(mock.Object);
            var result = target.FindByLogin("earth");

            result.Login.Should().Be("earth");
        }
    }
}
