namespace GTSharp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Package1GTS002 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Platform", newName: "Plataform");
            AlterColumn("dbo.Plataform", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plataform", "Name", c => c.String(maxLength: 100, unicode: false));
            RenameTable(name: "dbo.Plataform", newName: "Platform");
        }
    }
}
