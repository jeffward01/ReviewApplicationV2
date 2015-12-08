using AutoMapper.QueryableExtensions;
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

namespace ReviewApplication.API.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Comment
        public IQueryable<CommentModel> Get()
        {
            return _commentRepository.GetAll().ProjectTo<CommentModel>();
        }

        // GET: api/Comment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comment
        public void Post([FromBody]string value)
        {
            _commentRepository.Add(new Core.Domain.Comment());

            _unitOfWork.Commit();
        }

        // PUT: api/Comment/5
        public void Put(int id, [FromBody]string value)
        {
            


        }

        // DELETE: api/Comment/5
        public void Delete(int id)
        {
        }
    }
}
