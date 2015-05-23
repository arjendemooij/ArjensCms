namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredcontent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Contents", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Contents", c => c.String());
        }
    }
}
