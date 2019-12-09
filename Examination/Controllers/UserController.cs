using Examination.Authorization;
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
    public class UserController : ApiController
    {
        private UserService userService = new UserService();

        [HttpPut]
        public IHttpActionResult Register(RegisterModel registerModel)
        {
            var user = userService.Register(registerModel.UserName, registerModel.Email, registerModel.Password, registerModel.Type);
            if (user != null)
                return Created("user", user);
            else
                return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult Login([FromUri]LoginModel loginModel)
        {
            var user = userService.Login(loginModel.Email, loginModel.Password);
            if (user != null)
                return Ok(user);
            else
                return Content(HttpStatusCode.NoContent, loginModel);
        }
    }
}
