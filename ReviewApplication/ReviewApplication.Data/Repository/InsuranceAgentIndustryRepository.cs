﻿using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Repository;
using ReviewApplication.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Data.Repository
{ 
    public class InsuranceAgentIndustryRepository : Repository<InsuranceAgentIndustry>, IInsuranceAgentIndustryRepository
    {
        public InsuranceAgentIndustryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
