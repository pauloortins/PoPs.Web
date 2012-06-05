using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PoPs.Repository.Repositories;
using PoPs.Service;
using PoPs.Domain;

namespace PoPs.Tests.ServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void GetUserByIdTest()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(x => x.GetUserById(1)).Returns(new User { Id = 1, Login = "Sena" });

            var target = new UserService(mock.Object);

            User user = target.GetUserById(1);

            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Sena", user.Login);
        }
    }
}
