
using Examination.Models;
using Examination.Models.RequestModels;
using Examination.Models.ResponseModels;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Examination.Controllers
{
    public class Solving_ExamController : ApiController
    {


        [HttpGet]
        [Route("api/Exam/{id}")]
        public IHttpActionResult GetExam(int id)
        {
            return Ok(Solving_ExamService.GetExam(id));
        }
        [HttpPost]
        [Route("api/PostExam")]
        public IHttpActionResult PostExam(PostExamModel c)
        {
            Solving_ExamService.PostExam(c.Exam_id, c.Student_id, c.Questions_id, c.Answers_id);
            return Ok();
        }

    }
}