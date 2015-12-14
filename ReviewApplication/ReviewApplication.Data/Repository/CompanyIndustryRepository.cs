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
    
    public class CompanyIndustryRepository : Repository<CompanyIndustry>, ICompanyIndustryRepository
    {
        public CompanyIndustryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        { }
    }
}
