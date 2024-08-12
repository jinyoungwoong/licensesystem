//using KWorks.Platform;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;


namespace KWorks.License.Management.Security
{
    public class AuthenticationMiddleware
    {
        //추후 권한 미들웨어 구성..필요..

        private RequestDelegate next;
        private readonly string[] IGNORES = new[] { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".js", ".css", ".swf", ".ico" };

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (!IGNORES.Contains(Path.GetExtension(context.Request.Path.Value).ToLower()))
            //{
            //    try
            //    {
            //        if(!(context.Request.Path.Value == "/" || context.Request.Path.Value.ToUpper() == "/ACCOUNT/"))
            //        {
            //            if (context.User.Claims.Count() == 0)
            //            {
            //                context.Response.StatusCode = 401;
            //                context.Response.Redirect("/account/login");
            //                return;
            //            }
            //            else
            //                await next(context);
            //        }
            //        else
            //        {
            //            await next(context);
            //        }

            //    }
            //    catch (Exception _ex)
            //    {
            //        await next(context);
            //    }
            //}

            await next(context);
        }
    }
}
