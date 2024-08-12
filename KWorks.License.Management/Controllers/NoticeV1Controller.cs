using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KWorks.License.Management.Data;
using KWorks.License.Management.Models;
using KWorks.License.Management.Common;

namespace KWorks.License.Management.Controllers
{
    public class NoticeV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public NoticeV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: NoticeV1
        public async Task<IActionResult> Index()
        {
            var entity = await _context.NoticeV1
                        .Include(m => m.Users)
                        .Where(m => !m.IsDeleted)
                        .OrderByDescending(m => m.IsFixed)
                        .ThenByDescending(m => m.ModifiedDate)
                        //.OrderByDescending(m => m.ModifiedDate)
                        .ToListAsync();

            return Json(new
            {
                success = true,
                items = entity
            });
        }

        // GET: NoticeV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeV1 = await _context.NoticeV1
                .FirstOrDefaultAsync(m => m.Id == id);

            if (noticeV1 == null)
            {
                return NotFound();
            }

            return View(noticeV1);
        }

        // GET: NoticeV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NoticeV1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Contents,IsFixed")] NoticeV1 noticeV1)
        {
            try
            {
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));  

                noticeV1.Id = 0;
                noticeV1.IsDeleted = false;
                noticeV1.CreatorId = sessionId;
                noticeV1.CreatedDate = DateTime.Now;
                noticeV1.ModifierId = sessionId;
                noticeV1.ModifiedDate = DateTime.Now;

                _context.Add(noticeV1);
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

        // GET: NoticeV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticeV1 = await _context.NoticeV1.FindAsync(id);
            if (noticeV1 == null)
            {
                return NotFound();
            }
            return View(noticeV1);
        }

        // POST: NoticeV1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,Title,Contents,IsFixed")] NoticeV1 noticeV1)
        {
            if (id != noticeV1.Id)
            {
                return NotFound();
            }

            try
            {
                var me = await _context.NoticeV1.FirstOrDefaultAsync(m => m.Id == noticeV1.Id);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true
                    });
                }

                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                me.Title = noticeV1.Title;
                me.Contents = noticeV1.Contents;
                me.IsFixed = noticeV1.IsFixed;
                me.ModifierId = sessionId;
                me.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeV1Exists(noticeV1.Id))
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

        // GET: NoticeV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var me = await _context.NoticeV1.FirstOrDefaultAsync(m => m.Id == id);

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

        // POST: NoticeV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticeV1 = await _context.NoticeV1.FindAsync(id);
            _context.NoticeV1.Remove(noticeV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeV1Exists(int id)
        {
            return _context.NoticeV1.Any(e => e.Id == id);
        }
    }
}
