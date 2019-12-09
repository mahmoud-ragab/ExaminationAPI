using Examination.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Examination.Authorization
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                var api = (ApiController)actionContext.ControllerContext.Controller;
                api.GetUserId();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}