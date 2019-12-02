namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcorrectanswertoquestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            AddColumn("dbo.Answer", "Question_Id", c => c.Int());
            AddColumn("dbo.Question", "CorrectAnswer", c => c.Int());
            CreateIndex("dbo.Answer", "Question_Id");
            CreateIndex("dbo.Question", "CorrectAnswer");
            AddForeignKey("dbo.Answer", "Question_Id", "dbo.Question", "Id");
            AddForeignKey("dbo.Question", "CorrectAnswer", "dbo.Answer", "Id");
            DropStoredProcedure("dbo.Answer_Insert");
            DropStoredProcedure("dbo.Answer_Update");
            DropStoredProcedure("dbo.Answer_Delete");
            DropStoredProcedure("dbo.Question_Insert");
            DropStoredProcedure("dbo.Question_Update");
            DropStoredProcedure("dbo.Question_Delete");
            DropStoredProcedure("dbo.Exam_Insert");
            DropStoredProcedure("dbo.Exam_Update");
            DropStoredProcedure("dbo.Exam_Delete");
            DropStoredProcedure("dbo.Course_Insert");
            DropStoredProcedure("dbo.Course_Update");
            DropStoredProcedure("dbo.Course_Delete");
            DropStoredProcedure("dbo.Instructor_Insert");
            DropStoredProcedure("dbo.Instructor_Update");
            DropStoredProcedure("dbo.Instructor_Delete");
            DropStoredProcedure("dbo.Department_Insert");
            DropStoredProcedure("dbo.Department_Update");
            DropStoredProcedure("dbo.Department_Delete");
            DropStoredProcedure("dbo.Student_Insert");
            DropStoredProcedure("dbo.Student_Update");
            DropStoredProcedure("dbo.Student_Delete");
            DropStoredProcedure("dbo.Topic_Insert");
            DropStoredProcedure("dbo.Topic_Update");
            DropStoredProcedure("dbo.Topic_Delete");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "CorrectAnswer", "dbo.Answer");
            DropForeignKey("dbo.Answer", "Question_Id", "dbo.Question");
            DropIndex("dbo.Question", new[] { "CorrectAnswer" });
            DropIndex("dbo.Answer", new[] { "Question_Id" });
            DropColumn("dbo.Question", "CorrectAnswer");
            DropColumn("dbo.Answer", "Question_Id");
            CreateIndex("dbo.Answer", "QuestionId");
            AddForeignKey("dbo.Answer", "QuestionId", "dbo.Question", "Id");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
