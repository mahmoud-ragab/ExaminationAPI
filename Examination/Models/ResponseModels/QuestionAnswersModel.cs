using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination.Models
{
    public class QuestionAnswersModel
    {
        public QuestionModel Question { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}