using ReviewApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
   public class CompanyIndustryModel
    {
        public int CompanyID { get; set; }
        public int IndustryID { get; set; }

        public  Company Company { get; set; }
        public  Industry Industry { get; set; }
    }
}
