using System;
using System.Collections.Generic;
using Data.Entities;
using Data.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Solving_ExamService
    {
        public static Solving_ExamRepository ExamRepository = new Solving_ExamRepository();
        public static Exam GetExam(int id)
        {
            return ExamRepository.GetExam(id);
        }

        public static void PostExam(int Exam_id, int Student_id, List<int> Questions_id, List<int> Answers_id)
        {
            ExamRepository.PostExam(Exam_id, Student_id, Questions_id, Answers_id);
        }
    }
}
