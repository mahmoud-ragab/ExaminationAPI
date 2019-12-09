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
    }
}
