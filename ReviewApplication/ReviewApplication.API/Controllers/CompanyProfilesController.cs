using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Models;
using ReviewApplication.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ReviewApplication.API.Controllers
{
    public class CompanyProfilesController : ApiController
    {
        private readonly ICompanyProfileRepository _companyProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Constructor
        public CompanyProfilesController(ICompanyProfileRepository companyProfileRepository, IUnitOfWork unitOfWork)
        {
            _companyProfileRepository = companyProfileRepository;
            _unitOfWork = unitOfWork;
        }


        // GET: api/CompanyProfiles
        [EnableQuery]
        public IQueryable<CompanyProfileModel> Get()
        {
            return null;  
        }

        // GET: api/CompanyProfiles/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CompanyProfiles
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CompanyProfiles/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CompanyProfiles/5
        public void Delete(int id)
        {
        }
    }
}
