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
    public class LeadProductsControllerTests
    {
        private Mock<ILeadProductRepository> _leadProductRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private LeadProductsController _controller;
        private LeadProduct[] _leadProducts;



        [TestInitialize]
        public void Intialize()
        {
            //Setup AutoMapper
            WebApiConfig.SetupAutomapper();

            //Set up Repositories
            _leadProductRepositoryMock = new Mock<ILeadProductRepository>();


            //Build Lead Products Below
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


            //Setup Mock LeadProduct Repository
            _leadProductRepositoryMock.Setup(lp => lp.GetAll()).Returns(_leadProducts.AsQueryable());
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(0)).Returns(_leadProducts[0]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(1)).Returns(_leadProducts[1]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(2)).Returns(_leadProducts[2]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(3)).Returns(_leadProducts[3]);

            //Setup Unit Of Work and controller
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _controller = new LeadProductsController(_leadProductRepositoryMock.Object, _unitOfWorkMock.Object);


        }


  

        [TestMethod] // [0]
        public void GetLeadProductsReturnLeadProducts()
        {
            //Arrange

            //Act
            var leadProducts = _controller.GetAllLeadProducts();

            //Assert
            _leadProductRepositoryMock.Verify(lp => lp.GetAll(), Times.Once);
            Assert.AreEqual(leadProducts.Count(), 4);


        }

        [TestMethod] // [1]
        public void GetLeadProductByIDReturnLeadProduct()
        {
            //arrage

            //act
            IHttpActionResult leadProduct = _controller.GetLeadProduct(0);

            //assert
            _leadProductRepositoryMock.Verify(lp => lp.GetByID(0), Times.Once);
            Assert.IsInstanceOfType(leadProduct, typeof(OkNegotiatedContentResult<LeadProductModel>));

            //extract the cointent from the HTTP result
            //Verify the content is not NUll and the ID's Match
            var contentResult = leadProduct as OkNegotiatedContentResult<LeadProductModel>;
            Assert.IsNotNull(leadProduct);
            Assert.AreEqual(contentResult.Content.LeadProductID, 0);
           
        }

        [TestMethod] // [2]
        public void GetAllLeadProductsFromCompanyReturnLeadProducts()
        {
            //Arrange
            _leadProductRepositoryMock.Setup(lp => lp.Where(It.IsAny<Expression<Func<LeadProduct, bool>>>()))
                                       .Returns(_leadProducts.Where(lp => lp.Company.LeadProducts.Any(lep => lep.CompanyID == 1)).AsQueryable());

            //Act
            var leadProductsQuery = _controller.GetAllLeadProductsFromComapny(1);


            //Assert
            _leadProductRepositoryMock.Verify(lpr => lpr.GetAll(), Times.Once);
            Assert.AreEqual(leadProductsQuery.Count(), 2);         
        }

        [TestMethod]
        public void PutLeadProductReturnLeadProduct()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutLeadProduct(
                   0,
                   new LeadProductModel
                   {
                       LeadProductID = 5,
                       CompanyID = 1,
                       IsArchived = false
                   });

            var statusCodeResult = actionResult as StatusCodeResult;
            //Assert
            _leadProductRepositoryMock.Verify(lp => lp.GetByID(5), Times.Once);
            _leadProductRepositoryMock.Verify(lp => lp.Update(It.IsAny<LeadProduct>()), Times.Once);
        }

        [TestMethod]
        public void PostLeadProductReturnLeadProduct()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutLeadProduct(
                    1,
                    new LeadProductModel
                    {
                        LeadProductID = 1,
                        CompanyID = 1,
                        IsArchived = false
                        
                    });
            var statusCodeResult = actionResult as StatusCodeResult;

            //Assert
            _leadProductRepositoryMock.Verify(lp => lp.Add(It.IsAny<LeadProduct>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.AtLeastOnce);
            Assert.IsInstanceOfType
                (actionResult, typeof(CreatedAtRouteNegotiatedContentResult<LeadProductModel>));
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<LeadProductModel>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(createdResult.RouteName, "DefaultApi");

        }

        [TestMethod]
        public void DeleteCompanyReturnsOk()
        {
            //Arrange


            //Act
            IHttpActionResult actionResult = _controller.DeleteLeadProduct(1);

            //Assert
            _leadProductRepositoryMock.Verify(lp => lp.GetByID(1), Times.Once);
            _leadProductRepositoryMock.Verify(lp => lp.Update(It.IsAny<LeadProduct>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<LeadProductModel>));
            var contentResult = actionResult as OkNegotiatedContentResult<LeadProductModel>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.LeadProductID == 1);
        }

    }
}
