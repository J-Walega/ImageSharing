using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImageSharing.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "username").Value;
        }
    }
}
