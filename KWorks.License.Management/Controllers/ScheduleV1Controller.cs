using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KWorks.License.Management.Data;
using KWorks.License.Management.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using KWorks.License.Management.Common;

namespace KWorks.License.Management.Controllers
{
    [Authorize]
    public class ScheduleV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public ScheduleV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }


        // GET: LicenseV1
        public async Task<IActionResult> Index()
        {
            ViewBag.name = SecurityClaims.GetCookieUserName(HttpContext);
            ViewBag.positionName = SecurityClaims.GetCookieUserPositionName(HttpContext);

            return View();

            //var val = await _context.LicenseV1
            //   .Include(z => z.Users)
            //   .Include(z => z.Companyes)
            //   .Include(z => z.Programs)
            //   .OrderBy(z => z.Id)
            //   .ToListAsync();
            //return View(val);

            //return View(await _context.LicenseV1.ToListAsync());
        }


    }
}
