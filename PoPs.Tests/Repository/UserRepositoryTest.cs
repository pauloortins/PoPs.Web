using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using PoPs.Repository.Repositories;
using PoPs.Domain;
using SharpTestsEx;
using PoPs.Repository;
using Moq;

namespace PoPs.Tests.Repository
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void Create()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var newUser = new User()
                {
                    Login = "1234",
                    Password = "1234",
                    Email = "1234@test.com"
                };

                var target = new UserRepository(new EFContext());

                target.Create(newUser);

                var addedUser = target.GetAll().First(x => x.Login.Equals(newUser.Login));

                addedUser.Password.Should().Be(newUser.Password);
                addedUser.Email.Should().Be(newUser.Email);
            }
        }

        [TestMethod]
        public void Update()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var newUser = new User()
                {
                    Login = "1234",
                    Password = "1234",
                    Email = "1234@test.com"
                };

                var target = new UserRepository(new EFContext());

                target.Create(newUser);

                var addedUser = target.GetAll().First(x => x.Login.Equals(newUser.Login));

                addedUser.Email = "5678@test.com";
                addedUser.Password = "12345";

                target.Update(addedUser);

                var updatedUser = target.GetAll().First(x => x.Login.Equals(newUser.Login));

                updatedUser.Password.Should().Be(addedUser.Password);
                updatedUser.Email.Should().Be(addedUser.Email);
            }
        }
    }
}
