using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class ExternalLogin
    {
        public int ExternalLoginID { get; set; } //Primary Key

        public int UserID { get; set; } //Foriegn Key

        public bool IsArchived { get; set; }//Archived State

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }



        //Add Virtuals
        public virtual User User { get; set; }


        //Add Methods (update)
        public void Update(ExternalLoginModel externalLoginModel)
        {
            ExternalLoginID = externalLoginModel.ExternalLoginID;
            UserID = externalLoginModel.UserID;
            IsArchived = externalLoginModel.IsArchived;
            LoginProvider = externalLoginModel.LoginProvider;
            ProviderKey = externalLoginModel.ProviderKey;
        }
    }
}
