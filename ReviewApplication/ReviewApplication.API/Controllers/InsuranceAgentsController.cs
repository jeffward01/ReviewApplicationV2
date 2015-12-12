using AutoMapper;
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

       
        //PUT: api/InsuranceAgents
        //TODO: working on building insurance agents controller
    }
}
