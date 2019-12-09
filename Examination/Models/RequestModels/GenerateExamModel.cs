using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination.Models.RequestModels
{
    public class GenerateExamModel
    {
        public int courseID { get; set; }
        public int numberOfMCQ { get; set; }
        public int numberOfTRUE_FALSE { get; set; }
    }
}