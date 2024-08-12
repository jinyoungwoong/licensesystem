using KWorks.License.Management.Common;
using KWorks.License.Management.Data;
using KWorks.License.Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using KWorks.License.Management.Security;

namespace KWorks.License.Management.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public AccountController(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult LogIn(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: AccountV1/SignIn
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(AccountV1 model, string returnUrl)
        {
            try
            {
                //모델 유효성 체크 (Valid)
                if (!ModelState.IsValid)
                {
                    return View();
                }
              
                //사용자 정보 조회
                var entity = new UserV1();
                var account = await entity.SignInAsync(_context, model.LoginId, model.Password);
              
                //사용자정보 조회 결과 및 처리
                if (account != null)
                {
                    var claims = SecurityClaims.BuildClaims(account);
                    var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity));


                    ////CREATE COOKIE:
                    //HttpContext.Response.Cookies.Append("cUserId", account.Id.ToString(), new CookieOptions()
                    //{
                    //    Expires = DateTime.Now.AddDays(5)
                    //});
                    //HttpContext.Response.Cookies.Append("cUserName", account.Name, new CookieOptions()
                    //{
                    //    Expires = DateTime.Now.AddDays(5)
                    //});
                    //HttpContext.Response.Cookies.Append("cPositionName", account.Positions.Value, new CookieOptions()
                    //{
                    //    Expires = DateTime.Now.AddDays(5)
                    //});


                    //GET COOKIE:
                    //string language = HttpContext.Request.Cookies["language"];

                    //DELETE COOKIE:
                    //HttpContext.Response.Cookies.Append("language", "", new CookieOptions()
                    //{
                    //    Expires = DateTime.Now.AddDays(-1)
                    //});


                    return RedirectToLocal(returnUrl);
                    //return RedirectToAction("Index", "Home");
                }

                //ModelState.AddModelError("LoginError", "로그인 정보를 기입하여 주시기 바랍니다.");
                //return View(model);
                //return Content("<script language='javascript' type='text/javascript'> alert('에러다.'); </script>");

                ViewBag.Message = String.Format("로그인 정보가 일치하지 않습니다.");
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Message = String.Format("로그인 정보가 일치하지 않습니다.");
                return View();            
            }
        }

        // POST: Account/LogOut
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                //HttpContext.Response.Cookies.Append("cUserId", "", new CookieOptions()
                //{
                //    Expires = DateTime.Now.AddDays(-1)
                //});
                //HttpContext.Response.Cookies.Append("cUserName", "", new CookieOptions()
                //{
                //    Expires = DateTime.Now.AddDays(-1)
                //});
                //HttpContext.Response.Cookies.Append("cPositionName", "", new CookieOptions()
                //{
                //    Expires = DateTime.Now.AddDays(-1)
                //});

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

     
    }
}
