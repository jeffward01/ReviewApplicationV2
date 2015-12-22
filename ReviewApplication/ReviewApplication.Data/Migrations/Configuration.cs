namespace ReviewApplication.Data.Migrations
{
    using Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReviewApplication.Data.Infrastructure.ReviewApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReviewApplication.Data.Infrastructure.ReviewApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //------------------------------------------------------------------------

            //TODO: Set all the proper ID's and Attributes
            //TODO: Make a way to 'Programmatically' Create ALL these Tables


            //Build 20 Users
            context.Users.AddOrUpdate(x => x.Id,

            #region
                new User
                {
                    Id = 0,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-A",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 1,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-A",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 2,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-B",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 3,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-C",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 4,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-D",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 5,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-E",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 3,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-F",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 6,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-G",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 7,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-H",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 8,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-I",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 9,
                    IsArchived = false,
                    Email = "Example@example.com",
                    ResetEmail = "ResetEmail@example.com",
                    UserName = "Company-J",
                    PasswordHash = "Password",
                    AccountType = "Company",
                    CreatedDate = DateTime.Now,

                },
                new User
                {
                    Id = 10,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-A",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 11,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-B",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 12,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-C",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 13,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-D",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 14,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-E",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 15,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-F",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 16,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-G",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 17,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-H",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 18,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-I",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,
                },
                new User
                {
                    Id = 19,
                    IsArchived = false,
                    Email = "test@example.com",
                    ResetEmail = "resetEmail@example.com",
                    UserName = "InsuranceAgent-J",
                    PasswordHash = "Password",
                    AccountType = "InsuranceAgent",
                    CreatedDate = DateTime.Now,

                });

            #endregion

            //Build 10 companies || => 7 Verified, 3 Un-Verified
            context.Companies.AddOrUpdate(x => x.CompanyID,


            #region

                //Company 1 || Unverified 
                new Company
                {
                    CompanyID = 0,
                    UserID = 0,
                    IsArchived = false,
                    Verified = false,
                    CompanyName = "Joe Schmoes Lead Company",
                    Address1 = "101 Wonder Way",
                    Address2 = "Suite: 290",
                    State = "CA",
                    City = "Los Angeles",
                    Zip = "90036",
                    TelephoneNumber = "5553331234",
                    OtherTelephoneNumber = "5551231234",
                    EmailAddress = "Joe@leads.com",
                    SkypeHandle = "LeadCo",
                    WebsiteURL = "http://www.leadcompany.com",
                    PictureLogoURL = "https://lh5.ggpht.com/E3EDtjhawNHXNOhnid79xqMofjwy6wIciqHC_-Xe77F9HhPfDOYaJLFTyGBYsDeHvQ=w300",
                    Bio = "The best lead company ever.  Like a pheonix we rise from the ashes.",
                    LeadNotes = "Our leads are generated by highly trained tele-sales professionals",
                    PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                    //Payment Area  || Stripe?
                    AcceptsCredit = true,
                    CreditComments = "We accept Credit",
                    AcceptsDebit = true,
                    DebitComments = "We accept Debit",
                    AcceceptsAmericanExpress = true,
                    AmericanExpressComments = "We accept American Express",
                    AcceptsPaypal = true,
                    PaypalEmailAddress = "joeLeads@leads.com",
                    PaypalComments = "We accept Paypal",
                    AcceptsMoneyOrder = true,
                    MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                    AcceptsVenmo = true,
                    VenmoComments = "Maximum transaction amount $675",
                    VenmoHandle = "JoesLeadsNow",
                    //Company Rating Depends on ReviewPosts

                },

                 //Company 2 || Unverified
                 new Company
                 {
                     CompanyID = 1,
                     UserID = 1,
                     IsArchived = false,
                     Verified = false,
                     CompanyName = "All Star Leads Company",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },

                 //Company 3 || Unverified
                 new Company
                 {
                     CompanyID = 2,
                     UserID = 2,
                     IsArchived = false,
                     Verified = false,
                     CompanyName = "Amazing Leads Inc",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },

                 //Company 4 || Verified
                 new Company
                 {
                     CompanyID = 3,
                     UserID = 3,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "Precision Lead Co.",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },

                 //Company 5 || Verified
                 new Company
                 {
                     CompanyID = 4,
                     UserID = 4,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "Best Leads Ever.",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },


                 //Company 6 || Verified
                 new Company
                 {
                     CompanyID = 5,
                     UserID = 5,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "Best Leads Ever.",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },

                 //Company 7 || Verified
                 new Company
                 {
                     CompanyID = 6,
                     UserID = 6,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "Lead Generation Services",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },


                 //Company 8 || Verified
                 new Company
                 {
                     CompanyID = 7,
                     UserID = 7,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "SOlD! Leads",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },


                 //Company 9 || Verified
                 new Company
                 {
                     CompanyID = 8,
                     UserID = 8,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "SouthWest Leads.",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 },


                 //Company 10 || Verified
                 new Company
                 {
                     CompanyID = 9,
                     UserID = 9,
                     IsArchived = false,
                     Verified = true,
                     CompanyName = "NorthEast Leads.",
                     Address1 = "111 Hollwood Blvd",
                     Address2 = "Suite: 880",
                     State = "CA",
                     City = "Los Angeles",
                     Zip = "90036",
                     TelephoneNumber = "5556667894",
                     OtherTelephoneNumber = "5557891234",
                     EmailAddress = "leads@allstarleads.com",
                     SkypeHandle = "AllStarLeads",
                     WebsiteURL = "http://www.AllStarleads.com",
                     PictureLogoURL = "http://design.ubuntu.com/wp-content/uploads/ubuntu-logo32.png",
                     Bio = "All Star Leads Company.  Our leads are 5-star!",
                     LeadNotes = "All of our leads are organic and come with a contact gurantee!",
                     PaymentNotes = "Please wait 2 days for payment to clear before lead generation begins",

                     //Payment Area  || Stripe?
                     AcceptsCredit = true,
                     CreditComments = "We accept Credit",
                     AcceptsDebit = true,
                     DebitComments = "We accept Debit",
                     AcceceptsAmericanExpress = true,
                     AmericanExpressComments = "We accept American Express",
                     AcceptsPaypal = true,
                     PaypalEmailAddress = "leads@allstarleads.com",
                     PaypalComments = "We accept Paypal",
                     AcceptsMoneyOrder = true,
                     MoneyOrderComments = "Please allow 2 weeks for money order to arrive",
                     AcceptsVenmo = true,
                     VenmoComments = "We accept Venmo!",
                     VenmoHandle = "AllStarLeads",

                     //Company Rating Depends on ReviewPosts
                 }


                 #endregion
                );

            //Build 10 Insurance Agents || => 5 Verified, 5 Un-Verified
            context.InsuranceAgents.AddOrUpdate(x => x.InsuranceAgentID,

            #region

                //InsuranceAgent 1 || Un-Verified
                new InsuranceAgent
                {
                    InsuranceAgentID = 0,
                    UserID = 10,
                    IsArchived = false,
                    ProfileName = "BossSales123",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "James",
                    LastName = "Marsden",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = false,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"

                },

                //InsuranceAgent 2 || Un-Verified
                new InsuranceAgent
                {
                    InsuranceAgentID = 1,
                    UserID = 11,
                    IsArchived = false,
                    ProfileName = "Lucky777",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Greg",
                    LastName = "Maverson",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = false,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 3 || Un-Verified
                new InsuranceAgent
                {
                    InsuranceAgentID = 2,
                    UserID = 12,
                    IsArchived = false,
                    ProfileName = "EliteSales",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Edward",
                    LastName = "Cullen",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = false,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 4 || Un-Verified
                new InsuranceAgent
                {
                    InsuranceAgentID = 3,
                    UserID = 13,
                    IsArchived = false,
                    ProfileName = "TotallyAwesome",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Suesan",
                    LastName = "Thomas",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = false,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 5 || Un-Verified
                new InsuranceAgent
                {
                    InsuranceAgentID = 4,
                    UserID = 14,
                    IsArchived = false,
                    ProfileName = "GameOnSales",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Todd",
                    LastName = "Mills",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = true,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 6 || Verified 
                new InsuranceAgent
                {
                    InsuranceAgentID = 5,
                    UserID = 15,
                    IsArchived = false,
                    ProfileName = "SleekSales",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Steven",
                    LastName = "Smith",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = true,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 7 || Verified 
                new InsuranceAgent
                {
                    InsuranceAgentID = 6,
                    UserID = 16,
                    IsArchived = false,
                    ProfileName = "TeleSalesAwesome",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Kevin",
                    LastName = "Miller",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = true,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 8 || Verified 
                new InsuranceAgent
                {
                    InsuranceAgentID = 7,
                    UserID = 17,
                    IsArchived = false,
                    ProfileName = "BrookeSanden123",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Brooke",
                    LastName = "Sanden",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = true,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },
                //InsuranceAgent 9 || Verified 
                new InsuranceAgent
                {
                    InsuranceAgentID = 8,
                    UserID = 18,
                    IsArchived = false,
                    ProfileName = "Jward01",
                    Territory = "Southern California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life Insurnace",
                    FirstName = "Jeff",
                    LastName = "Ward",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = false,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = true,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                },

                //InsuranceAgent 10 || Verified 
                new InsuranceAgent
                {
                    InsuranceAgentID = 9,
                    UserID = 19,
                    IsArchived = false,
                    ProfileName = "LifeSales",
                    Territory = "California",
                    YearsOfExperience = 5,
                    TypeOfAgent = "Life and Health Insurnace",
                    FirstName = "Phillip",
                    LastName = "Knopp",
                    Bio = "This is a short Bio... Yada Yada Yada",
                    RecommendedLeadCompanies = "Amazing Leads Co",
                    TypesOfLeadsUsed = "Telemarketer Leads",
                    ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Mr._Smiley_Face.svg/2000px-Mr._Smiley_Face.svg.png",
                    Gravatar = "YestGravatarUser",
                    TwitterHandle = "TwitterExampleHandle",
                    Verified = true,
                    InsuranceForumsHandle = "InsuranceForumsHandle",
                    AverageQuanitityOfLeadsTransactiondPerMonth = 100,
                    AverageQuanitityOfLeadsTransactiondPerWeek = 25,

                    TelemarketerLeads = true,
                    TelemarketingLeadNotes = "Telemarketer Leads are the best",
                    MailLeads = true,
                    MailLeadLeadNotes = "Mailers are my Bread and Butter",
                    Press1Leads = true,
                    Press1LeadNotes = "Great supplement to any week of leads",
                    InternetLeads = false,
                    InternetLeadNotes = "Not worth the money",
                    ColdCallPhoneNumberLists = false,
                    ColdCallPhoneNumberListLeadNotes = "Just invest Extra for the better leads.  Time is money"
                }


#endregion
                );



            //Build Industries || 5 Total
            context.Industries.AddOrUpdate(x => x.IndustryID,

            #region
                new Industry
                {
                    IndustryID = 0,
                    IsArchived = false,
                    Description = "Life Insurance"
                },

                new Industry
                {
                    IndustryID = 1,
                    IsArchived = false,
                    Description = "Health Insurance"
                },
                new Industry
                {
                    IndustryID = 2,
                    IsArchived = false,
                    Description = "Property and Casualty Insurance"
                },
                new Industry
                {
                    IndustryID = 3,
                    IsArchived = false,
                    Description = "Medicare Insurance"
                },
                new Industry
                {
                    IndustryID = 4,
                    IsArchived = false,
                    Description = "Annuities"
                });
            #endregion

            //Build CompanyIndustries
            context.




            //Build InsuranceAgentIndustries


            //Build LeadProducts

            //Build LeadTransactions

            //Build Comments

            //Build ReviewPosts






        }




    }
}
