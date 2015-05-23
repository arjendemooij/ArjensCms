namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageDateChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "DateChanged", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "DateChanged");
        }
    }
}
