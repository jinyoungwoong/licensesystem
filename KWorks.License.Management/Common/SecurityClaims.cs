using KWorks.License.Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KWorks.License.Management.Common
{
    public class SecurityClaims : Controller
    {
        //Claim
        public static IList<Claim> BuildClaims(UserV1 user)
        {
            //Role 부여
            var roles = "User";
            if (user.IsAdmin)
                roles = "Admin";
            else
                roles = user.FirstSubscriber ? "Manager" : "User";

            //Cliam 생성
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, $"{user.Id}"),
                new Claim(ClaimTypes.Role, roles),
                new Claim("Id", $"{user.Id}"),
                new Claim("Name", user.Name),
                new Claim("PositionName", user.Positions.Value)
            };

            return claims;
        }

        //
        public static string GetCookieUserId(HttpContext context)
        {
            return context.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
        }

        public static string GetCookieUserName(HttpContext context)
        {
            return context.User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
        }

        public static string GetCookieUserPositionName(HttpContext context)
        {
            return context.User.Claims.FirstOrDefault(c => c.Type == "PositionName").Value;
        }
    }
}
