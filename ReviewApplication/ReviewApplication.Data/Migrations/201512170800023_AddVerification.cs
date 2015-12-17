namespace ReviewApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVerification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Verified", c => c.Boolean(nullable: false));
            AddColumn("dbo.InsuranceAgents", "Verified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InsuranceAgents", "Verified");
            DropColumn("dbo.Companies", "Verified");
        }
    }
}
