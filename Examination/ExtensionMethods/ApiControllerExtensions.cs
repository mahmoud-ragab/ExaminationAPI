using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Service;

namespace Examination.ExtensionMethods
{
    public static class ApiControllerExtensions
    {
        private static UserService userSerivce = new UserService();

        public static int GetUserId(this ApiController api)
        {
            var token = GetHeaderValue(api, "Token");

            var userId = default(int);
            try
            {
                var dbUserId = userSerivce.GetUserIdByToken(token);
                userId = dbUserId;
            }
            catch
            {
                throw;
            }

            return userId;
        }

        private static string GetHeaderValue(this ApiController api, string headerName)
        {
            IEnumerable<string> headerValues;
            var nameFilter = string.Empty;
            if (api.Request.Headers.TryGetValues(headerName, out headerValues))
            {
                return ((string[])headerValues)[0];
            }
            else
            {
                 return string.Empty;
            }
        }

    }
}