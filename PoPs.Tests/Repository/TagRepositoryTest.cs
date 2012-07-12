using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoPs.Repository.Repositories;
using PoPs.Domain;
using PoPs.Repository;
using System.Transactions;
using SharpTestsEx;

namespace PoPs.Tests.Repository
{
    [TestClass]
    public class TagRepositoryTest
    {
        [TestMethod]
        public void Create()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                TagRepository target = new TagRepository(new EFContext());

                Tag model = new Tag()
                {
                    Name = "PopTag"
                };

                target.Create(model);

                Tag addedTag = target.GetAll().FirstOrDefault(w => w.Name == "PopTag");

                addedTag.Name.Should().Be("PopTag");
            }
        }

         [TestMethod]
        public void Update()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                TagRepository target = new TagRepository(new EFContext());

                Tag model = new Tag()
                {
                    Name = "PopTag"
                };

                target.Create(model);

                Tag updateTag = target.GetAll().FirstOrDefault(w => w.Name == "PopTag");

                updateTag.Name = "PopTagUpdated";

                target.Update(updateTag);

                Tag updatedTag = target.GetAll().FirstOrDefault(w => w.Name == "PopTagUpdated");

                updatedTag.Name.Should().Be("PopTagUpdated");
            }
        }
    }
}
