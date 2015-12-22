using ReviewApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
    public class InsuranceAgentModel
    {
        public int InsuranceAgentID { get; set; } // Primary Key
        public int UserID { get; set; } // Forign Key
        public bool IsArchived { get; set; } //Archived State

        public string ProfileName { get; set; }

        // Change Terrortiory to list in the future
        public string Territory { get; set; }
        public int YearsOfExperience { get; set; }
        public string TypeOfAgent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        //Recommended Lead Companies a list?
        public string RecommendedLeadCompanies { get; set; }
        //Reference LeadType?   (Types of Leads Used)
        public string TypesOfLeadsUsed { get; set; }
        public string ProfilePictureURL { get; set; }
        //Gravatar? Something special?
        public string Gravatar { get; set; }
        public string TwitterHandle { get; set; }
        public bool Verified { get; set; }
        public string AgentWebsiteURL { get; set; }
        public string InsuranceForumsHandle { get; set; }
        public int NumberOfReviewPosts { get; set; }
        public int NumberOfLikesRecieved { get; set; }
        public int AverageQuanitityOfLeadsTransactiondPerWeek { get; set; }
        public int AverageQuanitityOfLeadsTransactiondPerMonth { get; set; }

        //Lead Preferance
        public bool TelemarketerLeads { get; set; }
        public string TelemarketingLeadNotes { get; set; }

        public bool MailLeads { get; set; }
        public string MailLeadLeadNotes { get; set; }

        public bool Press1Leads { get; set; }
        public string Press1LeadNotes { get; set; }

        public bool InternetLeads { get; set; }
        public string InternetLeadNotes { get; set; }

        public bool ColdCallPhoneNumberLists { get; set; }
        public string ColdCallPhoneNumberListLeadNotes { get; set; }

        public List<CommentModel> Comments { get; set; }
        public List<ReviewPostModel> ReviewPosts { get; set; }
        public List<InsuranceAgentIndustryModel> Industries { get; set; }
        public List<LeadTransactionModel> Transations { get; set; }


    }
}
