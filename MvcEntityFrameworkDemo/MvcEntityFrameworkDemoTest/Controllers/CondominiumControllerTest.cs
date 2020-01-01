using System;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkDemo.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDemo.Controllers;
using MvcDemo.Models;

namespace MvcEntityFrameworkDemoTest.Controllers
{
    [TestClass]
    public class CondominiumControllerTest
    {
        private ICondominiumRepository _repository;
        private CondominiumController _controller;
        private CondominiumViewModel _condominium;

        [TestInitialize()]
        public void SetupController()
        {
            _repository = new Mocks.CondominiumMockRepository();
            _controller = new CondominiumController(_repository);
            _condominium = new CondominiumViewModel
            {
                Code = "Condo_123",
                Name = "Condominium Test"
            };
        }

        [TestMethod]
        public void TestCreate()
        {
            //Arrange

            //Act
           var result = _controller.Create(_condominium);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(((Mocks.CondominiumMockRepository)_repository).Collection.Count > 0);
            Assert.IsTrue(((Mocks.CondominiumMockRepository)_repository).Collection[0].Id > 0);
        }

        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            _controller.Create(_condominium);
            _condominium.Id = (from c in ((Mocks.CondominiumMockRepository)_repository).Collection select c).First().Id;
            _condominium.Name = _condominium.Name + "_update";

            //Act
            var result = _controller.Edit(_condominium);

            //Assert
            Assert.IsNotNull(result);
            var updatedCondominium = (from c in ((Mocks.CondominiumMockRepository)_repository).Collection where c.Id == _condominium.Id select c).FirstOrDefault();
            Assert.IsNotNull(updatedCondominium);
            Assert.AreEqual(_condominium.Name, updatedCondominium.Name);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            _controller.Create(_condominium);
            _condominium.Id = (from c in ((Mocks.CondominiumMockRepository)_repository).Collection select c).First().Id;

            //Act
            var result = _controller.Delete(_condominium.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(((Mocks.CondominiumMockRepository)_repository).Collection.Count == 0);
        }

        [TestMethod]
        public void TestDetails()
        {
            //Arrange
            _controller.Create(_condominium);
            _condominium.Id = (from c in ((Mocks.CondominiumMockRepository)_repository).Collection select c).First().Id;

            //Act
            var result = _controller.Details(_condominium.Id) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(_condominium.Id == ((CondominiumViewModel)result.ViewData.Model).Id);
        }
    }
}
