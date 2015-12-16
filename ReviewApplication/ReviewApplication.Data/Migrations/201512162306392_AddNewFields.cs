namespace ReviewApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Companies", "IndustryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "IndustryID", c => c.Int(nullable: false));
        }
    }
}
