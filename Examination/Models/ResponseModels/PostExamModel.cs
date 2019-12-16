using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination.Models.ResponseModels
{
    public class PostExamModel
    {
        public int Exam_id { get; set; }
        public int Student_id { get; set; }
        public List<int> Questions_id { get; set; }
        public List<int> Answers_id { get; set; }
    }
}