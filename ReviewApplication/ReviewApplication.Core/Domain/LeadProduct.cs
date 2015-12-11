using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Domain
{
    public class LeadProduct
    {
        public int LeadProductID { get; set; } //Primary Key
        public int CompanyID { get; set; } //Forign Key



        public string Price { get; set; }
        public string ProductNotes { get; set; }
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

        

        //Add Virtual Varibles
        public virtual Company Company { get; set; }

        //Add methods if any (update)
        public void Update(LeadProductModel leadProduct)
        {
            LeadProductID = leadProduct.LeadProductID;
            CompanyID = leadProduct.CompanyID;
            Price = leadProduct.Price;
            ProductNotes = leadProduct.ProductNotes;
            OrderLink = leadProduct.OrderLink;
            TelemarketingLead = leadProduct.TelemarketingLead;
            TelemarketingLeadNotes = leadProduct.TelemarketingLeadNotes;
            MailLead = leadProduct.MailLead;
            MailLeadLeadNotes = leadProduct.MailLeadLeadNotes;
            Press1Lead = leadProduct.Press1Lead;
            Press1LeadNotes = leadProduct.Press1LeadNotes;
            InternetLead = leadProduct.InternetLead;
            InternetLeadNotes = leadProduct.InternetLeadNotes;
            ColdCallPhoneNumberList = leadProduct.ColdCallPhoneNumberList;
            ColdCallPhoneNumberListLeadNotes = leadProduct.ColdCallPhoneNumberListLeadNotes;
        }
    }
}
