using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KWorks.License.Management.Data;
using KWorks.License.Management.Models;
using Microsoft.AspNetCore.Authorization;
using KWorks.License.Management.Common;

namespace KWorks.License.Management.Controllers
{
    [Authorize]
    public class CompanyV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public CompanyV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: CompanyV1
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.name = SecurityClaims.GetCookieUserName(HttpContext);
                ViewBag.positionName = SecurityClaims.GetCookieUserPositionName(HttpContext);

                return View(await _context.CompanyV1
                                  .Where(z => !z.IsDeleted)
                                  .OrderByDescending(z => z.ModifiedDate)
                                  .ToListAsync());

            }
            catch (Exception _ex)
            {
                return Json(new
                {
                    success = false
                });
            }
        }


        // GET: CompanyV1C/GetCompany
        public async Task<IActionResult> GetCompany()
        {
            try
            {
                var models = await _context.CompanyV1
                          .Where(z => !z.IsDeleted)
                          .OrderBy(z => z.Company_Name)
                          .ToListAsync();

                return Json(new
                {
                    success = true,
                    items = models
                });
            }
            catch (Exception _ex)
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        // GET: CompanyV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var companyV1 = await _context.CompanyV1
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (companyV1 == null)
                {
                    return NotFound();
                }

                return View(companyV1);

            }
            catch (Exception _ex)
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        // GET: CompanyV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyV1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Company_Name,CEO_Name,Manager_Name,Company_Tel,Manager_Tel,Address,Email,Remark")] CompanyV1 companyV1)
        {
            try
            {
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                companyV1.Id = 0;
                companyV1.IsEnabled = true;
                companyV1.IsDeleted = false;
                companyV1.CreatorId = sessionId;
                companyV1.CreatedDate = DateTime.Now;
                companyV1.ModifierId = sessionId;
                companyV1.ModifiedDate = DateTime.Now;

                _context.Add(companyV1);
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception _ex)
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        // GET: CompanyV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyV1 = await _context.CompanyV1.FindAsync(id);
            if (companyV1 == null)
            {
                return NotFound();
            }
            return View(companyV1);
        }

        // POST: CompanyV1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,Company_Name,CEO_Name,Manager_Name,Company_Tel,Manager_Tel,Address,Email,Remark")] CompanyV1 companyV1)
        {
            if (id != companyV1.Id)
            {
                return NotFound();
            }

            try
            {
                var me = await _context.CompanyV1.FirstOrDefaultAsync(m => m.Id == companyV1.Id);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true
                    });
                }

                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                me.Company_Name = companyV1.Company_Name;
                me.CEO_Name = companyV1.CEO_Name;
                me.Manager_Name = companyV1.Manager_Name;
                me.Company_Tel = companyV1.Company_Tel;
                me.Manager_Tel = companyV1.Manager_Tel;
                me.Address = companyV1.Address;
                me.Email = companyV1.Email;
                me.Remark = companyV1.Remark;
                me.ModifierId = sessionId;
                me.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyV1Exists(companyV1.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Json(new
            {
                success = true
            });
        }

        // GET: CompanyV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var me = await _context.CompanyV1.FirstOrDefaultAsync(m => m.Id == id);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true
                    });
                }

                me.IsDeleted = true;
                me.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        // POST: CompanyV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyV1 = await _context.CompanyV1.FindAsync(id);
            _context.CompanyV1.Remove(companyV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyV1Exists(int id)
        {
            return _context.CompanyV1.Any(e => e.Id == id);
        }
    }
}
