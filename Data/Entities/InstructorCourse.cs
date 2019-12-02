namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InstructorCourse")]
    public partial class InstructorCourse
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Instructor_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Course_Id { get; set; }

        [StringLength(2)]
        public string Evaluation { get; set; }

        public virtual Course Course { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
