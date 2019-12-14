namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 150),
                        QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.AnswerSheet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Exam_Id = c.Int(),
                        Question_Id = c.Int(),
                        Answer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Question_Id)
                .ForeignKey("dbo.StudentExam", t => t.Student_Exam_Id)
                .ForeignKey("dbo.Answer", t => t.Answer_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Student_Exam_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 150),
                        Exam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.Exam_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topic", t => t.Topic_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.InstructorCourse",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                        Evaluation = c.String(maxLength: 2, fixedLength: true),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Course_Id })
                .ForeignKey("dbo.Instructor", t => t.Instructor_Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(maxLength: 50),
                        Degree = c.String(maxLength: 50),
                        Salary = c.Int(),
                        Dept_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Dept_Id)
                .Index(t => t.Dept_Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Desc = c.String(maxLength: 100),
                        Location = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        Age = c.Short(),
                        Dept_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Dept_id)
                .Index(t => t.Dept_id);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Student_Id })
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.StudentExam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Exam_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .ForeignKey("dbo.Exam", t => t.Exam_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.Answer_Insert",
                p => new
                    {
                        Content = p.String(maxLength: 150),
                        QuestionId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Answer]([Content], [QuestionId])
                      VALUES (@Content, @QuestionId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Answer]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Answer] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Answer_Update",
                p => new
                    {
                        Id = p.Int(),
                        Content = p.String(maxLength: 150),
                        QuestionId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Answer]
                      SET [Content] = @Content, [QuestionId] = @QuestionId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Answer_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Answer]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Question_Insert",
                p => new
                    {
                        Content = p.String(maxLength: 150),
                        Exam_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Question]([Content], [Exam_Id])
                      VALUES (@Content, @Exam_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Question]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Question] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Question_Update",
                p => new
                    {
                        Id = p.Int(),
                        Content = p.String(maxLength: 150),
                        Exam_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Question]
                      SET [Content] = @Content, [Exam_Id] = @Exam_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Question_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Question]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Exam_Insert",
                p => new
                    {
                        Course_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Exam]([Course_Id])
                      VALUES (@Course_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Exam]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Exam] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Exam_Update",
                p => new
                    {
                        Id = p.Int(),
                        Course_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Exam]
                      SET [Course_Id] = @Course_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Exam_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Exam]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Course_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Topic_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Course]([Name], [Topic_Id])
                      VALUES (@Name, @Topic_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Course]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Course] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Course_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50),
                        Topic_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Course]
                      SET [Name] = @Name, [Topic_Id] = @Topic_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Course_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Course]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Instructor_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Degree = p.String(maxLength: 50),
                        Salary = p.Int(),
                        Dept_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Instructor]([Name], [Degree], [Salary], [Dept_Id])
                      VALUES (@Name, @Degree, @Salary, @Dept_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Instructor]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Instructor] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Instructor_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50),
                        Degree = p.String(maxLength: 50),
                        Salary = p.Int(),
                        Dept_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Instructor]
                      SET [Name] = @Name, [Degree] = @Degree, [Salary] = @Salary, [Dept_Id] = @Dept_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Instructor_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Instructor]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Desc = p.String(maxLength: 100),
                        Location = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [dbo].[Department]([Name], [Desc], [Location])
                      VALUES (@Name, @Desc, @Location)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Department]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50),
                        Desc = p.String(maxLength: 100),
                        Location = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [dbo].[Department]
                      SET [Name] = @Name, [Desc] = @Desc, [Location] = @Location
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Department]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Address = p.String(maxLength: 100),
                        Age = p.Short(),
                        Dept_id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Student]([Name], [Address], [Age], [Dept_id])
                      VALUES (@Name, @Address, @Age, @Dept_id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Student]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Student] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50),
                        Address = p.String(maxLength: 100),
                        Age = p.Short(),
                        Dept_id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Student]
                      SET [Name] = @Name, [Address] = @Address, [Age] = @Age, [Dept_id] = @Dept_id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Student_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Student]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Topic_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                    },
                body:
                    @"INSERT [dbo].[Topic]([Name])
                      VALUES (@Name)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Topic]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Topic] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Topic_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 50),
                    },
                body:
                    @"UPDATE [dbo].[Topic]
                      SET [Name] = @Name
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Topic_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Topic]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Topic_Delete");
            DropStoredProcedure("dbo.Topic_Update");
            DropStoredProcedure("dbo.Topic_Insert");
            DropStoredProcedure("dbo.Student_Delete");
            DropStoredProcedure("dbo.Student_Update");
            DropStoredProcedure("dbo.Student_Insert");
            DropStoredProcedure("dbo.Department_Delete");
            DropStoredProcedure("dbo.Department_Update");
            DropStoredProcedure("dbo.Department_Insert");
            DropStoredProcedure("dbo.Instructor_Delete");
            DropStoredProcedure("dbo.Instructor_Update");
            DropStoredProcedure("dbo.Instructor_Insert");
            DropStoredProcedure("dbo.Course_Delete");
            DropStoredProcedure("dbo.Course_Update");
            DropStoredProcedure("dbo.Course_Insert");
            DropStoredProcedure("dbo.Exam_Delete");
            DropStoredProcedure("dbo.Exam_Update");
            DropStoredProcedure("dbo.Exam_Insert");
            DropStoredProcedure("dbo.Question_Delete");
            DropStoredProcedure("dbo.Question_Update");
            DropStoredProcedure("dbo.Question_Insert");
            DropStoredProcedure("dbo.Answer_Delete");
            DropStoredProcedure("dbo.Answer_Update");
            DropStoredProcedure("dbo.Answer_Insert");
            DropForeignKey("dbo.AnswerSheet", "Answer_Id", "dbo.Answer");
            DropForeignKey("dbo.StudentExam", "Exam_Id", "dbo.Exam");
            DropForeignKey("dbo.Question", "Exam_Id", "dbo.Exam");
            DropForeignKey("dbo.Course", "Topic_Id", "dbo.Topic");
            DropForeignKey("dbo.StudentCourse", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.InstructorCourse", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.InstructorCourse", "Instructor_Id", "dbo.Instructor");
            DropForeignKey("dbo.Student", "Dept_id", "dbo.Department");
            DropForeignKey("dbo.StudentExam", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.AnswerSheet", "Student_Exam_Id", "dbo.StudentExam");
            DropForeignKey("dbo.StudentCourse", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.Instructor", "Dept_Id", "dbo.Department");
            DropForeignKey("dbo.Exam", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.AnswerSheet", "Question_Id", "dbo.Question");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropIndex("dbo.AnswerSheet", new[] { "Answer_Id" });
            DropIndex("dbo.StudentExam", new[] { "Exam_Id" });
            DropIndex("dbo.Question", new[] { "Exam_Id" });
            DropIndex("dbo.Course", new[] { "Topic_Id" });
            DropIndex("dbo.StudentCourse", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourse", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourse", new[] { "Instructor_Id" });
            DropIndex("dbo.Student", new[] { "Dept_id" });
            DropIndex("dbo.StudentExam", new[] { "Student_Id" });
            DropIndex("dbo.AnswerSheet", new[] { "Student_Exam_Id" });
            DropIndex("dbo.StudentCourse", new[] { "Student_Id" });
            DropIndex("dbo.Instructor", new[] { "Dept_Id" });
            DropIndex("dbo.Exam", new[] { "Course_Id" });
            DropIndex("dbo.AnswerSheet", new[] { "Question_Id" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.Topic");
            DropTable("dbo.StudentExam");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Student");
            DropTable("dbo.Department");
            DropTable("dbo.Instructor");
            DropTable("dbo.InstructorCourse");
            DropTable("dbo.Course");
            DropTable("dbo.Exam");
            DropTable("dbo.Question");
            DropTable("dbo.AnswerSheet");
            DropTable("dbo.Answer");
        }
    }
}
