using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewApplication.Core;
using ReviewApplication.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReviewApplication.Core.Domain
{
    public class InsuranceAgent
    {
        public int InsuranceAgentID { get; set; } // Primary Key

        public int UserID { get; set; } // Forign Key

        public int IndustryID { get; set; } //Forign Key

        public bool IsArchived { get; set; } //Archived State

        public string ProfileName { get; set; }

        // Change Terrortiory to list in the future
        public string Territory { get; set; }
        public int YearsOfExperience { get; set; }
        public string TypeOfAgent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Industry Insustry { get; set; }

        //Set Full Name
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Bio { get; set; }
        //Recommended Lead Companies a list?
        public string RecommendedLeadCompanies { get; set; }
        //Reference LeadType?   (Types of Leads Used)
        public string TypesOfLeadsUsed { get; set; }
        public string ProfilePictureURL { get; set; }
        //Gravatar? Something special?
        public string Gravatar { get; set; }
        public string TwitterHandle { get; set; }
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
        //Add Vitrual Varibles


            //Can have many reviewPosts, Comments, Transaction
        public virtual ICollection<ReviewPost> ReviewPosts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<LeadTransaction> Transactions { get; set; }
        public virtual Industry Industry { get; set; }

        //Can only have 1 userProfile
        public virtual User UserProfile { get; set; }

        //Add methods if any (update)
        public void Update(InsuranceAgentModel insuranceProfileAgent)
        {

            InsuranceAgentID = insuranceProfileAgent.InsuranceAgentID;
            UserID = insuranceProfileAgent.UserID;

            ProfileName = insuranceProfileAgent.ProfileName;


            // Change Terrortiory to list 
            Territory = insuranceProfileAgent.Territory;
            YearsOfExperience = insuranceProfileAgent.YearsOfExperience;
            TypeOfAgent = insuranceProfileAgent.TypeOfAgent;
            FirstName = insuranceProfileAgent.FirstName;
            LastName = insuranceProfileAgent.LastName;
            Bio = insuranceProfileAgent.Bio;
            //Recommended Lead Companies a list?
            RecommendedLeadCompanies = insuranceProfileAgent.RecommendedLeadCompanies;
            //Reference LeadType?   (Types of Leads Used)
            TypesOfLeadsUsed = insuranceProfileAgent.TypesOfLeadsUsed;
            ProfilePictureURL = insuranceProfileAgent.ProfilePictureURL;
            //Gravatar? Something special?
            InsuranceForumsHandle = insuranceProfileAgent.InsuranceForumsHandle;
            Gravatar = insuranceProfileAgent.Gravatar;
            TwitterHandle = insuranceProfileAgent.TwitterHandle;
            AgentWebsiteURL = insuranceProfileAgent.AgentWebsiteURL;
            NumberOfReviewPosts = insuranceProfileAgent.NumberOfReviewPosts;
            NumberOfLikesRecieved = insuranceProfileAgent.NumberOfLikesRecieved;
            AverageQuanitityOfLeadsTransactiondPerWeek = insuranceProfileAgent.AverageQuanitityOfLeadsTransactiondPerWeek;
            AverageQuanitityOfLeadsTransactiondPerMonth = insuranceProfileAgent.AverageQuanitityOfLeadsTransactiondPerMonth;

            //Lead Preferance
            TelemarketerLeads = insuranceProfileAgent.TelemarketerLeads;
            TelemarketingLeadNotes = insuranceProfileAgent.TelemarketingLeadNotes;

            MailLeads = insuranceProfileAgent.MailLeads;
            MailLeadLeadNotes = insuranceProfileAgent.MailLeadLeadNotes;

            Press1Leads = insuranceProfileAgent.Press1Leads;
            Press1LeadNotes = insuranceProfileAgent.Press1LeadNotes;

            InternetLeads = insuranceProfileAgent.InternetLeads;
            InternetLeadNotes = insuranceProfileAgent.InternetLeadNotes;

            ColdCallPhoneNumberLists = insuranceProfileAgent.ColdCallPhoneNumberLists;
            ColdCallPhoneNumberListLeadNotes = insuranceProfileAgent.ColdCallPhoneNumberListLeadNotes;

            IsArchived = insuranceProfileAgent.IsArchived;
        }
            
        
    }
}
