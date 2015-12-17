using ReviewApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Models
{
   public class CompanyModel
    {
        public int CompanyID { get; set; } //Primary Key
        public int UserID { get; set; }  // Foreign Key
        public bool IsArchived { get; set; } //Archived State

        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string TelephoneNumber { get; set; }
        public string OtherTelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string SkypeHandle { get; set; }
        public bool Verified { get; set; }
        public string WebsiteURL { get; set; }
        public string PictureLogoURL { get; set; }
        public int CompanyRating { get; set; }
        public string Bio { get; set; }
        public string LeadNotes { get; set; }
        public string PaymentNotes { get; set; }

        //Payment Area  || Stripe?
        public bool AcceptsCredit { get; set; }
        public string CreditComments { get; set; }
        public bool AcceptsDebit { get; set; }
        public string DebitComments { get; set; }
        public bool AcceceptsAmericanExpress { get; set; }
        public string AmericanExpressComments { get; set; }
        public bool AcceptsPaypal { get; set; }
        public string PaypalEmailAddress { get; set; }
        public string PaypalComments { get; set; }
        public bool AcceptsMoneyOrder { get; set; }
        public string MoneyOrderComments { get; set; }
        public bool AcceptsVenmo { get; set; }
        public string VenmoComments { get; set; }
        public string VenmoHandle { get; set; }

        public List<LeadProductModel> LeadProducts { get; set; }
        public List<ReviewPostModel> ReviewPosts { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<CompanyIndustryModel> Industries { get; set; }
        public List<LeadTransactionModel> Transactions { get; set; }

     



    }
}
