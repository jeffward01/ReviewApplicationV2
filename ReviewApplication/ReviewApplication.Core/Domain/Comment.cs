using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;

namespace ReviewApplication.Core.Domain
{
    public class Comment
    {
        public int CommentID { get; set; }
        public DateTime CommentDate { get; set; }

        public int ReviewID { get; set; } // Foriegn Key 
        public int? InsuranceAgentID { get; set; }
        public int? CompanyID { get; set; }
        public string PostBody { get; set; }
        public int NumberOfLikes { get; set; }

        //Set Virtual varibles
        public virtual InsuranceAgentProfile InsuranceAgentProfile { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ReviewPost ReviewPost { get; set; }
        


        //any Methods? Update
        public void Update(CommentModel comment)
        {
            //If new comment, set created date to now
            if(comment.CommentID == 0)
            {
                CommentDate = DateTime.Now;
            }

            CommentID = comment.CommentID;
            CommentDate = comment.CommentDate;
            ReviewID = comment.ReviewID;
            InsuranceAgentID = comment.InsuranceAgentID;
            CompanyID = comment.CompanyID;
            PostBody = comment.PostBody;
            NumberOfLikes = comment.NumberOfLikes;

        }

    }
}
