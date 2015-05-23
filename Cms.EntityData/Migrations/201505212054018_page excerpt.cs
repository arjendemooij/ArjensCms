namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pageexcerpt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Excerpt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Excerpt");
        }
    }
}
