using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class ExternalLogin
    {
        public int ExternalLoginID { get; set; }

        public int UserID { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        //Add Virtuals
        public virtual User User { get; set; }


        //Add Methods (update)
    }
}
