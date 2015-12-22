using ReviewApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class CompanyReviewPostModel
    {
        public int CompanyID { get; set; }
        public int ReviewPostID { get; set; }

        public ReviewPost ReviewPost { get; set; }
        public Company Company { get; set; }

    }
}
