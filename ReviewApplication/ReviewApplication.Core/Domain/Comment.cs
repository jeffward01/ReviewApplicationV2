using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;

namespace ReviewApplication.Core.Domain
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int? ParentCommentID { get; set; }
        public DateTime CommentDate { get; set; }

        public int ReviewID { get; set; } // Foriegn Key 
        public int? InsuranceAgentProfileID { get; set; }
        public int? CompanyID { get; set; }
        public string PostBody { get; set; }
        public int NumberOfLikes { get; set; }

        //Set Virtual varibles
        public virtual InsuranceAgent InsuranceAgentProfile { get; set; }
        public virtual Company CompanyProfile { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ReviewPost ReviewPost { get; set; }
        public virtual Comment ParentComment { get; set; }
        


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
            InsuranceAgentProfileID = comment.InsuranceAgentID;
            CompanyID = comment.CompanyID;
            PostBody = comment.PostBody;
            NumberOfLikes = comment.NumberOfLikes;

        }

    }
}
