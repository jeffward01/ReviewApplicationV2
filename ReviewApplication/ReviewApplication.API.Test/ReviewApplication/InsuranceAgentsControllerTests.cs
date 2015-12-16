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
        private Mock<IIndustryRepository> _industryRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private InsuranceAgentsController _controller;
        private InsuranceAgent[] _insuranceAgents;
        private Industry[] _industries;
        private InsuranceAgentIndustry[] _insuranceAgentIndustries;




        [TestInitialize]
        public void Initialize()
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
                    Id = 0,
                    IsArchived = false,
                    Description = "Life Insurance"
                },

                new Industry
                {
                    Id = 1,
                    IsArchived = false,
                    Description = "Health Insurance"
                },

                new Industry
                {
                    Id = 2,
                    IsArchived = false,
                    Description = "Property and Casualty"
                },

                new Industry
                {
                    Id = 3,
                    IsArchived = false,
                    Description = "Medicare"
                },

                new Industry
                {
                    Id = 4,
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


            //Setup Mock Industry Repository
            _industryRepositoryMock.Setup(ir => ir.GetAll()).Returns(_industries.AsQueryable());
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[0]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[1]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[2]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[3]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[4]);


            //Setup Mock InsuranceAgentIndustry Repository

            //TODO: BUIILD!

            //Setup Mock InsuranceAgent Repository


            //Setup Mock InsuranceAgentTransations Repository


            // Set up unit of work and controller
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _controller = new InsuranceAgentsController(_insuranceAgentRepositoryMock.Object, 
                                             _unitOfWorkMock.Object);

        }















        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
