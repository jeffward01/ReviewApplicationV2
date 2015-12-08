using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
   public class Industry
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //Add Virtuals
        public ICollection<InsuranceAgentProfile> InsuranceAgentProfiles { get; set; }
        public ICollection<CompanyProfile> CompanyProfiles { get; set; }

        //Add Methods (update)
    }
}
