using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Repository;
using ReviewApplication.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Data.Repository
{
     public class CompanyProfileRepository : Repository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
}
