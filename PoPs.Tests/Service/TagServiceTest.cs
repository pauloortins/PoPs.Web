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
    public class TagServiceTest
    {
        [TestMethod]
        public void Create()
        {
            var mock = new Mock<ITagRepository>();

            var target = new TagService(mock.Object);

            target.Create(new Tag());

            mock.Verify(x => x.Create(It.IsAny<Tag>()), Times.Once());
        }

        [TestMethod]
        public void Update()
        {
            var mock = new Mock<ITagRepository>();

            var target = new TagService(mock.Object);

            target.Update(new Tag());

            mock.Verify(x => x.Update(It.IsAny<Tag>()), Times.Once());
        }

        [TestMethod]
        public void GetAll()
        {
            var mock = new Mock<ITagRepository>();

            mock.Setup(s => s.GetAll()).Returns(
                new List<Tag> { 
                    new Tag { Id = 1, Name = "Tag1" },
                    new Tag { Id = 2, Name = "Tag2" } 
                }
            );

            var target = new TagService(mock.Object);

            IEnumerable<Tag> pops = target.GetAll();

            mock.Verify(x => x.GetAll(), Times.Once());
            
            pops.Count().Should().Be(2);

            pops.Satisfy(s => s.FirstOrDefault(w => w.Id == 1) != null);
            pops.Satisfy(s => s.FirstOrDefault(w => w.Id == 2) != null);
        }
    }
}

