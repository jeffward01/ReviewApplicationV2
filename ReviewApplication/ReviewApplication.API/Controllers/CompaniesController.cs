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
    public class CompaniesController : ApiController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Constructor
        public CompaniesController(ICompanyRepository companyProfileRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyProfileRepository;
            _unitOfWork = unitOfWork;
        }


        // GET: api/Companies || [0]
        [EnableQuery] 
        public IQueryable<CompanyModel> GetCompanies()
        {
            return _companyRepository.GetAll().ProjectTo<CompanyModel>();
        }

        // GET: api/Companies/5 || [1]
        [ResponseType(typeof(CompanyModel))]
        public IHttpActionResult GetCompany(int id)
        {
            Company dbCompany = _companyRepository.GetByID(id);
            if(dbCompany == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<CompanyModel>(dbCompany));
        }

        // PUT: api/Companies || [2] 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, CompanyModel company)
        {
            //Validate the request
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != company.CompanyID)
            {
                return BadRequest();
            }

            //Get the DB Company 
            var dbCompany = _companyRepository.GetByID(id);
            if(dbCompany == null)
            {
                return NotFound();
            }

            //Update the DBCompany according to the input CompanyModel Object,
            // and the update the comment in the DB
            dbCompany.Update(company);
            _companyRepository.Update(dbCompany);

            //Save the Database Changes
            try
            {
                _unitOfWork.Commit();
            }
            catch(DBConcurrencyException e)
            {
                if(!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update the comment in the database", e);
                }
                
            }
            return StatusCode(HttpStatusCode.NoContent);

        }



        // POST: api/Companies/5 || [3] 
        [ResponseType(typeof(CompanyModel]
        public IHttpActionResult PostCompany(CompanyModel company)
        {
            //Check Model State
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbCompany = new Company();

            //add the new Company Object poulated from the input Company
            _companyRepository.Add(dbCompany);

            //Save the changes to the Database
            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to add company to the database");
            }

            //Return the created comment record
            return CreatedAtRoute("DefaultApi", new { id = company.CompanyID }, company);
        }

        // DELETE: api/Companies/5 || [4]
        public void Delete(int id)
        {
        }




        //-------------------------------------------------------------
        //Helper Methods


        //Does company Exist
        private bool CompanyExists(int id)
        {
            return _companyRepository.Count(c => c.CompanyID == id) > 0;
        }

        //deletes related objects 
        //TODO: Write delete cascade
        private void DeleteCompany(int companyID)
    }
}
