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
    public class PropertyV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public PropertyV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: PropertyV1
        public async Task<IActionResult> Index()
        {
            ViewBag.name = SecurityClaims.GetCookieUserName(HttpContext);
            ViewBag.positionName = SecurityClaims.GetCookieUserPositionName(HttpContext);

            return View(await _context.PropertyV1.Include(m => m.PropertyValues).ToListAsync());
        }

        // GET: PropertyV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyV1 = await _context.PropertyV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyV1 == null)
            {
                return NotFound();
            }

            return View(propertyV1);
        }

        // GET: PropertyV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyV1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Kind,Remark,IsDeleted,CreatorId,CreatedDate,ModifierId,ModifiedDate")] PropertyV1 propertyV1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyV1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyV1);
        }

        // GET: PropertyV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyV1 = await _context.PropertyV1.FindAsync(id);
            if (propertyV1 == null)
            {
                return NotFound();
            }
            return View(propertyV1);
        }

        // POST: PropertyV1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Kind,Remark,IsDeleted,CreatorId,CreatedDate,ModifierId,ModifiedDate")] PropertyV1 propertyV1)
        {
            if (id != propertyV1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyV1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyV1Exists(propertyV1.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(propertyV1);
        }

        // GET: PropertyV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyV1 = await _context.PropertyV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyV1 == null)
            {
                return NotFound();
            }

            return View(propertyV1);
        }

        // POST: PropertyV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyV1 = await _context.PropertyV1.FindAsync(id);
            _context.PropertyV1.Remove(propertyV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyV1Exists(int id)
        {
            return _context.PropertyV1.Any(e => e.Id == id);
        }
    }
}
