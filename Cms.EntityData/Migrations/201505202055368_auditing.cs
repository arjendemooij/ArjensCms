namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auditing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChangeType = c.Int(nullable: false),
                        ColumnName = c.String(nullable: false),
                        ColumnValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntityChanges");
        }
    }
}
