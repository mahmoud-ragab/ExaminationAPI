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
    }
}
