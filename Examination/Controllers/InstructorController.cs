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
        [Route("api/Instructor/{id}/course/{cid}/exams")]
        public IHttpActionResult GetInstructorExamOfCourse(int id, int cid)
        {
            var exam = InstructorService.GetInstructorExamOFCourse(id, cid);
            var res = exam.Select(e => new
            {
                id = e.Id,
                //students = e.StudentExam.Where(ee=>ee.Exam_Id == id).Select(se=>new { se.Student.Id, se.Student.Name }).ToList()
                students = e.Course.StudentCourse.Select(sc => new { sc.Student.Id, sc.Student.Name }).ToList()
            }).ToList();
            return Ok(res);
        }
        [Route("api/Instructor/{id}/course/{cid}/exam/{eid}/student/{sid}/modelanswer")]
        public IHttpActionResult GetAnswerSheetListOfExam(int eid, int sid)
        {
            var res = InstructorService.GetStudentAnswerSheet(eid, sid);
            var r = res.Select(ii => new
            {
                Questions = new { questionContent = ii.Question.Content, answers = ii.Question.Answers.Select(a => a.Content).ToList(), correctAnswer = ii.Question.CorrectAnswer },
                selectedAnswer = new { asnwerContent = ii.Answer.Content, answerId = ii.Answer_Id }
            });
            return Ok(r);
        }
    }
}
