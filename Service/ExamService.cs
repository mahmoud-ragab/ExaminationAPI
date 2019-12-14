 
using Data.Entities;
using Data.Repositories;
using System.Collections.Generic;
using System.Linq;
 

namespace Service
{
   public class ExamService
    {
        public ExamRepository ExamRepository = new ExamRepository();

        public List<Solved_Exams> GetSlovedExams(int id)
        {
            return ExamRepository.SlovedExams(id).ToList();
        }


        public List<Solved_Exams> GetNotSlovedExams(int id)
        {
            return ExamRepository.NotSlovedExams(id).ToList();
        }
        public int Get_CountOfSolvedExams(int id)
        {
            return ExamRepository.CountOfSolvedExams(id);
        }

        public int Get_CountOfNotSolvedExams(int id)
        {
            return ExamRepository.CountOfNotSolvedExams(id);
        }


        

    }
}
