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
    public class CommentsControllerTests
    {
        private Mock<ICommentRepository> _commentRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        private CommentsController _controller;
        private Comment[] _comments;
        private ReviewPost[] _reviewPosts;
        private InsuranceAgent[] _insuranceAgents;
        private Company[] _companies;

        [TestInitialize]
        public void Initialize()
        {
            //Setup Automapper
            WebApiConfig.SetupAutomapper();

            //Setup repositories
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();


            //Set Data in Repositories


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
                    InsuranceAgentID = 2,
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
                    InsuranceAgentID = 1,
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
                    InsuranceAgentID = 2,
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

            

            _comments = new[]
            {
                new Comment
                {
                    CommentID = 0,
                    InsuranceAgentProfileID = 1,
                    CompanyID =1,
                    ReviewID = 1
                
                },
                 new Comment
                {
                    CommentID = 1,
                    ParentCommentID=0,
                    InsuranceAgentProfileID = 1,
                   
                    ReviewID = 1

                },
                 new Comment
                 {
                     CommentID =2,
                     InsuranceAgentProfileID =2,
                     ReviewID=2
                 },
                    new Comment
                 {
                     CommentID =3,
                     InsuranceAgentProfileID =2,
                     ReviewID=2
                 }
            };



            //Setup Mock Comment Repository
            _commentRepositoryMock.Setup(crm => crm.GetAll()).Returns(_comments.AsQueryable());
            _commentRepositoryMock.Setup(c => c.GetByID(1)).Returns(_comments[1]);
            _commentRepositoryMock.Setup(c => c.GetByID(2)).Returns(_comments[2]);
            _commentRepositoryMock.Setup(c => c.GetByID(3)).Returns(_comments[3]);



               // Setup Controller
            _controller = new CommentsController(_commentRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        

        [TestMethod] // [0]
        public void GetAllCommentsReturnComments()
        {
            //Arrange

            //act
            var comments = _controller.GetComments();

            //assert
            _commentRepositoryMock.Verify(c => c.GetAll(), Times.Once);
            Assert.AreEqual(comments, 4);

        }

        [TestMethod] // [1]
        public void GetCommentByIdReturnComment()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult = _controller.GetComment(1);

            //Assert
            _commentRepositoryMock.Verify(c => c.GetByID(1), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<CommentModel>));
        }

        //TODO: Check methods: 5,6,7,8

        [TestMethod] // [5]
        public void GetAllCommentsForInsuranceAgentReturnComments()
        {
            //Arrange
            _commentRepositoryMock.Setup(lp => lp.Where(It.IsAny<Expression<Func<Comment, bool>>>()))
                        .Returns(_comments.Where(c => c.InsuranceAgentProfileID.Equals(1)).AsQueryable());

            //Act
            var commentQuery = _controller.GetAllCommentForInsuranceAgent(1);

            //Assert
            //TODO: Refer to this for verifying that Where is called instead of GetAll
            _commentRepositoryMock.Verify(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()), Times.Once);
            Assert.AreEqual(commentQuery.Count(), 2);
            
        }


        [TestMethod] // [6]
        public void GetAllCommentsForCompanyReturnComments()
        {
            //arrnage
            _commentRepositoryMock.Setup(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()))
                            .Returns(_comments.Where(c => c.CompanyID.Equals(1)).AsQueryable());

            //act
            var commentQuery = _controller.GetAllCommentsForCompany(1);

            //assert
            _commentRepositoryMock.Verify(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()), Times.Once);
            Assert.AreEqual(commentQuery, 1);
        }


        [TestMethod]
        public void GetAllCommentsForReviewPost()
        {
            //arrange
            _commentRepositoryMock.Setup(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()))
                        .Returns(_comments.Where(c => c.ReviewID.Equals(1)).AsQueryable());

            //Act
            var commentQuery = _controller.GetAllCommentsForReviewPost(1);

            //assert
            _commentRepositoryMock.Verify(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()), Times.Once);
            Assert.AreEqual(commentQuery, 2);
        }

        [TestMethod] // [8]
        public void GetAllCommentsForParentComment()
        {
            //Arrange
            _commentRepositoryMock.Setup(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()))
                .Returns(_comments.Where(c => c.ParentCommentID.Equals(0)).AsQueryable());

            //Act
            var commentQuery = _controller.GetAllCommentsForParentComment(0);

            //Assert
            _commentRepositoryMock.Verify(c => c.Where(It.IsAny<Expression<Func<Comment, bool>>>()), Times.Once);
            Assert.AreEqual(commentQuery, 1);
        }

        [TestMethod] // [2]
        public void PutCommentReturnComment()
        {
            //Arrange

            //Act
            IHttpActionResult actionResult =
                _controller.PutComment(
                    0,
                    new CommentModel
                    {
                        CommentID = 0,
                        PostBody = "abc"
                    });
            var statusCodeResult = actionResult as StatusCodeResult;

            //Assert
            _commentRepositoryMock.Verify(c => c.GetByID(0), Times.Once);
            _commentRepositoryMock.Verify(c => c.Update(It.IsAny<Comment>()), Times.Once);

            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            
        }


        [TestMethod] //[3]
        public void PostCommentReturnComment()
        {
            //arrange

            //act
            IHttpActionResult actionResult =
                _controller.PostComment(
                    new CommentModel
                    {
                        CommentID = 10,
                        CompanyID = 1,
                        ReviewID = 2,
                        PostBody = "xyz",
                    });

            //assert
            _commentRepositoryMock.Verify(lp => lp.Add(It.IsAny<Comment>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType
                (actionResult, typeof(CreatedAtRouteNegotiatedContentResult<CommentModel>));
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<CommentModel>;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(createdResult.RouteName, "DefaultApi");


        }


        [TestMethod] // [4]
        public void DeleteCommentReturnComment()
        {
            //arrange

            //act
            IHttpActionResult actionResult = _controller.DeleteComment(1);

            //Assert
            _commentRepositoryMock.Verify(lp => lp.GetByID(1), Times.Once);
            _commentRepositoryMock.Verify(lp => lp.Update(It.IsAny<Comment>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.Commit(), Times.Once);
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<CommentModel>));
            var contentResult = actionResult as OkNegotiatedContentResult<CommentModel>;
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.IsTrue(contentResult.Content.CommentID == 1);
        }
        
    }
}
