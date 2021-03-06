﻿using System;
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
using ReviewApplication.Data.Repository;

namespace ReviewApplication.API.Test.ReviewApplication
{
    [TestClass]
    public class LeadTransactionsControllerTests
    {
        private Mock<ILeadTransactionRepository> _leadTransactionRepositoryMock;
        private Mock<IInsuranceAgentRepository> _insuranceAgentRepositoryMock;
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private Mock<LeadProductRepository> _leadProductRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private LeadTransactionsController _controller;
        private LeadTransaction[] _leadTransactions;
        private Company[] _companies;
        private LeadProduct[] _leadProducts;
        private InsuranceAgent[] _insuranceAgents;


        [TestInitialize]
        public void Intialize()
        {
            //Setup AutoMapper
            WebApiConfig.SetupAutomapper();

            //Setup Repositories
            _leadTransactionRepositoryMock = new Mock<ILeadTransactionRepository>();
            _leadProductRepositoryMock = new Mock<LeadProductRepository>();
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _insuranceAgentRepositoryMock = new Mock<IInsuranceAgentRepository>();



            //Build Lead Transaction Objects Below
            _leadProducts = new[]
        {
                //Lead Product for Test Company 1
                new LeadProduct
                {
                    LeadProductID = 0,
                    CompanyID = 1,
                    IsArchived = false,
                    Price = 20,
                    ProductNotes = "Price is per telemarketing lead generated",
                    OrderLink = "http://www.google.com",
                    TelemarketingLead = true,
                    TelemarketingLeadNotes = "Leads will be generated within 2 weeks of order date",
                    MailLead = false,
                    MailLeadLeadNotes = "",
                    Press1Lead = false,
                    Press1LeadNotes = "",
                    InternetLead = false,
                    InternetLeadNotes = "",
                    ColdCallPhoneNumberList = false,
                    ColdCallPhoneNumberListLeadNotes = ""
                },

                //Lead Product for Test Company 1
                new LeadProduct
                {
                     LeadProductID = 1,
                     CompanyID = 1,
                     IsArchived = false,
                     Price = 15,
                     ProductNotes = "Price is per Press-1 Lead Generated",
                     OrderLink = "http://wwww.google.com",
                     TelemarketingLead = false,
                     TelemarketingLeadNotes = "",
                     MailLead = false,
                     MailLeadLeadNotes = "",
                     Press1Lead = true,
                     Press1LeadNotes = "Leads will be generated within 2 weeks of Order date",
                     InternetLead = false,
                     InternetLeadNotes = "",
                     ColdCallPhoneNumberList = false,
                     ColdCallPhoneNumberListLeadNotes = ""
                },

                //Lead Product for Test Company 2
                new LeadProduct
                {
                     LeadProductID = 2,
                     CompanyID = 3,
                     IsArchived = false,
                     Price = 25,
                     ProductNotes = "Price per Telemarketing Lead Generated",
                     OrderLink = "http://wwww.google.com",
                     TelemarketingLead = true,
                     Press1LeadNotes = "",
                     MailLead = false,
                     MailLeadLeadNotes = "",
                     Press1Lead = true,
                     TelemarketingLeadNotes = "Leads will be generated within 2 weeks of Order date",
                     InternetLead = false,
                     InternetLeadNotes = "",
                     ColdCallPhoneNumberList = false,
                     ColdCallPhoneNumberListLeadNotes = ""
                },

                //Lead Product for Test Company 2
                new LeadProduct
                {
                     LeadProductID = 3,
                     CompanyID = 3,
                     IsArchived = false,
                     Price = 15,
                     ProductNotes = "Price is per Press-1 Lead Generated",
                     OrderLink = "http://wwww.google.com",
                     TelemarketingLead = false,
                     TelemarketingLeadNotes = "",
                     MailLead = false,
                     MailLeadLeadNotes = "",
                     Press1Lead = true,
                     Press1LeadNotes = "Leads will be generated within 2 weeks of Order date",
                     InternetLead = false,
                     InternetLeadNotes = "",
                     ColdCallPhoneNumberList = false,
                     ColdCallPhoneNumberListLeadNotes = ""
                }
            };

            _companies = new[]
            {
                //Test Company 1
                new Company
                {
                     CompanyID = 1,
                     UserID = 1,
                     IsArchived = false,
                     CompanyName = "Joe Schmoes Lead Company",
                     Address1 = "101 Wonder Way",
                     Address2 = "Suite: 290",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5553331234",
                     OtherTelephoneNumber = "5551231234",
                     EmailAddress  = "Joe@leads.com",
                     SkypeHandle = "LeadCo",
                     WebsiteURL = "http://www.leadcompany.com",
                     PictureLogoURL = "https://lh5.ggpht.com/E3EDtjhawNHXNOhnid79xqMofjwy6wIciqHC_-Xe77F9HhPfDOYaJLFTyGBYsDeHvQ=w300",
                     Bio = "The best lead company ever.  Like a pheonix we rise from the ashes.",
                     LeadNotes = "Our leads are generated by highly trained tele-sales professionals",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                    //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "joeLeads@leads.com",
                     PaypalComments ="We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "Maximum transaction amount $675",
                     VenmoHandle = "JoesLeadsNow",

                     LeadProducts = _leadProducts.Where(lp => lp.CompanyID == 1).ToArray()
                },

                //Test Company 2
                 new Company
                {
                     CompanyID = 3,
                     UserID = 3,
                     IsArchived = false,
                     CompanyName = "All Star Leads Company",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress  = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                    //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments ="We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     LeadProducts = _leadProducts.Where(lp => lp.CompanyID == 3).ToArray()
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

           



            _leadTransactions = new[]
             {
            new LeadTransaction
            {
                LeadTransactionID = 0,
                CompanyID = 3,
                LeadProductID = 0,
                InsuranceAgentProfileID = 1,
                IsArchived = false

            },
                new LeadTransaction
            {
                LeadTransactionID = 1,
                CompanyID = 3,
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




            //Setup Mock LeadProduct Repository
            _leadProductRepositoryMock.Setup(lp => lp.GetAll()).Returns(_leadProducts.AsQueryable());
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(0)).Returns(_leadProducts[0]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(1)).Returns(_leadProducts[1]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(2)).Returns(_leadProducts[2]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(3)).Returns(_leadProducts[3]);



            //Setup Mock Company Repository
            _companyRepositoryMock.Setup(cr => cr.GetAll()).Returns(_companies.AsQueryable());
            _companyRepositoryMock.Setup(cr => cr.GetByID(1)).Returns(_companies[0]);
            _companyRepositoryMock.Setup(cr => cr.GetByID(3)).Returns(_companies[1]);


            //Setup Mock InsuranceAgent Repository
            _insuranceAgentRepositoryMock.Setup(iar => iar.GetAll()).Returns(_insuranceAgents.AsQueryable());
            _insuranceAgentRepositoryMock.Setup(iar => iar.GetByID(1)).Returns(_insuranceAgents[0]);
            _insuranceAgentRepositoryMock.Setup(iar => iar.GetByID(2)).Returns(_insuranceAgents[1]);

            //Setup Mock LeadTransations Repository 
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetAll()).Returns(_leadTransactions.AsQueryable());
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetByID(0)).Returns(_leadTransactions[0]);
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetByID(1)).Returns(_leadTransactions[1]);
            _leadTransactionRepositoryMock.Setup(ltr => ltr.GetByID(2)).Returns(_leadTransactions[2]);




            //Setup Unit Of Work and controller
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _controller = new LeadTransactionsController(_leadTransactionRepositoryMock.Object, _unitOfWorkMock.Object);
            
        }


        //Build Test Methods Below

        [TestMethod] //[0]
        public void GetAllLeadTransactionsReturnAllLeadTransations()
        {
            //Arrange

            //Act
            var leadTransactions = _controller.GetAllLeadTranasactions();

            //Assert
            _leadTransactionRepositoryMock.Verify(ltr => ltr.GetAll(), Times.Once);
            Assert.AreEqual(leadTransactions.Count(), 3);
        }


        [TestMethod] // [1]
        public void GetLeadTransactionByIDReturnLeadTransaction()
        {
            //Arrange

            //Act
            IHttpActionResult leadTransaction = _controller.GetLeadTransactionByID(1);

            //assert
            _leadTransactionRepositoryMock.Verify(lp => lp.GetByID(1), Times.Once);
            Assert.IsInstanceOfType(leadTransaction, typeof(OkNegotiatedContentResult<LeadTransaction>));

            //extract the cointent from the HTTP result
            //Verify the content is not NUll and the ID's Match
            var contentResult = leadTransaction as OkNegotiatedContentResult<LeadTransaction>;
            Assert.IsNotNull(leadTransaction);
            Assert.AreEqual(contentResult.Content.LeadTransactionID, 1);
      
        }

        [TestMethod] // [2] 
        public void GetLeadTransactionsForCompany()
        {
            //Arrange
            _leadTransactionRepositoryMock.Setup(lt => lt.Where(It.IsAny<Expression<Func<LeadTransaction, bool>>>()))
                            .Returns(_leadTransactions.Where(lt => lt.Company.Transactions.Any(lwt => lwt.CompanyID == 1)).AsQueryable());

            //Act
            var leadTransactionQuery = _controller.GetLeadTransactionsforCompany(1);

            //Assert
            _leadTransactionRepositoryMock.Verify(lt => lt.GetAll(), Times.Once);
            Assert.AreEqual(leadTransactionQuery.Count(), 1);
        }


        [TestMethod] // [3]
        public void GetLeadTransactionForInsuranceAgent()
        {
            //Arrange
            _leadTransactionRepositoryMock.Setup(lt => lt.Where(It.IsAny<Expression<Func<LeadTransaction, bool>>>()))
                        .Returns(_leadTransactions.Where(lt => lt.Agent.Transactions.Any(at => at.InsuranceAgentProfileID == 1)).AsQueryable());

            //Act
            var leadTransactionQuery = _controller.GetLeadTransactionforInsuranceAgent(1);

            //Assert
            _leadTransactionRepositoryMock.Verify(lt => lt.GetAll(), Times.Once);
            Assert.AreEqual(leadTransactionQuery.Count(), 2);
        }

        [TestMethod] // [4]
        public void GetLeadTransactionForLeadProduct()
        {
            //Arrange
            _leadTransactionRepositoryMock.Setup(lt => lt.Where(It.IsAny<Expression<Func<LeadTransaction, bool>>>()))
                        .Returns(_leadTransactions.Where(lt => lt.LeadProductID.Equals(0)).AsQueryable());

            //Act
            var leadTransactionQuery = _controller.GetLeadTransactionsForLeadProduct(0);

            //Assert
            _leadTransactionRepositoryMock.Verify(lt => lt.Where(It.IsAny<Expression<Func<LeadTransaction, bool>>>()), Times.Once);
            Assert.AreEqual(leadTransactionQuery.Count(), 2);
        }

        [TestMethod] // [5]
        public void PutLeadTransactionReturnLeadTranasactions()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutLeadTransaction(
                    0,
                    new LeadTransactionModel
                    {
                        LeadTransactionID = 0,
                        IsArchived = false,
                        LeadProductID = 2
            
                    });
            var statusCodeResult = actionResult as StatusCodeResult;

            //Assert
            _leadTransactionRepositoryMock.Verify(lt => lt.GetByID(0), Times.Once);
            _leadTransactionRepositoryMock.Verify(lt => lt.Update(It.IsAny<LeadTransaction>()), Times.Once);
            
        }


        [TestMethod] // [6]
        public void PostLeadTransactionReturnLeadTransaction()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PostLeadTranscation(
                    new LeadTransactionModel
                    {
                        LeadTransactionID = 10,
                        CompanyID = 4,
                        IsArchived = false
                    });
            var statusCodeResult = actionResult as StatusCodeResult;

            //Assert
            _leadTransactionRepositoryMock.Verify(lp => lp.Add(It.IsAny<LeadTransaction>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.AtLeastOnce);
            Assert.IsInstanceOfType
                (actionResult, typeof(CreatedAtRouteNegotiatedContentResult<LeadTransactionModel>));
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<LeadTransactionModel>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(createdResult.RouteName, "DefaultApi");





        }

        [TestMethod] // [7]
        public void DeleteLeadTransactionReturnLeadTransaction()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult = _controller.DeleteLeadTransaction(1);

            //Assert
            _leadTransactionRepositoryMock.Verify(lp => lp.GetByID(1), Times.Once);
            _leadTransactionRepositoryMock.Verify(lp => lp.Update(It.IsAny<LeadTransaction>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<LeadTransactionModel>));
            var contentResult = actionResult as OkNegotiatedContentResult<LeadTransactionModel>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.LeadTransactionID == 1);


        }









    }





}

