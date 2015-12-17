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
    public class CompaniesControllerTests
    {
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private Mock<IIndustryRepository> _industryRepositoryMock;
        private Mock<IReviewPostRepository> _reviewPostRepositoryMock;
        private Mock<ILeadProductRepository> _leadProductRepositoryMock;
        private Mock<ICompanyIndustryRepository> _companyIndustryRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private CompaniesController _controller;
        private Company[] _companies;
        private ReviewPost[] _reviewPosts;
        private LeadProduct[] _leadProducts;
        private Industry[] _industries;
        private CompanyIndustry[] _companyIndustries;

        //Numbers for Tests
        public int _numberOfMockCompanies = 2;


        [TestInitialize]
        public void Initialize()
        {
            //Setup Automapper
            WebApiConfig.SetupAutomapper();

            //Set up Repositories
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _reviewPostRepositoryMock = new Mock<IReviewPostRepository>();
            _leadProductRepositoryMock = new Mock<ILeadProductRepository>();
            _industryRepositoryMock = new Mock<IIndustryRepository>();
            _companyIndustryRepositoryMock = new Mock<ICompanyIndustryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();


            //Set Data in Repositories

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

            _reviewPosts = new[]
            {
                //Review Post for Test company 1
                new ReviewPost
                {
                    ReviewPostID = 0,
                    CompanyID = 1,
                    InsuranceAgentID = 0,
                    LeadProductID = 0,
                    IsArchived = false,
                    ReviewPostDate = new DateTime(2015,12,3,10,55,32),
                    CompanyRating = 5,
                    PostTitle = "Great Company and Customer Service!",
                    PostBody = "I recieved my leads within 10 days of ordering. I converted 10 of the 20 leads and I am very happy",
                    NumberOfLikes = 2

                },

                 //Review Post for Test company 1
                new ReviewPost
                {
                    ReviewPostID = 1,
                    CompanyID = 1,
                    InsuranceAgentID = 1,
                    LeadProductID = 0,
                    IsArchived = false,
                    ReviewPostDate = new DateTime(2015,12,4,10,55,32),
                    CompanyRating = 3,
                    PostTitle = "Quality Leads",
                    PostBody = "Very high quality! I called 20 very happy clients!",
                    NumberOfLikes = 1
                },

                 //Review Post for Test company 1
                new ReviewPost
                {
                    ReviewPostID = 2,
                    CompanyID = 1,
                    InsuranceAgentID = 2,
                    LeadProductID = 0,
                    IsArchived = false,
                    ReviewPostDate = new DateTime(2015,12,4,11,55,32),
                    CompanyRating = 5,
                    PostTitle = "Fantastic leads",
                    PostBody = "Great Customer service! 2 of my leads were bad and they reimbursed me immediately!",
                    NumberOfLikes = 2
                },

                 //Review Post for Test company 2
                 new ReviewPost
                {
                    ReviewPostID = 3,
                    CompanyID = 3,
                    InsuranceAgentID = 3,
                    LeadProductID = 2,
                    IsArchived = false,
                    ReviewPostDate = new DateTime(2015,12,3,10,55,32),
                    CompanyRating = 2,
                    PostTitle = "Not the best leads",
                    PostBody = "Alright leads for the price, many of my clients were confused when I called them. 2/5",
                    NumberOfLikes = 3
                },

                  //Review Post for Test company 2
                 new ReviewPost
                {
                    ReviewPostID = 4,
                    CompanyID = 3,
                    InsuranceAgentID = 4,
                    LeadProductID = 2,
                    IsArchived = false,
                    ReviewPostDate = new DateTime(2015,12,3,11,55,32),
                    CompanyRating = 4,
                    PostTitle = "Quick Leads",
                    PostBody = "Great Leads!  High Conversion Rate!",
                    NumberOfLikes = 2
                },

                  //Review Post for Test company 2
                 new ReviewPost
                {
                    ReviewPostID = 5,
                    CompanyID = 3,
                    InsuranceAgentID = 5,
                    LeadProductID = 2,
                    IsArchived = false,
                    ReviewPostDate = new DateTime(2015,12,3,12,55,32),
                    CompanyRating = 4,
                    PostTitle = "Decent Leads!",
                    PostBody = "No Complaints!  Will use again",
                    NumberOfLikes = 0,
                },

            };

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

            _companyIndustries = new[]
            {
                //Industry for Company 1
                new CompanyIndustry
                {
                CompanyID = 1,
                IndustryID = 0
                },

                //Industry for Company 1
                new CompanyIndustry
                {
                    CompanyID = 1,
                    IndustryID = 1
                },

                 //Industry for Company 1
                new CompanyIndustry
                {
                    CompanyID = 1,
                    IndustryID = 3
                },

                 //Industry for Company 2
                new CompanyIndustry
                {
                CompanyID = 1,
                IndustryID = 0
                },

                //Industry for Company 2
                new CompanyIndustry
                {
                    CompanyID = 1,
                    IndustryID = 1
                },

                 //Industry for Company 2
                new CompanyIndustry
                {
                    CompanyID = 1,
                    IndustryID = 3
                },
                  //Industry for Company 2
                new CompanyIndustry
                {
                    CompanyID = 1,
                    IndustryID = 4
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

                     ReviewPosts = _reviewPosts.Where(rp => rp.CompanyID == 1).ToArray(),
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

                     ReviewPosts = _reviewPosts.Where(rp => rp.CompanyID == 3).ToArray(),
                     LeadProducts = _leadProducts.Where(lp => lp.CompanyID == 3).ToArray()
                 }
            };

            
        
            //Setup Mock LeadProduct Repository
            _leadProductRepositoryMock.Setup(lp => lp.GetAll()).Returns(_leadProducts.AsQueryable());
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(0)).Returns(_leadProducts[0]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(1)).Returns(_leadProducts[1]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(2)).Returns(_leadProducts[2]);
            _leadProductRepositoryMock.Setup(lp => lp.GetByID(3)).Returns(_leadProducts[3]);

            //Setup Mock ReviewPost Repository
            _reviewPostRepositoryMock.Setup(rp => rp.GetAll()).Returns(_reviewPosts.AsQueryable());
            _reviewPostRepositoryMock.Setup(rp => rp.GetByID(0)).Returns(_reviewPosts[0]);
            _reviewPostRepositoryMock.Setup(rp => rp.GetByID(1)).Returns(_reviewPosts[1]);
            _reviewPostRepositoryMock.Setup(rp => rp.GetByID(2)).Returns(_reviewPosts[2]);
            _reviewPostRepositoryMock.Setup(rp => rp.GetByID(3)).Returns(_reviewPosts[3]);
            _reviewPostRepositoryMock.Setup(rp => rp.GetByID(4)).Returns(_reviewPosts[4]);
            _reviewPostRepositoryMock.Setup(rp => rp.GetByID(5)).Returns(_reviewPosts[5]);


            //Setup Mock Industry Repository
            _industryRepositoryMock.Setup(ir => ir.GetAll()).Returns(_industries.AsQueryable());
            _industryRepositoryMock.Setup(ir => ir.GetByID(0)).Returns(_industries[0]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(1)).Returns(_industries[1]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(2)).Returns(_industries[2]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(3)).Returns(_industries[3]);
            _industryRepositoryMock.Setup(ir => ir.GetByID(4)).Returns(_industries[4]);



            //Setup Mock Company Repository
            _companyRepositoryMock.Setup(cr => cr.GetAll()).Returns(_companies.AsQueryable());
            _companyRepositoryMock.Setup(cr => cr.GetByID(1)).Returns(_companies[0]);
            _companyRepositoryMock.Setup(cr => cr.GetByID(3)).Returns(_companies[1]);

            // Set up unit of work and controller
            _unitOfWorkMock = new Mock<IUnitOfWork>();
          //  _companyRepositoryMock = new Mock<IBlogService>();


            _controller = new CompaniesController( _companyRepositoryMock.Object, _companyIndustryRepositoryMock.Object,
                                                _unitOfWorkMock.Object);

        }

     


        [TestMethod] // [0]
        public void GetCompaniesReturnCompanies()
        {
            //Arrange

            //Act
            var companies = _controller.GetCompanies();

            //Assert
            // Verify GetCompanies() is called (1) time.  Verify Correct number is returned


           _companyRepositoryMock.Verify(c => c.Where(It.IsAny<Expression<Func<Company, bool>>>()), Times.Once);
            Assert.AreEqual(companies.Count(), _numberOfMockCompanies); 
        }



        [TestMethod] //[1]
        public void GetCompanyReturnsSameID()
        {
            //Arrange

            //Act: Grab first company
            IHttpActionResult actionResult = _controller.GetCompany(1);


            // Assert
            // Verify that GetByID is called just once
            // Verify that HTTP status code is Ok, with object of correct type
            _companyRepositoryMock.Verify(p => p.GetByID(1), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<CompanyModel>));


            // Extract the content from the HTTP result
            // Verify the content is not null, and the IDs match
            var contentResult = actionResult as OkNegotiatedContentResult<CompanyModel>;
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.CompanyID, 1);
        }

        [TestMethod]  // [5]
        public void GetCompaniesByIndustryReturnsCompanies()
        {
            //Arrange
            _companyRepositoryMock.Setup(r => r.Where(It.IsAny < Expression < Func<Company, bool>>>()))
                                  .Returns(_companies.Where(r => r.Industries.Any(i => i.IndustryID == 1)).AsQueryable());

            //Act : Grab Companies
            var companiesQuery = _controller.GetCompaniesByIndustry(1);

            //Assert
            _companyRepositoryMock.Verify(ci => ci.Where(It.IsAny<Expression<Func<Company, bool>>>()), Times.Once);
            Assert.AreEqual(companiesQuery.Count(), 2);
        }


        [TestMethod] // [Action]
        public void GetNonExistentCompaniesReturnsNotFOund()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult = _controller.GetCompany(-99999999);

            //Assert
            _companyRepositoryMock.Verify(Cr => Cr.GetByID(-99999999), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]  //[2]
        public void PutCompanyReturnCompany()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutCompany(
                    1,
                    new CompanyModel
                    {
                        CompanyID = 1,
                        UserID = 0,
                        IsArchived = false
                    });
            var statusCodeResult = actionResult as StatusCodeResult;
            //Assert
            _companyRepositoryMock.Verify(cr => cr.GetByID(1), Times.Once);
            _companyRepositoryMock.Verify(cr => cr.Update(It.IsAny<Company>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(statusCodeResult.StatusCode, HttpStatusCode.NoContent);

        }

        [TestMethod] // [3]
        public void PostCompanyReturnPost()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PostCompany(
                    new CompanyModel
                    {
                        CompanyID = 2,
                        UserID = 2,
                        IsArchived = false
                    });
            var statusCodeResult = actionResult as StatusCodeResult;

            //Assert
            _companyRepositoryMock.Verify(c => c.Add(It.IsAny<Company>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.AtLeastOnce);
            Assert.IsInstanceOfType
                (actionResult, typeof(CreatedAtRouteNegotiatedContentResult<CompanyModel>));
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<CompanyModel>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(createdResult.RouteName, "DefaultApi");
        }

        [TestMethod] // [4]
        public void DeleteCompanyReturnsOk()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult = _controller.DeleteCompany(1);

            //Assert
            _companyRepositoryMock.Verify(c => c.GetByID(1), Times.Once);
            _companyRepositoryMock.Verify(c => c.Update(It.IsAny<Company>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<CompanyModel>));
            var contentResult = actionResult as OkNegotiatedContentResult<CompanyModel>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.CompanyID == 1);


        }


    }
}
