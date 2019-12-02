namespace Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnswerSheet")]
    public partial class AnswerSheet
    {
        [Key]
        public int Id { get; set; }

        public int? Student_Exam_Id { get; set; }

        public int? Question_Id { get; set; }

        public int? Answer_Id { get; set; }

        public virtual Answer Answer { get; set; }

        public virtual Question Question { get; set; }

        public virtual StudentExam StudentExam { get; set; }
    }
}
