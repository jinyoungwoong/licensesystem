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


            //PGSQL EF ���
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
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All); // �ѱ��� ���ڵ��Ǵ� ���� �ذ�
            });

            //������ �������� ó��
            //MSDN - ID ���� ��Ű ���� ���
            //https://docs.microsoft.com/ko-kr/aspnet/core/security/authentication/cookie?view=aspnetcore-6.0
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.Cookie.MaxAge = options.ExpireTimeSpan; // optional
                options.SlidingExpiration = true; //��Ű���� - ���� �Ⱓ�� ���� �̻��� ��û�� ó���� ������ ���ο� ���� �ð����� �� ��Ű�� �����

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
                //options.Cookie.Expiration = TimeSpan.FromSeconds(10); //����ȵ�

                //options.ExpireTimeSpan = TimeSpan.FromSeconds(10); //��Ű�� ����� �ð� ������ �����ϴ� �� > Core 2.0 �̻���� ���� �ȵǰ� �⺻������ 14�� �� Expire �ȴ�.
                options.LoginPath = "Account/LogIn"; //�α����� �ʿ��� �������� ��� �ڵ����� ���𷺼� 
                options.LogoutPath = "Account/LogOut";  //������ ��η� �α׾ƿ�
                options.AccessDeniedPath = "Account/LogIn"; // �������� �źεǾ��� ���� ���
            });


            //services.Configure<WebEncoderOptions>(options =>
            //{
            //    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);  //�ѱ����ڵ�
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

            app.UseAuthentication(); //Ŭ���� ��Ű Ȱ��ȭ

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
