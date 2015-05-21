namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitychangefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntityChanges", "EntityName", c => c.String(nullable: false));
            DropColumn("dbo.EntityChanges", "ColumnName");
            DropColumn("dbo.EntityChanges", "ColumnValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntityChanges", "ColumnValue", c => c.String(nullable: false));
            AddColumn("dbo.EntityChanges", "ColumnName", c => c.String(nullable: false));
            DropColumn("dbo.EntityChanges", "EntityName");
        }
    }
}
