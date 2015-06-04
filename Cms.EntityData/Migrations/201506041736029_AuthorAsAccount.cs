namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAsAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Author_Id", c => c.Int());
            CreateIndex("dbo.Pages", "Author_Id");
            AddForeignKey("dbo.Pages", "Author_Id", "dbo.Accounts", "Id");
            DropColumn("dbo.Pages", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "Author", c => c.String(nullable: false));
            DropForeignKey("dbo.Pages", "Author_Id", "dbo.Accounts");
            DropIndex("dbo.Pages", new[] { "Author_Id" });
            DropColumn("dbo.Pages", "Author_Id");
        }
    }
}
