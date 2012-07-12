using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoPs.Domain;
using PoPs.Repository;
using PoPs.Repository.Repositories;
using SharpTestsEx;

namespace PoPs.Tests.Repository
{
    [TestClass]
    public class PopRpositoryTest
    {
        [TestMethod]
        public void Create()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                UserRepository userRepo = new UserRepository(new EFContext());
                TagRepository tagRepo = new TagRepository(new EFContext());
                PopRepository target = new PopRepository(new EFContext());

                userRepo.Create(new User()
                {
                    Login = "1234",
                    Password = "1234",
                    Email = "1234@test.com"
                });

                User user = userRepo.GetAll().FirstOrDefault(w => w.Login == "1234");

                tagRepo.Create(new Tag()
                {
                    Name = "Pop"
                });

                Tag tag = tagRepo.GetAll().FirstOrDefault(w => w.Name == "Pop");

                Pop model = new Pop()
                {
                    Title = "New Pop",
                    URL = "New Pop URL",
                    PublishDate = DateTime.Now,
                    Tags = new List<Tag> { tag },
                    User = user
                };

                target.Create(model);

                Pop createdPop = target.GetAll().FirstOrDefault(w => w.Title == model.Title);

                createdPop.Title.Should().Be(model.Title);
                createdPop.URL.Should().Be(model.URL);
                createdPop.PublishDate.Should().Be(model.PublishDate);

                createdPop.Tags.Satisfy(t => t.FirstOrDefault(w => w.Name == "Pop") != null);
                createdPop.User.Login.Should().Be("1234");
            }
        }

        [TestMethod]
        public void Update()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                TagRepository tagRepo = new TagRepository(new EFContext());
                PopRepository target = new PopRepository(new EFContext());

                tagRepo.Create(new Tag()
                {
                    Name = "PopTag_1"
                });

                tagRepo.Create(new Tag()
                {
                    Name = "PopTag_2"
                });

                Tag popTag_1 = tagRepo.GetAll().FirstOrDefault(w => w.Name == "PopTag_1");
                Tag PopTag_2 = tagRepo.GetAll().FirstOrDefault(w => w.Name == "PopTag_2");

                Pop pop = new Pop()
                {
                    Title = "New Pop",
                    URL = "New Pop URL",
                    PublishDate = DateTime.Now,
                    Tags = new List<Tag> { popTag_1 },
                    User = new User()
                    {
                        Login = "1234",
                        Password = "1234",
                        Email = "1234@test.com"
                    }
                };

                target.Create(pop);

                Pop updatePop = target.GetAll().FirstOrDefault(w => w.Title == pop.Title);

                updatePop.Title = "Edited Pop";
                updatePop.URL = "Edited Pop URL";
                updatePop.PublishDate = DateTime.Now;
                updatePop.Tags.Remove(popTag_1);
                updatePop.Tags.Add(PopTag_2);

                target.Update(updatePop);

                Pop updatedPop = target.GetAll().FirstOrDefault(w => w.Title == updatePop.Title);

                updatedPop.Title.Should().Be(updatePop.Title);
                updatedPop.URL.Should().Be(updatePop.URL);
                updatedPop.PublishDate.Should().Be(updatePop.PublishDate);

                updatedPop.Tags.Count.Should().Be(1);

                updatedPop.Tags.Satisfy(t => t.FirstOrDefault(w => w.Name == "PopTag_2") != null);
            }
        }
    }
}

