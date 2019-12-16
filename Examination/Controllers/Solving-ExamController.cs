
using Examination.Models;
using Examination.Models.RequestModels;
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
        [Route("api/PostExam/{id}")]
        public void PostExam(Object c)
        {
            var x = c;
            int vb = 1;
            Console.WriteLine("hey");

        }

    }
}