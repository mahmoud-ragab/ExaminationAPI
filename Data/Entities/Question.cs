namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
            AnswerSheet = new HashSet<AnswerSheet>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Content { get; set; }

        public int? Exam_Id { get; set; }

        public int? CorrectAnswer { get; set; }
        [ForeignKey("CorrectAnswer")]
        public virtual Answer Answer { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerSheet> AnswerSheet { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
