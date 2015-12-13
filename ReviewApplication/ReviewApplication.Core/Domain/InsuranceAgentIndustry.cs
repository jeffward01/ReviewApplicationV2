using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using Microsoft.SCP;
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
    public class InsuranceAgentIndustry
    {
        public int InsuranceAgentID { get; set; }
        public int IndustryID { get; set; }

        public virtual InsuranceAgent InsuranceAgent { get; set; }
        public virtual Industry Industry { get; set; }

        public void Update(InsuranceAgentIndustryModel insuranceAgentIndustry)
        {
            IndustryID = insuranceAgentIndustry.IndustryID;
            InsuranceAgentID = insuranceAgentIndustry.InsuranceAgentID;
        }
    }
}