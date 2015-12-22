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
        public bool IsArchived { get; set; } //Archived State

        public string Email { get; set; }
        public string ResetEmail { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }

       
        //Add Either?
        public InsuranceAgentModel InsuranceAgentProfile { get; set; }
        public CompanyModel CompanyProfile { get; set; }

        //Add methods if any (update)

    }
}
