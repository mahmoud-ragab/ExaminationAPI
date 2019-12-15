using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class QuestionRepository
    {
        public ExaminationContext context = new ExaminationContext();

        public List<Question> GetAll()
        {
            return context.Question.ToList();
        }

        public List<Question> GenerateExam_SP(int courseID, int numberOfMCQ, int numberOfTRUE_FALSE , int instructorID)
        {
             var createdExam = context.Database.SqlQuery<Question>(
                "exec genreateExam @courseID, @numberOfMcq, @numberOfTrue_False,@instructorID ",
                new System.Data.SqlClient.SqlParameter("@courseID", courseID),
                new System.Data.SqlClient.SqlParameter("@numberOfMcq", numberOfMCQ),
                new System.Data.SqlClient.SqlParameter("@numberOfTrue_False", numberOfTRUE_FALSE),
                new System.Data.SqlClient.SqlParameter("@instructorID", instructorID)).ToList();
            return createdExam;
        }
    }
}
