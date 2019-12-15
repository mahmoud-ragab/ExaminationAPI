using Data.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Repositories
{
   public class Solving_ExamRepository
    {
        public ExaminationContext examinationContext;
     
        public Solving_ExamRepository()
        {
            examinationContext = new ExaminationContext();
        }

        public Exam GetExam(int id)
        {
            //var Exam_id = new SqlParameter("@Exam_ID", id);
            // var Exam = examinationContext.Database.SqlQuery<Exam>("sp_GetExambyId @Exam_ID", Exam_id).FirstOrDefault();
            //return Exam;

            return examinationContext.Exam.Where(e => e.Id == id).FirstOrDefault();
        }



    }
}
