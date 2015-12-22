using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReviewApplication.Core.Domain;
using ReviewApplication.API.Controllers;
using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Repository;
using System.Linq;
using System.Collections.ObjectModel;
using System.Web.Http;
using System.Web.Http.Results;
using ReviewApplication.Core.Models;
using System.Net;
using System.Linq.Expressions;

namespace ReviewApplication.API.Test.ReviewApplication
{
    [TestClass]
    [System.Runtime.InteropServices.Guid("F717934F-5092-4B51-9F89-E2254EA9F00E")]
    public class IndustriesControllerTests
    {
        private Mock<IIndustryRepository> _industryRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private IndustriesController _controller;
        private Industry[] _industries;

        [TestInitialize]
        public void Intialize()
        {
            //Setup AutoMapper
            WebApiConfig.SetupAutomapper();

            //Set up Repositories
            _industryRepositoryMock = new Mock<IIndustryRepository>();

            //Build Industries
            _industries = new[]
           {
                new Industry
                {
                    IndustryID = 0,
                    IsArchived = false,
                    Description = "Life Insurance",
                   
                },

                new Industry
                {
                    IndustryID = 1,
                    IsArchived = false,
                    Description = "Health Insurance"
                },

                new Industry
                {
                    IndustryID = 2,
                    IsArchived = false,
                    Description = "Property and Casualty"
                },

                new Industry
                {
                    IndustryID = 3,
                    IsArchived = false,
                    Description = "Medicare"
                },

                new Industry
                {
                    IndustryID = 4,
                    IsArchived = false,
                    Description = "Annuities"
                }

            };

      
            //Setup Mock Industry Repository
            _industryRepositoryMock.Setup(ir => ir.GetAll()).Returns(_industries.AsQueryable());
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[0]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(1)).Returns(_industries[1]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(2)).Returns(_industries[2]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(3)).Returns(_industries[3]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(4)).Returns(_industries[4]);

            // Set up unit of work and controller
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _controller = new IndustriesController(_industryRepositoryMock.Object, _unitOfWorkMock.Object);
        }
        

        [TestMethod] // [0]
        public void GetIndustriesReturnIndustries()
        {
            //Arrange

            //Act
            var industries = _controller.GetIndustries();

            //Assert

           // TODO: Fix GetAll Test |refrence Karens Code| _industryRepositoryMock.Verify(ir => ir.GetAll((It.IsAny<Industry>()), Times.Once));
            Assert.AreEqual(5, industries.Count());

        }

        [TestMethod] // [1]
        public void GetIndustryReturnInsdustry()
        {
            //Arrange

            //act
            IHttpActionResult actionResult = _controller.GetIndustry(1);

            //assert
            _industryRepositoryMock.Verify(ir => ir.GetByID(1), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<IndustryModel>));
        }

        [TestMethod] //[2]
        public void PutIndustryReturnIndustry()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutIndustry(
                    0,
                    new IndustryModel
                    {
                        IndustryID = 0,
                        Description = ""
                    });
            var statusCodeResult = actionResult as StatusCodeResult;
            //Assert
            _industryRepositoryMock.Verify(i => i.GetByID(0), Times.Once);
            _industryRepositoryMock.Verify(i => i.Update(It.IsAny<Industry>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(statusCodeResult.StatusCode, HttpStatusCode.NoContent);
            
        }

        [TestMethod] // [3]
        public void PostIndustryReturnIndustry()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PostIndustry(
                    new IndustryModel
                    {
                        IndustryID = 5,
                        IsArchived = false
                    });

            var StatusCodeResult = actionResult as StatusCodeResult;
            //Assert
            _industryRepositoryMock.Verify(ir => ir.Add(It.IsAny<Industry>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType
              (actionResult, typeof(CreatedAtRouteNegotiatedContentResult<IndustryModel>));
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<IndustryModel>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(createdResult.RouteName, "DefaultApi");
        }

        [TestMethod] // [4]
        public void DeleteIndustryReturnOk()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult = _controller.DeleteIndustry(1);

            //Assert
            _industryRepositoryMock.Verify(ir => ir.GetByID(1), Times.Once);
            _industryRepositoryMock.Verify(i => i.Update(It.IsAny<Industry>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<IndustryModel>));
            var contentResult = actionResult as OkNegotiatedContentResult<IndustryModel>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.IndustryID == 1);
        }

    }
}
