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
            return _insuranceAgentRepository.Where(ia => !ia.IsArchived).ProjectTo<InsuranceAgentModel>();
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

       
        //GET: api/Companies/5 || [2]
        [EnableQuery]
        public IQueryable<InsuranceAgentModel> GetAllInsuranceAgentsByIndustry(int industryID)
        {
            //Grab all insurance agents with matching industry ID
            var insuranceAgents = _insuranceAgentRepository.Where(ia => !ia.IsArchived && ia.Industries.Any(i => i.IndustryID == industryID));

            return insuranceAgents.ProjectTo<InsuranceAgentModel>();

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

        //POST: api/InsurnaceAgents || [4]
        [ResponseType(typeof(InsuranceAgentModel))]
        public IHttpActionResult PostInsurnaceAgent(InsuranceAgentModel insuranceAgent)
        {
            //Check the Model state
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //make the DB Insurnace Agent
            var dbInsuranceAgent = new InsuranceAgent();

            dbInsuranceAgent.Update(insuranceAgent);

            //add the new Insurnace Agent Object populated from the input
            _insuranceAgentRepository.Add(dbInsuranceAgent);

            //Save the changes in the Database
            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to add Insurance Agent to the Database");

            }

            //Return the created Insurnace agent Record
            return CreatedAtRoute("DefaultApi", new { id = insuranceAgent.InsuranceAgentID }, insuranceAgent);
        }




        //Delete: api/InsuranceAgents || [5]
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
