using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace KWorks.License.Management.Security
{
    public class CheckSession : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var check = context.HttpContext;
            if (check.User.Claims.Count() == 0)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { 
                            Controller = "Account",
                            Action = "Login"
                        }));
            }
        }
    }
}
