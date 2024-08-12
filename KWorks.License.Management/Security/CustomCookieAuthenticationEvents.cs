using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KWorks.License.Management.Security
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        //private readonly IUserRepository _userRepository;

        //public CustomCookieAuthenticationEvents(IUserRepository userRepository)
        //{
        //    // Get the database from registered DI services.
        //    _userRepository = userRepository;
        //}

        public CustomCookieAuthenticationEvents()
        {
            // Get the database from registered DI services.

        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            //추후 사용자정보 변경 시 쿠키 무효화 관련내용..처리
            var userPrincipal = context.Principal;

            if(userPrincipal.Claims.Count() == 0)
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);

            }

            // Look for the LastChanged claim.
            //var lastChanged = (from c in userPrincipal.Claims
            //                   where c.Type == "LastChanged"
            //                   select c.Value).FirstOrDefault();


            //if (string.IsNullOrEmpty(lastChanged) ||
            //    !_userRepository.ValidateLastChanged(lastChanged))
            //{
            //    context.RejectPrincipal();

            //    await context.HttpContext.SignOutAsync(
            //        CookieAuthenticationDefaults.AuthenticationScheme);
            //}
        }
    }
}