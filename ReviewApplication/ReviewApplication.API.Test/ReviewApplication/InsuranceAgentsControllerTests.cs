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
    public class InsuranceAgentsControllerTests
    {
        private Mock<IInsuranceAgentRepository> _insuranceAgentRepositoryMock;
        private Mock<IInsuranceAgentIndustryRepository> _insuranceAgentIndustryRepositoryMock;
        private Mock<ILeadTransactionRepository> _leadTransactionRepositoryMock;
        private Mock<IIndustryRepository> _industryRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private InsuranceAgentsController _controller;
        private InsuranceAgent[] _insuranceAgents;
        private Industry[] _industries;
        private InsuranceAgentIndustry[] _insuranceAgentIndustries;
        private LeadTransaction[] _leadTransactions;




        [TestInitialize]
        public void Initialize()
        {
            //Setup AutoMapper
            WebApiConfig.SetupAutomapper();

            //Set up Repositories
            _industryRepositoryMock = new Mock<IIndustryRepository>();
            _insuranceAgentRepositoryMock = new Mock<IInsuranceAgentRepository>();
            _insuranceAgentIndustryRepositoryMock = new Mock<IInsuranceAgentIndustryRepository>();
            _leadTransactionRepositoryMock = new Mock<ILeadTransactionRepository>();



            //Build 2 insurance Agents
            _insuranceAgents = new[]
            {
                new InsuranceAgent
                {
                    InsuranceAgentID = 1,
                    IsArchived = false
                },
                  new InsuranceAgent
                {
                    InsuranceAgentID = 2,
                    IsArchived = false
                }


            };


            //Build Industries
            _industries = new[]
           {
                new Industry
                {
                    IndustryID = 0,
                    IsArchived = false,
                    Description = "Life Insurance"
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

            _insuranceAgentIndustries = new[]
            {
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 1,
                    IndustryID = 0,
                },
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 1,
                    IndustryID = 1,
                },
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 1,
                    IndustryID = 2,
                },
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 1,
                    IndustryID = 3,
                },
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 1,
                    IndustryID = 4,
                },
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 2,
                    IndustryID = 1,
                },
                new InsuranceAgentIndustry
                {
                    InsuranceAgentID = 2,
                    IndustryID = 0,
                }
            };

           


            _leadTransactions = new[]
            {
                new LeadTransaction
                {
                    LeadTransactionID = 0,
                    CompanyID = 0,
                    LeadProductID = 0,
                    InsuranceAgentProfileID = 1,
                    IsArchived = false

                },
                 new LeadTransaction
                {
                    LeadTransactionID = 1,
                    CompanyID = 0,
                    LeadProductID = 0,
                    InsuranceAgentProfileID = 1,
                    IsArchived = false

                },
                  new LeadTransaction
                {
                    LeadTransactionID = 2,
                    CompanyID = 1,
                    LeadProductID = 5,
                    InsuranceAgentProfileID = 2,
                    IsArchived = false

                }



            };




            //Setup Mock Industry Repository
            _industryRepositoryMock.Setup(ir => ir.GetAll()).Returns(_industries.AsQueryable());
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[0]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(1)).Returns(_industries[1]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(2)).Returns(_industries[2]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(3)).Returns(_industries[3]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(4)).Returns(_industries[4]);

            //TODO: setup as Composite 'Mock'       ?????????
            _insuranceAgentIndustryRepositoryMock.Setup(iai => iai.GetAll()).Returns(_insuranceAgentIndustries.AsQueryable());
            _insuranceAgentIndustryRepositoryMock.Setup(iai => iai.GetByID(1, 0)).Returns(_insuranceAgentIndustries[0]);
            
            //Setup Mock InsuranceAgent Repository
            _insuranceAgentRepositoryMock.Setup(iar => iar.GetAll()).Returns(_insuranceAgents.AsQueryable());
            _insuranceAgentRepositoryMock.Setup(iar => iar.GetByID(1)).Returns(_insuranceAgents[0]);
            _insuranceAgentRepositoryMock.Setup(iar => iar.GetByID(2)).Returns(_insuranceAgents[1]);


            //Setup Mock LeadTransations Repository ||| <--- NOT NEEDED?
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetAll()).Returns(_leadTransactions.AsQueryable());
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetByID(0)).Returns(_leadTransactions[0]);
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetByID(1)).Returns(_leadTransactions[1]);
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetByID(2)).Returns(_leadTransactions[2]);




            // Set up unit of work and controller
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _controller = new InsuranceAgentsController(_insuranceAgentRepositoryMock.Object, 
                                             _unitOfWorkMock.Object);

        }

        

        [TestMethod] // [0]
        public void GetAllInsuranceAgentsReturnAllInsuranceAgents()
        {
            //Arrange

            //Act
            var insuranceAgents = _controller.GetInsuranceAgents();

            //Assert
        //  _insuranceAgentRepositoryMock.Verify(iar => iar.Where(It.IsAny<Expression<Func<InsuranceAgent, bool>>>()), Times.Once);
            Assert.AreEqual(insuranceAgents.Count(), 2);
        }
        
        [TestMethod] //[1]
        public void GetInsuranceAgentByIDReturnInsuranceAgent()
        {
            //Arrange

            //Act
            IHttpActionResult insuranceAgents = _controller.GetInsuranceAgent(1);

            //Assert
            _insuranceAgentRepositoryMock.Verify(iar => iar.GetByID(1), Times.Once);
            Assert.IsInstanceOfType(insuranceAgents, typeof(OkNegotiatedContentResult<InsuranceAgentModel>));
            
        }

        [TestMethod] //[2]
        public void GetInsuranceAgentsByIndustryReturnInsuranceAgent()
        {
            //Arrange
            _insuranceAgentRepositoryMock.Setup(iar => iar.Where(It.IsAny<Expression<Func<InsuranceAgent, bool>>>()))
                                    .Returns(_insuranceAgents.Where(ia => ia.Industries.Any(i => i.IndustryID == 1)).AsQueryable());


            //Act
            var insuranceAgents = _controller.GetAllInsuranceAgentsByIndustry(1);

            //Assert
            _insuranceAgentRepositoryMock.Verify(iar => iar.Where(It.IsAny<Expression<Func<InsuranceAgent, bool>>>()), Times.Once);
            Assert.AreEqual(insuranceAgents.Count(), 2);

        }

        [TestMethod] //[3]
        public void PutInsuranceAgentReturnInsuranceAgent()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutInsuranceAgent(
                    1,
                    new InsuranceAgentModel
                    {
                        InsuranceAgentID = 1,
                        IsArchived = false
                    });
            var statusCodeResult = actionResult as StatusCodeResult;

            //Assert
            _insuranceAgentRepositoryMock.Verify(iar => iar.GetByID(1), Times.Once);
            _insuranceAgentRepositoryMock.Verify(iar => iar.Update(It.IsAny<InsuranceAgent>()), Times.Once);
        }

        [TestMethod] //[4]
        public void PostInsuranceAgentReturnInsuranceAgent()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PostInsurnaceAgent(
                    new InsuranceAgentModel
                    {
                        InsuranceAgentID = 3,
                        IsArchived = false
                    });
            var statusCodeResult = actionResult as StatusCodeResult;
            //Assert
            _insuranceAgentRepositoryMock.Verify(iar => iar.Add(It.IsAny<InsuranceAgent>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType
                (actionResult, typeof(OkNegotiatedContentResult<InsuranceAgentModel>));
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<InsuranceAgentModel>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(createdResult.RouteName, "DefaultApi");
        }

        [TestMethod] // [5]
        public void DeleteinsuranceAgentReturnInsurnaceAgent()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult = _controller.DeleteInsuranceAgent(1);


            //Assert
            _insuranceAgentRepositoryMock.Verify(iar => iar.GetByID(1), Times.Once);
            _insuranceAgentRepositoryMock.Verify(iar => iar.Update(It.IsAny<InsuranceAgent>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType
                (actionResult, typeof(OkNegotiatedContentResult<InsuranceAgentModel>));
            var contentResult = actionResult as OkNegotiatedContentResult<InsuranceAgentModel>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.InsuranceAgentID == 1);
        }
    }
}
