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
    public class PopServiceTest
    {
        [TestMethod]
        public void Create()
        {
            var mock = new Mock<IPopRepository>();

            var target = new PopService(mock.Object);

            target.Create(new Pop());

            mock.Verify(x => x.Create(It.IsAny<Pop>()), Times.Once());
        }

        [TestMethod]
        public void Update()
        {
            var mock = new Mock<IPopRepository>();

            var target = new PopService(mock.Object);

            target.Update(new Pop());

            mock.Verify(x => x.Update(It.IsAny<Pop>()), Times.Once());
        }

        [TestMethod]
        public void GetAll()
        {
            var mock = new Mock<IPopRepository>();

            mock.Setup(s => s.GetAll()).Returns(
                new List<Pop> { 
                    new Pop { Id = 1, Title = "Pop1" },
                    new Pop { Id = 2, Title = "Pop2" } 
                }
            );

            var target = new PopService(mock.Object);

            IEnumerable<Pop> pops = target.GetAll();

            mock.Verify(x => x.GetAll(), Times.Once());
            
            pops.Count().Should().Be(2);

            pops.Satisfy(s => s.FirstOrDefault(w => w.Id == 1) != null);
            pops.Satisfy(s => s.FirstOrDefault(w => w.Id == 2) != null);
        }
    }
}

