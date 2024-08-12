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
using KWorks.License.Management.Security;
using KWorks.License.Management.Common;

namespace KWorks.License.Management.Controllers
{
    [Authorize]
    public class UserV1Controller : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public UserV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: UserV1
        public async Task<IActionResult> Index()
        {
            ViewBag.name = SecurityClaims.GetCookieUserName(HttpContext);
            ViewBag.positionName = SecurityClaims.GetCookieUserPositionName(HttpContext);

            var val = await _context.UserV1
                      .Include(z => z.Organizations)
                      .Include(z => z.Positions)
                      .Where(z => !z.IsDeleted)
                      .OrderBy(z => z.ModifiedDate)
                      .ToListAsync();

            return View(val);
        }


        // GET: PropertyValueV1/GetPosition
        public async Task<IActionResult> GetUser()
        {
            var models = await _context.UserV1
                               .Where(z => !z.IsDeleted)
                               .OrderBy(z => z.Name)
                               .ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: UserV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userV1 = await _context.UserV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userV1 == null)
            {
                return NotFound();
            }

            return View(userV1);
        }

        // GET: UserV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserV1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginId,Password,Name,OrganizationId,PositionId,IsAdmin,Remark")] UserV1 userV1)
        {
            try
            {
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                userV1.Id = 0;
                userV1.FirstSubscriber = true;
                userV1.IsDeleted = false;
                userV1.CreatorId = sessionId;
                userV1.CreatedDate = DateTime.Now;
                userV1.ModifierId = sessionId;
                userV1.ModifiedDate = DateTime.Now;

                _context.Add(userV1);
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

            ////if (ModelState.IsValid)
            ////{
            //_context.Add(userV1);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            ////}

            //return View(userV1);
        }

        // GET: UserV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userV1 = await _context.UserV1.FindAsync(id);
            if (userV1 == null)
            {
                return NotFound();
            }
            return View(userV1);
        }

        // POST: UserV1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind("Id,Password,Name,OrganizationId,PositionId,IsAdmin,Remark")] UserV1 userV1)
        {
            if (id != userV1.Id)
            {
                return NotFound();
            }
      
            try
            {
                var me = await _context.UserV1.FirstOrDefaultAsync(m => m.Id == userV1.Id);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true
                    });
                }
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                me.Password = userV1.Password;
                me.Name = userV1.Name;
                me.OrganizationId = userV1.OrganizationId;
                me.PositionId = userV1.PositionId;
                me.IsAdmin = userV1.IsAdmin;
                me.Remark = userV1.Remark;
                me.ModifierId = sessionId;
                me.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserV1Exists(userV1.Id))
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
    

        // GET: UserV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var me = await _context.UserV1.FirstOrDefaultAsync(m => m.Id == id);

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

        // POST: UserV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userV1 = await _context.UserV1.FindAsync(id);
            _context.UserV1.Remove(userV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserV1Exists(int id)
        {
            return _context.UserV1.Any(e => e.Id == id);
        }

        // GET: UserV1/PasswordChange/pwd/changePwd
        [HttpGet]
        public async Task<IActionResult> PasswordChange(string pwd, string changePwd)
        {
            try
            {
                var sessionId = SecurityClaims.GetCookieUserId(HttpContext);

                if (sessionId.Trim() != "")
                {
                    var me = await _context.UserV1.FirstOrDefaultAsync(m => m.Id == int.Parse(sessionId.Trim()));

                    if (me == null)
                    {
                        return Json(new
                        {
                            success = false,
                            msg = "패스워드 변경중 오류가 발생하였습니다."
                        });
                    }

                    if (me.Password != pwd)
                    {
                        return Json(new
                        {
                            success = false,
                            msg = "기존 패스워드가 일치하지 않습니다."
                        });
                    }

                    me.Password = changePwd;
                    me.ModifiedDate = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return Json(new
                    {
                        success = true,
                        msg = "패스워드가 변경되었습니다."
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        msg = "로그인 정보에 오류가 발생하여 패스워드 변경중 오류가 발생하였습니다."
                    });
                }
            }
            catch (Exception _ex)
            {
                return Json(new
                {
                    success = false,
                    msg = "패스워드 변경중 오류가 발생하였습니다."
                });
            }
        }
    }
}
