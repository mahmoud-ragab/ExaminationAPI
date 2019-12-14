using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination.Controllers
{
    public class DepartmentController : ApiController
    {
        public DepartmentService departmentService = new DepartmentService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var depts = departmentService.GetAll().Select(d => new { Id = d.Id, Name = d.Name });
                return Ok(depts);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
