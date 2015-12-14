using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class LeadProductModel
    {
        public int LeadProductID { get; set; } //Primary Key
        public int CompanyID { get; set; } //Forign Key
        public List<int> ReviewPostID { get; set; } //Foriegn Key

        public bool IsArchived { get; set; } //Archived State

        public string OrderLink { get; set; }

        //Lead Type
        public bool TelemarketingLead { get; set; }
        public string TelemarketingLeadNotes { get; set; }

        public bool MailLead { get; set; }
        public string MailLeadLeadNotes { get; set; }

        public bool Press1Lead { get; set; }
        public string Press1LeadNotes { get; set; }

        public bool InternetLead { get; set; }
        public string InternetLeadNotes { get; set; }

        public bool ColdCallPhoneNumberList { get; set; }
        public string ColdCallPhoneNumberListLeadNotes { get; set; }

        public int Price { get; set; }
        public string ProductNotes { get; set; }

        public List<ReviewPostModel> ReviewPosts { get; set; }

    }
}
