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
    public class LeadProductsController : ApiController
    {
        private readonly ILeadProductRepository _leadProductRepository;
        private readonly IUnitOfWork _unitOfWork;


        //Constructor
        public LeadProductsController(ILeadProductRepository leadProductRepository, IUnitOfWork unitOfWork)
        {
            _leadProductRepository = leadProductRepository;
            _unitOfWork = unitOfWork;
        }

        //GET: Api/LeadProduct || [0]
        [EnableQuery]
        public IQueryable<LeadProductModel> GetLeadProducts()
        {
            return _leadProductRepository.Where(lp => lp.IsArchived == false).ProjectTo<LeadProductModel>();
        }

        //GET : api/LeadProduct || [1]
        [ResponseType(typeof(LeadProductModel)]
        public IHttpActionResult GetLeadProduct(int id)
        {
            LeadProduct dbLeadProduct = _leadProductRepository.GetByID(id);

            if(dbLeadProduct != null && !dbLeadProduct.IsArchived)
            {
                return Ok(Mapper.Map<LeadProductModel>(dbLeadProduct));
            }
            else
            {
                return NotFound();
            }
        }


        //GET: api/LeadProduct || [2]
        [EnableQuery]
        public IQueryable<LeadProductModel> GetAllLeadProductsFromComapny(int companyID)
        {
            return _leadProductRepository.Where(lp => lp.IsArchived == false && lp.CompanyID == companyID).ProjectTo<LeadProductModel>();
        }

        //PUT: api/LeadProducts || [3]
        public IHttpActionResult PutLeadProduct(int id, LeadProductModel leadProduct)
        {
            //Validate the Request
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Get the DbLeadProduct
            var dbLeadProduct = _leadProductRepository.GetByID(id);
            if(dbLeadProduct == null)
            {
                return NotFound();
            }

            //Update the DbLeadProduct ACcodfint to the Input LeadProductMOdel Object
            // and update the leadProduct in the database
            dbLeadProduct.Update(leadProduct);
            _leadProductRepository.Update(dbLeadProduct);

            //Save the changes in the Database
            try
            {
                _unitOfWork.Commit();
            }
            catch(DBConcurrencyException e)
            {
                if(!LeadProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update the leadproduct in the database");
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete: api/LeadProducts || [4]
        public IHttpActionResult DeleteLeadProduct(int id)
        {
            //Get the dbLeadProduct corresponding to the insuranceAgentID
            LeadProduct dbLeadProduct = _leadProductRepository.GetByID(id);
            if(dbLeadProduct == null)
            {
                return NotFound();
            }

            //Delete the LeadProduct
            try
            {
                //set to archived
                dbLeadProduct.IsArchived = true;

                //Update the leadProduct 
                _leadProductRepository.Update(dbLeadProduct);

                //save the changes
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to archive the LeadProduct to the Database");
            }
            return Ok(Mapper.Map<LeadProductModel>(dbLeadProduct));
        }




        private bool LeadProductExists(int id)
        {
            return _leadProductRepository.Count(lp => lp.LeadProductID == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
