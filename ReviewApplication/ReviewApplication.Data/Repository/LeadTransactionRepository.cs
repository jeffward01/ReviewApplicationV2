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
    public class LeadTransactionRepository : Repository<LeadTransaction>, ILeadTransactionRepository
    {
        public LeadTransactionRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
}
