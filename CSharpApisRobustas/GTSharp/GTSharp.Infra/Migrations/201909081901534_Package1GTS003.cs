namespace GTSharp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Package1GTS003 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "GTSUser");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GTSUser", newName: "User");
        }
    }
}
