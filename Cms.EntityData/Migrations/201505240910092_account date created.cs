namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountdatecreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "DateCreated");
        }
    }
}
