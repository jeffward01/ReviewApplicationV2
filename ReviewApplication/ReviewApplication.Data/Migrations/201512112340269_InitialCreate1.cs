namespace ReviewApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Companies", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Industries", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.InsuranceAgents", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReviewPosts", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.LeadTransactions", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.LeadProducts", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExternalLogins", "IsArchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExternalLogins", "IsArchived");
            DropColumn("dbo.Users", "IsArchived");
            DropColumn("dbo.LeadProducts", "IsArchived");
            DropColumn("dbo.LeadTransactions", "IsArchived");
            DropColumn("dbo.ReviewPosts", "IsArchived");
            DropColumn("dbo.InsuranceAgents", "IsArchived");
            DropColumn("dbo.Industries", "IsArchived");
            DropColumn("dbo.Companies", "IsArchived");
            DropColumn("dbo.Comments", "IsArchived");
        }
    }
}
