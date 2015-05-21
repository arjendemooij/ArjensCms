namespace Cms.EntityData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accountrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "EmailAdress", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "UserName", c => c.String());
            AlterColumn("dbo.Accounts", "EmailAdress", c => c.String());
        }
    }
}
