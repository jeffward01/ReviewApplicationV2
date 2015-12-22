using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
   public class Industry
    {
        public int IndustryID { get; set; } //Primary Key

        public bool IsArchived { get; set; } //Archived State
        public string Description { get; set; }

        //Add Virtuals
        public virtual ICollection<InsuranceAgentIndustry> InsuranceAgents { get; set; }
        public virtual ICollection<CompanyIndustry> Companies { get; set; }


        //Add Methods (update)
        public void Update(IndustryModel industry)
        {
            IndustryID = industry.IndustryID;
            IsArchived = industry.IsArchived;
       
            Description = industry.Description;
        }
    }
}
