using ReviewApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class ExternalLoginModel
    {
        public int ExternalLoginID { get; set; }

        public bool IsArchived { get; set; } //Archived State

        public int UserID { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public User User { get; set; }
    }
}
