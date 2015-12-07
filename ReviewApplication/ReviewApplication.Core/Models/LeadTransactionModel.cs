using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class LeadTransactionModel
    {
        public DateTime TransactionDate { get; set; }
        public int LeadTransactionID { get; set; }
        public int CompanyID { get; set; }
        public int LeadProductID { get; set; }
        public int InsuranceAgentProfileID { get; set; }
        public int TransactionPrice { get; set; }
        public string TransactionNotes { get; set; }

        public CompanyProfileModel Company { get; set; }
        public LeadProductModel LeadProduct {get;set;}
        public InsuranceAgentProfileModel InsuranceAgent { get; set; }
    }
}
