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
        private readonly ICompanyIndustryRepository _companyIndustryRepository;

        //Constructor
        public CompaniesController(ICompanyRepository companyProfileRepository, ICompanyIndustryRepository companyIndustryRepository,IUnitOfWork unitOfWork)
        {
            _companyRepository = companyProfileRepository;
            _unitOfWork = unitOfWork;
            _companyIndustryRepository = companyIndustryRepository;
        }


        // GET: api/Companies || [0]
        [EnableQuery] 
        public IQueryable<CompanyModel> GetCompanies()
        {
            return _companyRepository.Where(c => !c.IsArchived).ProjectTo<CompanyModel>();
        }

        // GET: api/Companies/5 || [1]
        [ResponseType(typeof(CompanyModel))]
        public IHttpActionResult GetCompany(int id)
        {
            Company dbCompany = _companyRepository.GetByID(id);
            if(dbCompany != null && !dbCompany.IsArchived)
            {
                return Ok(Mapper.Map<CompanyModel>(dbCompany));
            }
            else
            {
                return NotFound();
            }
           
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
        [ResponseType(typeof(CompanyModel))]
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
        [ResponseType(typeof(CompanyModel))]
        public IHttpActionResult DeleteCompany(int id)
        {
            //Get the DbComment corresponding to the comment ID
            Company dbCompany = _companyRepository.GetByID(id);
            if(dbCompany == null)
            {
                return NotFound();
            }

            //Delete Company
            try
            {
                //set to archived
                dbCompany.IsArchived = true;

                //update the comment
                _companyRepository.Update(dbCompany);

                //Save changes
                _unitOfWork.Commit();
            }
            catch(Exception e)
            {
                throw new Exception("Unable to mark the company as archived");
            }

            return Ok(Mapper.Map<CompanyModel>(dbCompany));
        }




        //GET: api/Companies/5 || [5]
        [EnableQuery]
        public IQueryable<CompanyModel> GetCompaniesByIndustry(int industryID)
        {
            var companies = _companyRepository.Where(ia => !ia.IsArchived && ia.Industries.Any(i => i.IndustryID == industryID));

            return companies.ProjectTo<CompanyModel>();

        }


        //-------------------------------------------------------------
        //Helper Methods


        //Does company Exist
        private bool CompanyExists(int id)
        {
            return _companyRepository.Count(c => c.CompanyID == id) > 0;
        }

      
    }
}
