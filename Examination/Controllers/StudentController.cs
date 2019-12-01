using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination.Controllers
{
    public class StudentController : ApiController
    {
        public StudentService studentService = new StudentService();

        // GET api/Customer
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(studentService.GetAll());
        }
    }
}
