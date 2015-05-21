namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitychangefield2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityChangeFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NewValue = c.String(),
                        OldValue = c.String(),
                        EntityChange_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntityChanges", t => t.EntityChange_Id)
                .Index(t => t.EntityChange_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityChangeFields", "EntityChange_Id", "dbo.EntityChanges");
            DropIndex("dbo.EntityChangeFields", new[] { "EntityChange_Id" });
            DropTable("dbo.EntityChangeFields");
        }
    }
}
