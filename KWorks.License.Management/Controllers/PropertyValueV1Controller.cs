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
    public class PropertyValueV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public PropertyValueV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: PropertyValueV1
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.PropertyValueV1.ToListAsync());
        //}


        //public async Task<IActionResult> Index(int? id)
        //{
        //    //if(id != null)
        //    //    return View(await _context.PropertyValueV1.Where(m => m.PropertyId == id).ToListAsync());
        //    //else
        //        return View(await _context.PropertyValueV1.ToListAsync());
        //}

        public async Task<IActionResult> Index(int? id)
        {
            //if(id != null)
            //    return View(await _context.PropertyValueV1.Where(m => m.PropertyId == id).ToListAsync());
            //else
            //return View(await _context.PropertyValueV1.ToListAsync());

   
            var models = new List<PropertyValueV1>();

            if (id != null)
                models = await _context.PropertyValueV1.Where(m => m.PropertyId == id && !m.IsDeleted).OrderByDescending(m => m.ModifiedDate).ToListAsync();
            else
                models = await _context.PropertyValueV1.Where(m => !m.IsDeleted).ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: PropertyValueV1/GetOrganization
        public async Task<IActionResult> GetOrganization()
        {
            var models = await _context.PropertyValueV1
                        .Where(z => z.PropertyId == 1)
                        .Where(z => !z.IsDeleted)
                        .OrderBy(z => z.ModifiedDate)
                        .ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: PropertyValueV1/GetPosition
        public async Task<IActionResult> GetPosition()
        {
            var models = await _context.PropertyValueV1
                               .Where(z => z.PropertyId == 2)
                               .Where(z => !z.IsDeleted)
                               .OrderBy(z => z.ModifiedDate)
                               .ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: PropertyValueV1/GetProgram
        public async Task<IActionResult> GetProgram()
        {
            var models = await _context.PropertyValueV1
                        .Where(z => z.PropertyId == 3)
                        .Where(z => !z.IsDeleted)
                        .OrderBy(z => z.ModifiedDate)
                        .ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: PropertyValueV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyValueV1 = await _context.PropertyValueV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyValueV1 == null)
            {
                return NotFound();
            }

            return View(propertyValueV1);
        }

        // GET: PropertyValueV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyValueV1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PropertyId,Text,Value,Remark")] PropertyValueV1 propertyValueV1)
        {
            try
            {
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                propertyValueV1.Id = 0;
                propertyValueV1.IsDeleted = false;
                propertyValueV1.CreatorId = sessionId;
                propertyValueV1.CreatedDate = DateTime.Now;
                propertyValueV1.ModifierId = sessionId;
                propertyValueV1.ModifiedDate = DateTime.Now;

                _context.Add(propertyValueV1);
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

        // GET: PropertyValueV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyValueV1 = await _context.PropertyValueV1.FindAsync(id);
            if (propertyValueV1 == null)
            {
                return NotFound();
            }
            return View(propertyValueV1);
        }

        // POST: PropertyValueV1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,PropertyId,Text,Value,Remark")] PropertyValueV1 propertyValueV1)
        {
            if (id != propertyValueV1.Id)
            {
                return NotFound();
            }

            try
            {
                var me = await _context.PropertyValueV1.FirstOrDefaultAsync(m => m.Id == propertyValueV1.Id);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true
                    });
                }

                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                me.Text = propertyValueV1.Text;
                me.Value = propertyValueV1.Value;
                me.Remark = propertyValueV1.Remark;
                me.ModifierId = sessionId;
                me.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyValueV1Exists(propertyValueV1.Id))
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

        // GET: PropertyValueV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var me = await _context.PropertyValueV1.FirstOrDefaultAsync(m => m.Id == id);

            if (me == null)
            {
                return Json(new
                {
                    success = true
                });
            }

            me.IsDeleted =true;
            me.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }

        // POST: PropertyValueV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyValueV1 = await _context.PropertyValueV1.FindAsync(id);
            _context.PropertyValueV1.Remove(propertyValueV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyValueV1Exists(int id)
        {
            return _context.PropertyValueV1.Any(e => e.Id == id);
        }
    }
}
