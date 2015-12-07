using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class UserModel 
    {

        public int UserID { get; set; } // Primary Key

        public string Email { get; set; }
        public string ResetEmail { get; set; }
        public string Industry { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }

       
        //Add Either?
        public InsuranceAgentProfileModel InsuranceAgentProfile { get; set; }
        public CompanyProfileModel CompanyProfile { get; set; }

        //Add methods if any (update)

    }
}
