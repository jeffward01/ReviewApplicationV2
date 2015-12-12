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

        //PUT: api/ReviewPosts || [5]
        [ResponseType(typeof(ReviewPostModel))]
        public IHttpActionResult PutReviewPost(int id, ReviewPostModel reviewPost)
        {
            //validate the Request
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Get the DbReviewPost
            var dbReviewPost = _reviewPostRepository.GetByID(id);
            if(dbReviewPost == null)
                {
                return NotFound();
            }

            //Update the dbReviewPost According to the input ReviewPostModel Object
            // and update the reviewPost in the database
            dbReviewPost.Update(reviewPost);
            _reviewPostRepository.Update(dbReviewPost);

            //Save the changes in the Database
            try
            {
                _unitOfWork.Commit();
            }
            catch(DBConcurrencyException e)
            {

                if (!ReviewPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update ReviewProduct in the Database");
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete: api/ReviewPosts || [6]
        [ResponseType(typeof(ReviewPostModel))]
        public IHttpActionResult DeleteReviewPost(int id)
        {
            //Get the dbLeadProduct corresponding to the insuranceAgentID
            ReviewPost dbReviewPost = _reviewPostRepository.GetByID(id);
            if (dbReviewPost == null)
            {
                return NotFound();
            }

            //Delete the LeadProduct
            try
            {
                //set to archived
                dbReviewPost.IsArchived = true;

                //Update the leadProduct 
                _reviewPostRepository.Update(dbReviewPost);

                //save the changes
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new Exception("Unable to archive the ReviewPost to the Database");
            }
            return Ok(Mapper.Map<ReviewPostModel>(dbReviewPost));
        }


        public bool ReviewPostExists(int id)
        {
            return _reviewPostRepository.Count(rp => rp.ReviewPostID == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }
}
