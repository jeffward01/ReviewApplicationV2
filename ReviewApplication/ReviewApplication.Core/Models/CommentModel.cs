using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class CommentModel
    {
        public int CommentID { get; set; } //Primary Key
        public int ReviewID { get; set; } //Foriegn Key
        public bool IsArchived { get; set; } //Archived State

        public int? InsuranceAgentID { get; set; }
        public int? CompanyID { get; set; }
        public DateTime CommentDate { get; set; }
        public string PostBody { get; set; }
        public int NumberOfLikes { get; set; }

        //public IEnumerable<CommentModel> Comments { get; set; }
      

    }
}
