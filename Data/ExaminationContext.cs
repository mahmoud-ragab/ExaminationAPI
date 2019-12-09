namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Data.Entities;

    public partial class ExaminationContext : DbContext
    {
        public ExaminationContext()
            : base("name=ExaminationContext")
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AnswerSheet> AnswerSheet { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<InstructorCourse> InstructorCourse { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }
        public virtual DbSet<StudentExam> StudentExam { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
            .HasRequired<Instructor>(s => s.instructor)
            .WithMany(g => g.Exams)
            .HasForeignKey<int>(s => s.Instructor_Id)
            .WillCascadeOnDelete();

            modelBuilder.Entity<Answer>()
                .HasMany(e => e.AnswerSheet)
                .WithOptional(e => e.Answer)
                .HasForeignKey(e => e.Answer_Id);
            //modelBuilder.Entity<Answer>().MapToStoredProcedures();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Exam)
                .WithOptional(e => e.Course)
                .HasForeignKey(e => e.Course_Id);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.InstructorCourse)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.Course_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.StudentCourse)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.Course_Id)
                .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Course>().MapToStoredProcedures();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Instructor)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.Dept_Id);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.Dept_id);
            //modelBuilder.Entity<Department>().MapToStoredProcedures();

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.Question)
                .WithOptional(e => e.Exam)
                .HasForeignKey(e => e.Exam_Id);

            modelBuilder.Entity<Exam>()
                .HasMany(e => e.StudentExam)
                .WithOptional(e => e.Exam)
                .HasForeignKey(e => e.Exam_Id);
            //modelBuilder.Entity<Exam>().MapToStoredProcedures();

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.InstructorCourse)
                .WithRequired(e => e.Instructor)
                .HasForeignKey(e => e.Instructor_Id)
                .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Instructor>().MapToStoredProcedures();

            modelBuilder.Entity<InstructorCourse>()
                .Property(e => e.Evaluation)
                .IsFixedLength();

            modelBuilder.Entity<Question>()
                .HasMany(e => e.AnswerSheet)
                .WithOptional(e => e.Question)
                .HasForeignKey(e => e.Question_Id);
            //modelBuilder.Entity<Question>().MapToStoredProcedures();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentCourse)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.Student_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentExam)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.Student_Id);
            //modelBuilder.Entity<Student>().MapToStoredProcedures();

            modelBuilder.Entity<StudentExam>()
                .HasMany(e => e.AnswerSheet)
                .WithOptional(e => e.StudentExam)
                .HasForeignKey(e => e.Student_Exam_Id);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Course)
                .WithOptional(e => e.Topic)
                .HasForeignKey(e => e.Topic_Id);
            //modelBuilder.Entity<Topic>().MapToStoredProcedures();
        }
    }
}
