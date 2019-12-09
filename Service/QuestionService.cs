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
    public class QuestionService
    {
        public QuestionRepository questionRepository = new QuestionRepository();

        public List<Question> GetAll()
        {
            return questionRepository.GetAll();
        } 
    }
}
