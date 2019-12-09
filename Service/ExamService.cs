using Data;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
