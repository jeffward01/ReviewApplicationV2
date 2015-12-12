using AutoMapper;
using AutoMapper.QueryableExtensions;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Models;
using ReviewApplication.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace ReviewApplication.API.Controllers
{
    public class ReviewPostsController : ApiController
    {
        private readonly IReviewPostRepository _reviewPostRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Constructor
        public ReviewPostsController(IReviewPostRepository reviewPostRepository, IUnitOfWork UnitOfWork)
        {
            _reviewPostRepository = reviewPostRepository;
            _unitOfWork = UnitOfWork;
        }

        //GET: api/ReviewPost || [0]
        [EnableQuery]
        public IQueryable<ReviewPostModel> GetReviewPosts()
        {
            return _reviewPostRepository.Where(lp => lp.IsArchived == false).ProjectTo<ReviewPostModel>();
        }

        //GET: api/ReviewPost || [1]
        [ResponseType(typeof(ReviewPostModel))]
        public IHttpActionResult GetReviewPost(int id)
        {
            ReviewPost dbReviewPost = _reviewPostRepository.GetByID(id);

            if(dbReviewPost != null && !dbReviewPost.IsArchived)
            {
                return Ok(Mapper.Map<ReviewPostModel>(dbReviewPost));
            }
            else
            {
                return NotFound();
            }
        }

        //GET Api/ReviewPost || [2]
        [EnableQuery]
        public IQueryable<ReviewPostModel> GetAllReviewPostsForCompany(int companyID)
        {
            return _reviewPostRepository.Where(rp => rp.IsArchived == false && rp.CompanyID == companyID).ProjectTo<ReviewPostModel>();
        }


       //GET Api/ReviewPost || [3]
        [EnableQuery]
        public IQueryable<ReviewPostModel> GetAllReviewPostsForInsuranceAgent(int insuranceAgentID)
        {
            return _reviewPostRepository.Where(rp => rp.IsArchived == false && rp.InsuranceAgentID == insuranceAgentID).ProjectTo<ReviewPostModel>();
        }

        //GET Api/ReviewPost || [4]
        [EnableQuery]
        public IQueryable<ReviewPostModel> GetAllReviewPostsForLeadProduct(int leadProductID)
        {
            return _reviewPostRepository.Where(rp => rp.IsArchived == false && rp.LeadProductID == leadProductID).ProjectTo<ReviewPostModel>();
        }


    }
}
