using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class ReviewPost
    {
        public int ReviewPostID { get; set; } //Primary Key
        public bool IsArchived { get; set; } //Archived State

        public DateTime ReviewPostDate { get; set; }

        public double Rating { get; set; }
       

        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public int NumberOfLikes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<CompanyReviewPost> CompanyReviewPosts { get; set; }
        public virtual ICollection<InsuranceAgentReviewPost> InsuranceAgentReviewPosts { get; set; }
        public virtual ICollection<LeadProductReviewPost>LeadProductReviewPosts { get; set; }



        public void Update(ReviewPostModel reviewPost)
        {
            ReviewPostID = reviewPost.ReviewPostID;
        
            ReviewPostDate = reviewPost.ReviewPostDate;
            Rating = reviewPost.Rating;
        
            PostBody = reviewPost.PostBody;
            PostTitle = reviewPost.PostTitle;
            NumberOfLikes = reviewPost.NumberOfLikes;
            IsArchived = reviewPost.IsArchived;
        }
    }
}
