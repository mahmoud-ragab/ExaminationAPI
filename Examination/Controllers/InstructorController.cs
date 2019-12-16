using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination.Controllers
{
    public class InstructorController : ApiController
    {
        // GET api/Customer
        [HttpGet]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult GetInstructor(int id)
        {
            return Ok(InstructorService.GetInstructor(id));
        }
        [Route("api/Instructor/{id}/courses")]
        public IHttpActionResult GetInstructorCourses(int id)
        {
            return Ok(InstructorService.GetInstructorCoursesList(id));
        }
        [Route("api/Instructor/{id}/{cid}/exams")]
        public IHttpActionResult GetInstructorExamOfCourse(int id,int cid)
        {
            return Ok(InstructorService.GetInstructorExamOFCourse(id,cid));
        }
        [Route("api/Instructor/{id}/exam/{eid}")]
        public IHttpActionResult GetAnswerSheetListOfExam(int eid)
        {
            return Ok(InstructorService.GetExamAnswerSheets(eid));
        }
    }
}
