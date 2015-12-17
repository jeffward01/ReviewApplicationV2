using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class IndustryModel
    {
        public int Id { get; set; }
        public int? InsuranceAgentID { get; set; }//ForiegnKey
        public int? CompanyID { get; set; } //ForiegnKey
        public string Description { get; set; }
        public bool IsArchived { get; set; } //Archived State

        public string CompaniesUrl
        {
            get
            {
                return "/api/industry/" + Id + "/companies";
            }
        }

        public string InsuranceAgents
        {
            get
            {
                return "/api/industry/" + Id + "/agents";
            }
        }
    }
}
