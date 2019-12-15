using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination.Models.ResponseModels
{
    public class ExamModel
    {
        public int Exam_id;
        public List<QuestionAnswersModel> Questions;
       

    }
}