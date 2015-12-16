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
    public class IndustriesController : ApiController
    {
        private readonly IIndustryRepository _industryRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Constructor
        public IndustriesController(IIndustryRepository industryRepository, IUnitOfWork unitOfWork)
        {
            _industryRepository = industryRepository;
            _unitOfWork = unitOfWork;
        }

        //GET: api/Industry || [0]
        [EnableQuery]
        public IQueryable<IndustryModel> GetIndustries()
        {
            return _industryRepository.Where(i => i.IsArchived == false).ProjectTo<IndustryModel>();
        }

        //GET: api/Industry || [1]
        [ResponseType(typeof(IndustryModel))]
        public  IHttpActionResult GetIndustry(int id)
        {
            Industry dbIndustry = _industryRepository.GetByID(id);

            if(dbIndustry != null && !dbIndustry.IsArchived)
            {
                return Ok(Mapper.Map<IndustryModel>(dbIndustry));
            }
            else
            {
                return NotFound();
            }
        }

        //PUT: api/Industry/5 || [2]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndustry(int id, IndustryModel industry)
        {
            //Validate the Request
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != industry.Id)
            {
                return BadRequest();
            }

            //Get the DB Industry
            var dbIndustry = _industryRepository.GetByID(id);
            if(dbIndustry == null)
            {
                return NotFound();
            }

            //Update the Db Industry according to the input Industry Model Object
            // and update the industry in the database
            dbIndustry.Update(industry);
            _industryRepository.Update(dbIndustry);

            //Save the Database Changes
            try
            {
                _unitOfWork.Commit();
            }
            catch(DBConcurrencyException e)
            {
                if(!IndustryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update the industry in the database");
                }
            }

            return StatusCode(HttpStatusCode.NoContent);

        }

        //POST: api/Industry || [3]
        [ResponseType(typeof(IndustryModel))]
        public IHttpActionResult PostIndustry(IndustryModel industry)
        {
            //Check ModelState
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //make DB industry
            var dbIndustry = new Industry();

            dbIndustry.Update(industry);

            //add the new Industry object populated from the input 
            _industryRepository.Add(dbIndustry);

            //Save the changes in the Database
            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to add Industry to the database");
            }

            //Return the created Insustry record
            return CreatedAtRoute("DefaultApi", new { id = industry.Id }, industry);
        }


        //Delete: Api /industry/5 || [4]
        [ResponseType(typeof(IndustryModel))]
        public IHttpActionResult DeleteIndustry(int id)
        {
            //Get the db Industry corresponding to the industry ID
            Industry dbIndustry = _industryRepository.GetByID(id);
            if(dbIndustry == null)
            {
                return NotFound();
            }

            //Delete Industry
            try
            {
                //Set to archived
                dbIndustry.IsArchived = true;

                //Udpate the industry
                _industryRepository.Update(dbIndustry);

                //Save the changes
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to archive the Industry to the database");
            }

            return Ok(Mapper.Map<IndustryModel>(dbIndustry));
        }


        private bool IndustryExists(int id)
        {
            return _industryRepository.Count(i => i.Id == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
