using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReviewApplication.Core.Domain
{
    public class CompanyIndustry
    {
         public int CompanyID { get; set; }
        public int IndustryID { get; set; }

        public virtual Company Company { get; set; }
        public virtual Industry Industry { get; set; }

        public void Update(CompanyIndustryModel companyIndustry)
        {
            CompanyID = companyIndustry.CompanyID;
            IndustryID = companyIndustry.IndustryID;
        }
    }
}