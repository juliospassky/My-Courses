namespace GTSharp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Package1GTS001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UK_USER_EMAIL");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", "UK_USER_EMAIL");
            DropTable("dbo.User");
            DropTable("dbo.Platform");
        }
    }
}
