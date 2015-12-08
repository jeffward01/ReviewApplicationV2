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

        public int UserID { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public virtual User User { get; set; }
    }
}
