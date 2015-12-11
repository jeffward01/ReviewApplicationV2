namespace ReviewApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        ParentCommentID = c.Int(),
                        CommentDate = c.DateTime(nullable: false),
                        ReviewID = c.Int(nullable: false),
                        InsuranceAgentProfileID = c.Int(),
                        CompanyID = c.Int(),
                        PostBody = c.String(),
                        NumberOfLikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Comments", t => t.ParentCommentID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .ForeignKey("dbo.InsuranceAgents", t => t.InsuranceAgentProfileID)
                .ForeignKey("dbo.ReviewPosts", t => t.ReviewID)
                .Index(t => t.ParentCommentID)
                .Index(t => t.ReviewID)
                .Index(t => t.InsuranceAgentProfileID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        IndustryID = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        TelephoneNumber = c.String(),
                        OtherTelephoneNumber = c.String(),
                        EmailAddress = c.String(),
                        SkypeHandle = c.String(),
                        WebsiteURL = c.String(),
                        PictureLogoURL = c.String(),
                        Bio = c.String(),
                        LeadNotes = c.String(),
                        PaymentNotes = c.String(),
                        AcceptsCredit = c.Boolean(nullable: false),
                        CreditComments = c.String(),
                        AcceptsDebit = c.Boolean(nullable: false),
                        DebitComments = c.String(),
                        AcceceptsAmericanExpress = c.Boolean(nullable: false),
                        AmericanExpressComments = c.String(),
                        AcceptsPaypal = c.Boolean(nullable: false),
                        PaypalEmailAddress = c.String(),
                        PaypalComments = c.String(),
                        AcceptsMoneyOrder = c.Boolean(nullable: false),
                        MoneyOrderComments = c.String(),
                        AcceptsVenmo = c.Boolean(nullable: false),
                        VenmoComments = c.String(),
                        VenmoHandle = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Users", t => t.CompanyID)
                .ForeignKey("dbo.Industries", t => t.IndustryID)
                .Index(t => t.CompanyID)
                .Index(t => t.IndustryID);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsuranceAgents",
                c => new
                    {
                        InsuranceAgentID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        IndustryID = c.Int(nullable: false),
                        ProfileName = c.String(),
                        Territory = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        TypeOfAgent = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Bio = c.String(),
                        RecommendedLeadCompanies = c.String(),
                        TypesOfLeadsUsed = c.String(),
                        ProfilePictureURL = c.String(),
                        Gravatar = c.String(),
                        TwitterHandle = c.String(),
                        AgentWebsiteURL = c.String(),
                        InsuranceForumsHandle = c.String(),
                        NumberOfReviewPosts = c.Int(nullable: false),
                        NumberOfLikesRecieved = c.Int(nullable: false),
                        AverageQuanitityOfLeadsTransactiondPerWeek = c.Int(nullable: false),
                        AverageQuanitityOfLeadsTransactiondPerMonth = c.Int(nullable: false),
                        TelemarketerLeads = c.Boolean(nullable: false),
                        TelemarketingLeadNotes = c.String(),
                        MailLeads = c.Boolean(nullable: false),
                        MailLeadLeadNotes = c.String(),
                        Press1Leads = c.Boolean(nullable: false),
                        Press1LeadNotes = c.String(),
                        InternetLeads = c.Boolean(nullable: false),
                        InternetLeadNotes = c.String(),
                        ColdCallPhoneNumberLists = c.Boolean(nullable: false),
                        ColdCallPhoneNumberListLeadNotes = c.String(),
                        Insustry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.InsuranceAgentID)
                .ForeignKey("dbo.Industries", t => t.IndustryID)
                .ForeignKey("dbo.Industries", t => t.Insustry_Id)
                .ForeignKey("dbo.Users", t => t.InsuranceAgentID)
                .Index(t => t.InsuranceAgentID)
                .Index(t => t.IndustryID)
                .Index(t => t.Insustry_Id);
            
            CreateTable(
                "dbo.ReviewPosts",
                c => new
                    {
                        ReviewPostID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        InsuranceAgentID = c.Int(nullable: false),
                        ReviewPostDate = c.DateTime(nullable: false),
                        CompanyRating = c.Int(nullable: false),
                        AgentRating = c.Int(),
                        PostTitle = c.String(),
                        PostBody = c.String(),
                        NumberOfLikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewPostID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .ForeignKey("dbo.InsuranceAgents", t => t.InsuranceAgentID)
                .Index(t => t.CompanyID)
                .Index(t => t.InsuranceAgentID);
            
            CreateTable(
                "dbo.LeadTransactions",
                c => new
                    {
                        LeadTransactionID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        LeadProductID = c.Int(nullable: false),
                        InsuranceAgentProfileID = c.Int(nullable: false),
                        TransactionPrice = c.Int(nullable: false),
                        TransactionNotes = c.String(),
                    })
                .PrimaryKey(t => t.LeadTransactionID)
                .ForeignKey("dbo.InsuranceAgents", t => t.InsuranceAgentProfileID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .ForeignKey("dbo.LeadProducts", t => t.LeadProductID)
                .Index(t => t.CompanyID)
                .Index(t => t.LeadProductID)
                .Index(t => t.InsuranceAgentProfileID);
            
            CreateTable(
                "dbo.LeadProducts",
                c => new
                    {
                        LeadProductID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Price = c.String(),
                        ProductNotes = c.String(),
                        OrderLink = c.String(),
                        TelemarketingLead = c.Boolean(nullable: false),
                        TelemarketingLeadNotes = c.String(),
                        MailLead = c.Boolean(nullable: false),
                        MailLeadLeadNotes = c.String(),
                        Press1Lead = c.Boolean(nullable: false),
                        Press1LeadNotes = c.String(),
                        InternetLead = c.Boolean(nullable: false),
                        InternetLeadNotes = c.String(),
                        ColdCallPhoneNumberList = c.Boolean(nullable: false),
                        ColdCallPhoneNumberListLeadNotes = c.String(),
                    })
                .PrimaryKey(t => t.LeadProductID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        ResetEmail = c.String(),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        AccountType = c.String(),
                        Industry = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalLogins",
                c => new
                    {
                        ExternalLoginID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.ExternalLoginID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "IndustryID", "dbo.Industries");
            DropForeignKey("dbo.InsuranceAgents", "InsuranceAgentID", "dbo.Users");
            DropForeignKey("dbo.ExternalLogins", "UserID", "dbo.Users");
            DropForeignKey("dbo.Companies", "CompanyID", "dbo.Users");
            DropForeignKey("dbo.LeadTransactions", "LeadProductID", "dbo.LeadProducts");
            DropForeignKey("dbo.LeadProducts", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.LeadTransactions", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.LeadTransactions", "InsuranceAgentProfileID", "dbo.InsuranceAgents");
            DropForeignKey("dbo.ReviewPosts", "InsuranceAgentID", "dbo.InsuranceAgents");
            DropForeignKey("dbo.ReviewPosts", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Comments", "ReviewID", "dbo.ReviewPosts");
            DropForeignKey("dbo.InsuranceAgents", "Insustry_Id", "dbo.Industries");
            DropForeignKey("dbo.InsuranceAgents", "IndustryID", "dbo.Industries");
            DropForeignKey("dbo.Comments", "InsuranceAgentProfileID", "dbo.InsuranceAgents");
            DropForeignKey("dbo.Comments", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Comments", "ParentCommentID", "dbo.Comments");
            DropIndex("dbo.ExternalLogins", new[] { "UserID" });
            DropIndex("dbo.LeadProducts", new[] { "CompanyID" });
            DropIndex("dbo.LeadTransactions", new[] { "InsuranceAgentProfileID" });
            DropIndex("dbo.LeadTransactions", new[] { "LeadProductID" });
            DropIndex("dbo.LeadTransactions", new[] { "CompanyID" });
            DropIndex("dbo.ReviewPosts", new[] { "InsuranceAgentID" });
            DropIndex("dbo.ReviewPosts", new[] { "CompanyID" });
            DropIndex("dbo.InsuranceAgents", new[] { "Insustry_Id" });
            DropIndex("dbo.InsuranceAgents", new[] { "IndustryID" });
            DropIndex("dbo.InsuranceAgents", new[] { "InsuranceAgentID" });
            DropIndex("dbo.Companies", new[] { "IndustryID" });
            DropIndex("dbo.Companies", new[] { "CompanyID" });
            DropIndex("dbo.Comments", new[] { "CompanyID" });
            DropIndex("dbo.Comments", new[] { "InsuranceAgentProfileID" });
            DropIndex("dbo.Comments", new[] { "ReviewID" });
            DropIndex("dbo.Comments", new[] { "ParentCommentID" });
            DropTable("dbo.ExternalLogins");
            DropTable("dbo.Users");
            DropTable("dbo.LeadProducts");
            DropTable("dbo.LeadTransactions");
            DropTable("dbo.ReviewPosts");
            DropTable("dbo.InsuranceAgents");
            DropTable("dbo.Industries");
            DropTable("dbo.Companies");
            DropTable("dbo.Comments");
        }
    }
}
