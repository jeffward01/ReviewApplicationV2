using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class InsuranceAgentReviewPost
    {
        public int InsuranceAgentID { get; set; }
        public int ReviewPostID { get; set; }

        public virtual ReviewPost ReviewPost { get; set; }
        public virtual InsuranceAgent InsuranceAgent { get; set; }

        public void Update(InsuranceAgentReviewPostModel companyReviewPost)
        {
            InsuranceAgentID = companyReviewPost.InsuranceAgentID;
            ReviewPostID = companyReviewPost.ReviewPostID;
        }
    }
}
