using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class LeadProductReviewPost
    {
        public int LeadProductID { get; set; }
        public int ReviewPostID { get; set; }

        public virtual ReviewPost ReviewPost { get; set; }
        public virtual LeadProduct LeadProduct { get; set; }

        public void Update(LeadProductReviewPostModel leadProductReview)
        {
            LeadProductID = leadProductReview.LeadProductID;
            ReviewPostID = leadProductReview.ReviewPostID;
        }
    }
}
