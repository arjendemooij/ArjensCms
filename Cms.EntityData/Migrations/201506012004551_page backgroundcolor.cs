namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pagebackgroundcolor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "BackgroundColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "BackgroundColor");
        }
    }
}
