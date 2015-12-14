using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReviewApplication.Core.Domain;
using ReviewApplication.API.Controllers;
using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Repository;
using System.Linq;
using System.Collections.ObjectModel;

namespace ReviewApplication.API.Test.ReviewApplication
{
    [TestClass]
    public class CompaniesControllerTests
    {
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private Mock<IReviewPostRepository> _reviewPostRepositoryMock;
        private Mock<ILeadProductRepository> _leadProductRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWork;
        private CompaniesController _controller;
        private Company[] _companies;
        private ReviewPost[] _reviewPosts;
        private LeadProduct[] _leadProducts;


        [TestInitialize]
        public void Initialize()
        {
            //Setup Automapper
            WebApiConfig.SetupAutomapper();

            //Set up Repositories
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _reviewPostRepositoryMock = new Mock<IReviewPostRepository>();
            _leadProductRepositoryMock = new Mock<ILeadProductRepository>();


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

            _companies = new[]
            {
                //Test Company 1
                new Company
                {
                     CompanyID = 1,
                     UserID = 1,
                     IsArchived = false,
                     IndustryID = 1,
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
                     IndustryID = 1,
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
                     VenmoHandle = "ALlStarLeads",

                     ReviewPosts = _reviewPosts.Where(rp => rp.CompanyID == 3).ToArray(),
                     LeadProducts = _leadProducts.Where(lp => lp.CompanyID == 3).ToArray()
                 }
            };

            //Mock Controller Methods
            _companyRepositoryMock.Setup(cr => cr.GetAll()).Returns(_companies.AsQueryable());
            _companyRepositoryMock.Setup(cr => cr.GetByID(1)).Returns(_companies[0]);
        }
    }
}
