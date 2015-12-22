using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Repository;
using ReviewApplication.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReviewApplication.Data.Repository
{
    public class InsuranceAgentReviewPostRepository : Repository<InsuranceAgentReviewPost>, IInsuranceAgentReviewPostRepository
    {
        public InsuranceAgentReviewPostRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}