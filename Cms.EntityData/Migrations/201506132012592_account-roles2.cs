namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountroles2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleAccounts",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Account_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Account_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.RoleAccounts", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleAccounts", new[] { "Account_Id" });
            DropIndex("dbo.RoleAccounts", new[] { "Role_Id" });
            DropTable("dbo.RoleAccounts");
        }
    }
}
