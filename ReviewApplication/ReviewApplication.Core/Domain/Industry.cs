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
        public int Id { get; set; } //Primary Key
        public bool IsArchived { get; set; } //Archived State
        public string Description { get; set; }

        //Add Virtuals
        public ICollection<InsuranceAgent> InsuranceAgentProfiles { get; set; }
        public ICollection<Company> CompanyProfiles { get; set; }

        //Add Methods (update)
        public void Update(IndustryModel industry)
        {
            Id = industry.Id;
            IsArchived = industry.IsArchived;
            Description = industry.Description;
        }
    }
}
