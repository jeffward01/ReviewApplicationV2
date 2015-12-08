using AutoMapper.QueryableExtensions;
using AutoMapper;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Models;
using ReviewApplication.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

using System.Web.Http.Description;
using System.Web.Http.OData;

namespace ReviewApplication.API.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;
        

        //Constructor
        public CommentController(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Comment
        [EnableQuery]
        public IQueryable<CommentModel> Get()
        {
            return _commentRepository.GetAll().ProjectTo<CommentModel>();
        }

        // GET: api/Comment/5
        [ResponseType(typeof(CommentModel))]
        public IHttpActionResult GetComment(int id)
        {
            Comment dbComment = _commentRepository.GetByID(id);
            if(dbComment == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<CommentModel>(dbComment));
        }


        // PUT: api/Comment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, CommentModel comment)
        {
            //Validate the request
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != comment.CommentID)
            {
                return BadRequest();
            }

            //Get the DB Comment  
            var dbComment = _commentRepository.GetByID(id);
            if(dbComment == null)
            {
                return NotFound();
            }

            //Update the Db Comment according to the input CommentModel object,
            // and the update the comment in the DB
            dbComment.Update(comment);
            _commentRepository.Update(dbComment);

            //Save Database Changes
            try
            {
                _unitOfWork.Commit();
            }
            catch( DBConcurrencyException e)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update the comment in the database",e);
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Comment
        [ResponseType(typeof(CommentModel))]
        public IHttpActionResult PostCOmment(CommentModel comment)
        {
          //Check ModelState
          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbComment = new Comment();

            dbComment.Update(comment);

            //add the new COmment object populated from input comment
            _commentRepository.Add(dbComment);

            //save the changes to the database
            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to add comment to the database",e);
           
            }

            //Return the created comment record
            return CreatedAtRoute("DefaultApi", new { id = comment.CommentID }, comment);
        }

     
       
        // DELETE: api/Comment/5
        [ResponseType(typeof(CommentModel))]
        public IHttpActionResult DeleteComment(int id)
        {
            //Get the db COmment correspond to the comment ID
            Comment dbComment = _commentRepository.GetByID(id);
            if(dbComment == null)
            {
                return NotFound();
            }
            
            //Delete Post
            try
            {
                DeleteComments(id);

                //Remove the comment
                _commentRepository.Delete(dbComment);

                //Save Changes
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to delete the comment from the database", e);
            }

            return Ok(Mapper.Map<CommentModel>(dbComment));
        }








        //--------------------------------------------
        //Helper Methods

        //Dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // Checks to see if Comment Exists
        private bool CommentExists(int id)
        {
            return _commentRepository.Count(c => c.CommentID == id) > 0;
        }

        //Remove Comments corresponding to comment
        private void DeleteComments (int commentID)
        {
            var dbComments = _commentRepository.Where(c => c.CommentID == commentID);

            if(dbComments.Count() > 0)
            {
                foreach (var dbComment in dbComments)
                {
                    _commentRepository.Delete(dbComment);
                }
            }
        }
    }
}
