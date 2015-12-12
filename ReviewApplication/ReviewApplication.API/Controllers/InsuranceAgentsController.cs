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
    public class InsuranceAgentsController : ApiController
    {
        private readonly IInsuranceAgentRepository _insuranceAgentRepository;
        private readonly IUnitOfWork _unitOfWork;


        //Constructor
        public InsuranceAgentsController(IInsuranceAgentRepository insuranceAgentRepository, IUnitOfWork unitOfWork)
        {
            _insuranceAgentRepository = insuranceAgentRepository;
            _unitOfWork = unitOfWork;
        }

        //GET: Api/InsuranceAgent || [0]
        [EnableQuery]
        public IQueryable<InsuranceAgentModel> GetInsuranceAgents()
        {
            return _insuranceAgentRepository.Where(ia => ia.IsArchived == false).ProjectTo<InsuranceAgentModel>();
        }

        //GET: Api/InsurnaceAgent || [1]
        [ResponseType(typeof(IndustryModel))]
        public IHttpActionResult GetInsuranceAgent(int id)
        {
            InsuranceAgent dbInsuranceAgent = _insuranceAgentRepository.GetByID(id);

            if(dbInsuranceAgent != null && !dbInsuranceAgent.IsArchived)
            {
                return Ok(Mapper.Map<InsuranceAgentModel>(dbInsuranceAgent));
            }
            else
            {
                return NotFound();
            }
        }

        //GET: API/InsuranceAgent || [2]
        [EnableQuery]
        public IQueryable<InsuranceAgentModel> GetAllInsuranceAgentsByIndustry(int industryID)
        {
            //Grab all insurance agents with matching industry ID
            return _insuranceAgentRepository.Where(ia => ia.IsArchived == false && ia.IndustryID == industryID).ProjectTo<InsuranceAgentModel>();    
        }

       
        //PUT: api/InsuranceAgents  || [3]
        [ResponseType(typeof(void))]  
        public IHttpActionResult PutInsuranceAgent(int id, InsuranceAgentModel insuranceAgent)
        {
            //Validate the request
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Get the DB Industry
            var dbIndustry = _insuranceAgentRepository.GetByID(id);
            if(dbIndustry == null)
            {
                return NotFound();
            }

            //Update the DBInsuranceagent According to the input InsuranceAgentModel Object
            // and update the industry in the database
            dbIndustry.Update(insuranceAgent);
            _insuranceAgentRepository.Update(dbIndustry);

            //Save the Database Changes
            try
            {
                _unitOfWork.Commit();
            }
            catch(DBConcurrencyException e)
            {
                if(!InsuranceAgentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable tp update the industry in the database");
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete: api/InsuranceAgents || [4]
        [ResponseType(typeof(InsuranceAgentModel))]
        public IHttpActionResult DeleteInsuranceAgent(int id)
        {
            //Get the dbInsurance Agent corresponding to the InsuranceAgentID
            InsuranceAgent dbInsuranceAgent = _insuranceAgentRepository.GetByID(id);
            if(dbInsuranceAgent == null)
            {
                return NotFound();
            }

            //Delete the Insurance Agent
            try
            {
                //Set to archived
                dbInsuranceAgent.IsArchived = true;

                //Update the InsuranceAgent
                _insuranceAgentRepository.Update(dbInsuranceAgent);

                //save the changes
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to archive the InsuranceAgent to the Database");
            }
            return Ok(Mapper.Map<InsuranceAgentModel>(dbInsuranceAgent));
        }


        private bool InsuranceAgentExists(int id)
        {
            return _insuranceAgentRepository.Count(ia => ia.InsuranceAgentID == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
