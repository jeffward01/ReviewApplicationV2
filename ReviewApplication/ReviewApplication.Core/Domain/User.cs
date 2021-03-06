﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewApplication.Core.Models;
using Microsoft.AspNet.Identity;
using ReviewApplication.Core.Repository;
using ReviewApplication.Core.Models;
using ReviewApplication.Core.Domain;

namespace ReviewApplication.Core.Domain
{
   public class User : IUser<int>
    {
        public int Id { get; set; } // Primary Key
        public bool IsArchived { get; set; } //Archived State

        public string Email { get; set; }
        public string ResetEmail { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }

        //Add Vitrual Varibles
        public virtual Company CompanyProfile { get; set; }
        public virtual InsuranceAgent InsuranceAgentProfile { get; set; }
        public virtual ICollection<ExternalLogin> ExternalLogins { get; set; }


        //Add methods if any (update)
        public void Update(UserModel UserProfile)
        {
            //If new user, CreatedDate = now.
            if(UserProfile.UserID == 0)
            {
                CreatedDate = DateTime.Now;
            }

            Email = UserProfile.Email;
            ResetEmail = UserProfile.ResetEmail;
            PasswordHash = UserProfile.PasswordHash;
            UserName = UserProfile.UserName;
            SecurityStamp = UserProfile.SecurityStamp;
            AccountType = UserProfile.AccountType;
            CreatedDate = UserProfile.CreatedDate;
            IsArchived = UserProfile.IsArchived;
        }
    }
}
