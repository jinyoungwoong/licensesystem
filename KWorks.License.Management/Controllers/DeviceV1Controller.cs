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

namespace KWorks.License.Management.Controllers
{
    [Authorize]
    public class DeviceV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public DeviceV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: DeviceV1
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceV1.ToListAsync());
        }

        // GET: DeviceV1/GetLicenseDeviceInfo
        public async Task<IActionResult> GetLicenseDeviceInfo(int id)
        {
            var models = await _context.DeviceV1
                               .Where(z => z.LicenseId == id)
                               .Where(z => !z.IsDeleted)
                               .ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: DeviceV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceV1 = await _context.DeviceV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceV1 == null)
            {
                return NotFound();
            }

            return View(deviceV1);
        }

        // GET: DeviceV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceV1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicenseId,CompanyId,MacAddress,ExternalIpAddress,InternalIpAddress,SerialNo,PC_UserName,PC_DeviceName,Remark,IsDeleted,CreatorId,CreatedDate,ModifierId,ModifiedDate")] DeviceV1 deviceV1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceV1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceV1);
        }

        // GET: DeviceV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceV1 = await _context.DeviceV1.FindAsync(id);
            if (deviceV1 == null)
            {
                return NotFound();
            }
            return View(deviceV1);
        }

        // POST: DeviceV1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicenseId,CompanyId,MacAddress,ExternalIpAddress,InternalIpAddress,SerialNo,PC_UserName,PC_DeviceName,Remark,IsDeleted,CreatorId,CreatedDate,ModifierId,ModifiedDate")] DeviceV1 deviceV1)
        {
            if (id != deviceV1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceV1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceV1Exists(deviceV1.Id))
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
            return View(deviceV1);
        }

        // GET: DeviceV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceV1 = await _context.DeviceV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deviceV1 == null)
            {
                return NotFound();
            }

            return View(deviceV1);
        }

        // POST: DeviceV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceV1 = await _context.DeviceV1.FindAsync(id);
            _context.DeviceV1.Remove(deviceV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceV1Exists(int id)
        {
            return _context.DeviceV1.Any(e => e.Id == id);
        }
    }
}
