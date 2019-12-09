using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Repositories
{
   public class ExamRepository
    {
        public ExaminationContext examinationContext;
        public ExamRepository()
        {
            examinationContext = new ExaminationContext();
        }

        
        public  IEnumerable<Solved_Exams> SlovedExams(int id)
        {
            var std_id = new SqlParameter("@id", id);

            var data = examinationContext.Database.SqlQuery<Solved_Exams>("sp_sloved_exams @id", std_id).ToList();
         

            return (data);
        }



        public IEnumerable<Solved_Exams> NotSlovedExams(int id)
        {
            var std_id = new SqlParameter("@id", id);

            var data = examinationContext.Database.SqlQuery<Solved_Exams>("sp_Not_sloved_exams @id", std_id).ToList();


            return (data);
        }


        public int CountOfSolvedExams(int id)
        {
            var std_id = new SqlParameter("@id", id);

            var data = examinationContext.Database.SqlQuery<int>("sp_Count_Of_Solved_Exams @id", std_id).FirstOrDefault();


            return (data);
        }

        public int CountOfNotSolvedExams(int id)
        {
            var std_id = new SqlParameter("@id", id);

            int data = examinationContext.Database.SqlQuery<int>("sp_Count_Of_Not_Solved_Exams @id", std_id).FirstOrDefault();


            return (data);
        }





    }
}
