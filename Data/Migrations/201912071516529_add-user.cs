namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Type = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Instructor", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "Id");
            CreateIndex("dbo.Instructor", "Id");
            AddForeignKey("dbo.Student", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Instructor", "Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructor", "Id", "dbo.Users");
            DropForeignKey("dbo.Student", "Id", "dbo.Users");
            DropIndex("dbo.Instructor", new[] { "Id" });
            DropIndex("dbo.Student", new[] { "Id" });
            AlterColumn("dbo.Student", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Instructor", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Users");
        }
    }
}
