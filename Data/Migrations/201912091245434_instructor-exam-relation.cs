namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructorexamrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exam", "Instructor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Exam", "Instructor_Id");
            AddForeignKey("dbo.Exam", "Instructor_Id", "dbo.Instructor", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exam", "Instructor_Id", "dbo.Instructor");
            DropIndex("dbo.Exam", new[] { "Instructor_Id" });
            DropColumn("dbo.Exam", "Instructor_Id");
        }
    }
}
