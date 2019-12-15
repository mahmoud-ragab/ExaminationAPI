using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
  public  class ExamReport
    {

        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int Exam_Id { get; set; }
        public int CorrectAnswerID { get; set; }
        public string CorrectAnswer { get; set; }
        public int StudentAnswerID { get; set; }
        public string StudentAnswer { get; set; }
        public string Result { get; set; }
        public string studentName { get; set; }
        public string studentAddress { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string TopicName { get; set; }
    }
}
