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
    public class LeadTransactionsController : ApiController
    {
        private readonly ILeadTransactionRepository _leadTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Contstructor
        public LeadTransactionsController(ILeadTransactionRepository leadTransactionRepository, IUnitOfWork unitOfWork)
        {
            _leadTransactionRepository = leadTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        //GET api/LeadTransaction || [0]
        [EnableQuery]
        public IQueryable<LeadTransactionModel> GetAllLeadTranasactions()
        {
            return _leadTransactionRepository.Where(lt => !lt.IsArchived).ProjectTo<LeadTransactionModel>();
        }


        //GET api/LeadTransaction || [1]
        [ResponseType(typeof(LeadTransactionModel))]
        public IHttpActionResult GetLeadTransactionByID(int id)
        {
            LeadTransaction dbLeadTransaction = _leadTransactionRepository.GetByID(id);

            if(dbLeadTransaction != null && !dbLeadTransaction.IsArchived)
            {
                return Ok(Mapper.Map<LeadTransactionModel>(dbLeadTransaction));
            }
            else
            {
                return NotFound();
            }
        }

        //GET api/LeadTransaction || [2]
        [EnableQuery]
        public IQueryable<LeadTransactionModel> GetLeadTransactionsforCompany(int companyID)
        {
            return _leadTransactionRepository.Where(lt => !lt.IsArchived && lt.CompanyID == companyID).ProjectTo<LeadTransactionModel>();
        }

        //GET api/LeadTransaction || [3]
        [EnableQuery]
        public IQueryable<LeadTransactionModel> GetLeadTransactionforInsuranceAgent(int insuranceAgentID)
        {
            return _leadTransactionRepository.Where(lt => !lt.IsArchived && lt.InsuranceAgentProfileID == insuranceAgentID).ProjectTo<LeadTransactionModel>();
        }

        //GET api/LeadTransaction || [4]
        [EnableQuery]
        public IQueryable<LeadTransactionModel> GetLeadTransactionsForLeadProduct(int leadProductID)
        {
            return _leadTransactionRepository.Where(lt => !lt.IsArchived && lt.LeadProductID == leadProductID).ProjectTo<LeadTransactionModel>();
        }


        //Put api/LeadTransaction || [5]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeadTransaction(int id, LeadTransactionModel leadTransaction)
        {
            //Validate the request
            if(!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            //Get the DB LeadTransaction
            var dbLeadTranscation = _leadTransactionRepository.GetByID(id);
            if(dbLeadTranscation == null)
            {
                return NotFound();
            }

            //Updatede the DB insurance agent according to the input LeadTransactionModel Object
            // and update the industry in the database
            dbLeadTranscation.Update(leadTransaction);
            _leadTransactionRepository.Update(dbLeadTranscation);

            //Save the Database Changes
            try
            {
                _unitOfWork.Commit();
            }
            catch(DBConcurrencyException e)
            {
                if (!LeadTransactionExists(id))
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

        //Delete: api/LeadTransactions || [4]
        [ResponseType(typeof(LeadTransactionModel))]
        public IHttpActionResult DeleteLeadTransaction(int id)
        {
            //Get the dbLeadTransaction corresponding to the LeadTransactionID
            LeadTransaction dbLeadTransaction = _leadTransactionRepository.GetByID(id);
            if (dbLeadTransaction == null)
            {
                return NotFound();
            }

            //Delete the LeadTransaction
            try
            {
                //Set to archived
                dbLeadTransaction.IsArchived = true;

                //Update the LeadTransaction
                _leadTransactionRepository.Update(dbLeadTransaction);

                //save the changes
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new Exception("Unable to archive the InsuranceAgent to the Database");
            }
            return Ok(Mapper.Map<LeadTransactionModel>(dbLeadTransaction));
        }

        private bool LeadTransactionExists(int id)
        {
            return _leadTransactionRepository.Count(ia => ia.LeadTransactionID == id) > 0;
        }
    }
}
