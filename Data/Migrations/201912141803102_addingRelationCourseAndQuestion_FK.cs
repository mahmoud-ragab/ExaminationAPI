namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingRelationCourseAndQuestion_FK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Question", "CoursedId");
            AddForeignKey("dbo.Question", "CoursedId", "dbo.Course", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "CoursedId", "dbo.Course");
            DropIndex("dbo.Question", new[] { "CoursedId" });
        }
    }
}
