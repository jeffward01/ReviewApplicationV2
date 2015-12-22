using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class CompanyReviewPost
    {
        public int CompanyID { get; set; }
        public int ReviewPostID { get; set; }

     
        public virtual ReviewPost ReviewPost { get; set; }
        public virtual Company Company { get; set; }

        public void Update(CompanyReviewPostModel companyReviewPost)
        {
            CompanyID = companyReviewPost.CompanyID;
            ReviewPostID = companyReviewPost.ReviewPostID;
        }
    }
}
