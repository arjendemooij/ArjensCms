namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorRequired2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "Author_Id", "dbo.Accounts");
            DropIndex("dbo.Pages", new[] { "Author_Id" });
            AlterColumn("dbo.Pages", "Author_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Pages", "Author_Id");
            AddForeignKey("dbo.Pages", "Author_Id", "dbo.Accounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "Author_Id", "dbo.Accounts");
            DropIndex("dbo.Pages", new[] { "Author_Id" });
            AlterColumn("dbo.Pages", "Author_Id", c => c.Int());
            CreateIndex("dbo.Pages", "Author_Id");
            AddForeignKey("dbo.Pages", "Author_Id", "dbo.Accounts", "Id");
        }
    }
}
