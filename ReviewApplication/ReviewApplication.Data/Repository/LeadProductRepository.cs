using ReviewApplication.CORE.Domain;
using ReviewApplication.CORE.Repository;
using ReviewApplication.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.DATA.Repository
{
    public class LeadProductRepository : Repository<LeadProduct>, ILeadProductRepository
    {
        public LeadProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
}
