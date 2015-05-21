namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitychangedae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntityChanges", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EntityChanges", "Date");
        }
    }
}
