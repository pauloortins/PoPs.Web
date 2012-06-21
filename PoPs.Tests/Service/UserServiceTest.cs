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
using PoPs.Infrasctructure;

namespace PoPs.Tests.Service
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void Create()
        {
            var mock = new Mock<IUserRepository>();
            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);

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

            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);

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

            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);

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

            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);
            var result = target.FindByEmail("earth@gmail.com");

            result.Email.Should().Be("earth@gmail.com");
        }

        [TestMethod]
        public void FindByNonExistEmail()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetAll()).Returns(new User[] {
                new User() { Email = "earth@gmail.com"},
                new User() { Email = "sun@gmail.com"},
                new User() { Email = "wind@gmail.com"},
                new User() { Email = "heart@gmail.com"}
            });

            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);
            var result = target.FindByEmail("sea@gmail.com");

            result.Should().Be(null);
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

            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);
            var result = target.FindByLogin("earth");

            result.Login.Should().Be("earth");
        }

        [TestMethod]
        public void FindByNonExistLogin()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetAll()).Returns(new User[] {
                new User() { Login = "earth"},
                new User() { Login = "sun"},
                new User() { Login = "wind"},
                new User() { Login = "heart"}
            });

            var emailMock = new Mock<IEmailSender>();

            var target = new UserService(mock.Object, emailMock.Object);
            var result = target.FindByLogin("sea");

            result.Should().Be(null);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var mock = new Mock<IUserRepository>();
            var emailMock = new Mock<IEmailSender>();
            var target = new UserService(mock.Object, emailMock.Object);

            target.Update(new User());

            mock.Verify(x => x.Update(It.IsAny<User>()), Times.Once());
        }

        [TestMethod]
        public void ChangePassword()
        {
            var mock = new Mock<IUserRepository>();
            var emailMock = new Mock<IEmailSender>();
            var target = new UserService(mock.Object, emailMock.Object);

            string oldPassword = "D!W#ASD!@#";

            var user = new User()
            {
                Login = "test",
                Password = oldPassword
            };

            mock.Setup(x => x.GetAll()).Returns(new User[]{
                user
            });

            target.ChangePassword(user.Login, "FSADFASD");

            target.FindByLogin(user.Login).Password.Should().Not.Be(oldPassword);
        }

        [TestMethod]
        public void SendNewPasswordToEmail()
        {
            var mock = new Mock<IUserRepository>();
            var emailMock = new Mock<IEmailSender>();
            var target = new UserService(mock.Object, emailMock.Object);

            string oldPassword = "D!W#ASD!@#";

            var user = new User()
            {
                Email = "test@gmail.com",
                Password = oldPassword
            };

            mock.Setup(x => x.GetAll()).Returns(new User[]{
                user
            });

            target.SendNewPasswordToEmail(user.Email);

            target.FindByEmail(user.Email).Password.Should().Not.Be(oldPassword);
        }
    }
}
