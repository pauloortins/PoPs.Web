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
    }
}
