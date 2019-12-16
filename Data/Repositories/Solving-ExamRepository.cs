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

        public void PostExam(int Exam_id, int Student_id, List<int> Questions_id, List<int> Answers_id)
        {
            var ansSheet = new List<AnswerSheet>();
            for (int i = 0; i < Questions_id.Count; i++)
                ansSheet.Add(new AnswerSheet
                {
                    Question_Id = Questions_id[i],
                    Answer_Id = Answers_id[i]
                });

            examinationContext.StudentExam.Add(new StudentExam
            {
                Exam_Id = Exam_id,
                Student_Id = Student_id,
                AnswerSheet = ansSheet
            });
            examinationContext.SaveChanges();
        }


    }
}
