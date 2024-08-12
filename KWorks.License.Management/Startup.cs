using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KWorks.License.Management.Data;
using Microsoft.Extensions.WebEncoders;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using KWorks.License.Management.Security;
//using System.Text.Encodings.Web;
//using System.Text.Unicode;

namespace KWorks.License.Management
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        protected virtual void ConfigureMiddleware(IApplicationBuilder builder)
        {
            builder.UseMiddleware<AuthenticationMiddleware>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddDbContext<KWorksLicenseManagementContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("KWorksLicenseManagementContext")));


            //PGSQL EF 사용
            services.AddDbContext<KWorksLicenseManagementContext>(options =>
                     options.UseNpgsql(Configuration.GetConnectionString("KWorksLicenseManagementContext")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.ConsentCookie.IsEssential = true;
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All); // 한글이 인코딩되는 문제 해결
            });

            //페이지 인증권한 처리
            //MSDN - ID 없이 쿠키 인증 사용
            //https://docs.microsoft.com/ko-kr/aspnet/core/security/authentication/cookie?view=aspnetcore-6.0
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.Cookie.MaxAge = options.ExpireTimeSpan; // optional
                options.SlidingExpiration = true; //쿠키갱신 - 만료 기간의 절반 이상인 요청을 처리할 때마다 새로운 만료 시간으로 새 쿠키를 재발행

                //options.EventsType = typeof(CustomCookieAuthenticationEvents);

                //options.Events = new CookieAuthenticationEvents
                //{
                //    // Set other options
                //    OnValidatePrincipal = CustomCookieAuthenticationEvents.ValidatePrincipal
                //};
            });

            //services.AddScoped<CustomCookieAuthenticationEvents>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.Name = "Cookie";
                //options.Cookie.Expiration = TimeSpan.FromSeconds(10); //적용안됨

                //options.ExpireTimeSpan = TimeSpan.FromSeconds(10); //쿠키가 만료될 시간 간격을 지정하는 값 > Core 2.0 이상부터 설정 안되고 기본적으로 14일 후 Expire 된다.
                options.LoginPath = "Account/LogIn"; //로그인이 필요한 페이지의 경우 자동으로 리디렉션 
                options.LogoutPath = "Account/LogOut";  //설정된 경로로 로그아웃
                options.AccessDeniedPath = "Account/LogIn"; // 엑세스가 거부되었을 때의 경로
            });


            //services.Configure<WebEncoderOptions>(options =>
            //{
            //    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);  //한글인코딩
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //클레임 쿠키 활성화

            app.UseAuthorization();

            //ConfigureMiddleware(app);

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "default1",
                  pattern: "{controller}/{action=Index}");

                endpoints.MapControllerRoute(
                  name: "default2",
                  pattern: "{controller=Account}/{action=Login}/{id?}");

                //endpoints.MapControllerRoute(
                //  name: "default3",
                //  pattern: "{controller=Account}/{action=Login}/{id}/{returnUrl}");

                //endpoints.MapControllerRoute(
                //  name: "default2",
                //  pattern: "{controller=Account}/{action=Index}/{model}/{returnUrl?}");

                //endpoints.MapControllerRoute(
                //  name: "default3",
                //  pattern: "{controller=Account}/{action=LogOut}");

                //endpoints.MapControllerRoute(
                //    name: "Hello",
                //    //pattern: "{controller}/{action}/{name}/{id?}");
                //    pattern: "{controller}/{action}/{name}/{numTimes}");

                //endpoints.MapControllerRoute(
                //    name: "Lincense",
                //   //pattern: "{controller}/{action}/{name}/{id?}");
                //   pattern: "{controller=LicenseV1}/{action=Resister}/{id?}/{macId}");
            });
        }
    }
}
