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
    public class LicenseV1Controller : Controller
    {
        public class NewEvent
        {
            public DateTime OrderDate { get; set; }
            public string UserName { get; set; }
            public string CompanyName { get; set; }
            public string ProgramName { get; set; }
            public DateTime IssuedDate { get; set; }
            public DateTime? RegisterDate { get; set; }
            public int RecycleCount { get; set; }
            public bool IsAccess { get; set; }
        }

        private readonly KWorksLicenseManagementContext _context;

        public LicenseV1Controller(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        // GET: LicenseV1
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.userId = SecurityClaims.GetCookieUserId(HttpContext);
                ViewBag.name = SecurityClaims.GetCookieUserName(HttpContext); 
                ViewBag.positionName = SecurityClaims.GetCookieUserPositionName(HttpContext); 

                var val = await _context.LicenseV1
                               .Include(z => z.Users)
                               .Include(z => z.Companyes)
                               .Include(z => z.Programs)
                               .Where(z => !z.IsDeleted)
                               .OrderByDescending(z => z.ModifiedDate)
                               .ToListAsync();

                return View(val);
            }
            catch (Exception)
            {

                throw;
            }
            //return View(await _context.LicenseV1.ToListAsync());
        }

        // GET: LicenseV1/GetLicenseInfo/id
        public async Task<IActionResult> GetLicenseInfo(int id)
        {
            try
            {
                var models = await _context.LicenseV1
                                   .Include(z => z.Users)
                                   .Include(z => z.Companyes)
                                   .Include(z => z.Programs)
                                   .Where(z => z.Id == id)
                                   .Where(z => !z.IsDeleted)
                                   .FirstOrDefaultAsync();

                return Json(new
                {
                    success = true,
                    items = models
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


        // GET: LicenseV1/GetLicenseInfo/id
        public async Task<IActionResult> GetLicenseEventInfo()
        {
            try
            {
                var models = new List<NewEvent>();

                var entitiy = await _context.LicenseV1
                                   .Include(z => z.Users)
                                   .Include(z => z.Companyes)
                                   .Include(z => z.Programs)
                                   .Include(z => z.Devices)
                                   .Where(z => z.IssuedDate > DateTime.Now.AddDays(-7)
                                               ||
                                               (z.Devices.Where(m => !m.IsDeleted).Count() > 0
                                                 &&
                                                 z.Devices.Where(m => !m.IsDeleted).OrderByDescending(m => m.CreatedDate).FirstOrDefault().CreatedDate > DateTime.Now.AddDays(-7)
                                               )
                                    )
                                   .Where(z => !z.IsDeleted)
                                   .ToListAsync();

                if (entitiy.Count() > 0)
                {
                    foreach (var item in entitiy)
                    {
                        //정렬순서 정의
                        var orderDate = DateTime.Now;
                        var registerDate = DateTime.Now;
                        var chk = true;
                        if (item.IsAccess == false)
                        {
                            //라이선스가 미등록 된 경우
                            orderDate = item.IssuedDate;
                            chk = false;
                        }
                        else
                        {
                            //라이선스가 등록된 경우
                            var tmpRegisterDate = item.Devices.Where(m => !m.IsDeleted).OrderByDescending(m => m.CreatedDate).FirstOrDefault().CreatedDate;
                            registerDate = tmpRegisterDate;

                            if (item.IssuedDate > tmpRegisterDate)
                                orderDate = item.IssuedDate;
                            else
                                orderDate = tmpRegisterDate;
                        }


                        //사용자 / 업체명 / 프로그램타입 / 라잇너스 생성일 / 라이선스 등록일(최신) / 정렬날짜 / 리싸이클 / 등록x미등록

                        models.Add(new NewEvent
                        {
                            OrderDate = orderDate,
                            UserName = item.Users.Name,
                            CompanyName = item.Companyes.Company_Name,
                            ProgramName = item.Programs.Value,
                            IssuedDate = item.IssuedDate,
                            RegisterDate = chk ? registerDate : (DateTime?)null,
                            RecycleCount = item.RecycleCount,
                            IsAccess = item.IsAccess
                        });

                    }
                }

                var result = models.OrderByDescending(m => m.OrderDate).ToArray();

                return Json(new
                {
                    success = true,
                    items = result
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

        // GET: LicenseV1/GetLicenseTotalInfo
        public async Task<IActionResult> GetLicenseTotalInfo()
        {
            try
            {
                var models = new List<object>();

                var entitiy = await _context.LicenseV1
                                   //.Include(z => z.Users)
                                   //.Include(z => z.Companyes)
                                   //.Include(z => z.Programs)
                                   .Where(z => !z.IsDeleted)
                                   .ToListAsync();



                var createCnt = entitiy.Count(); //라이선스 전체 생성 수량
                var registerCnt = entitiy.Where(z => z.IsAccess).Count(); //라이선스 등록 수량
                var nonRegisterCnt = entitiy.Where(z => z.IsEnabled && !z.IsAccess).Count(); //라이선스 미등록 수량
                var enabledCnt = entitiy.Where(z => z.IsEnabled).Count(); //라이선스 활성화 수량

                var disabledPer = GetPercentage(nonRegisterCnt, enabledCnt, 2);
                var enabledPer = System.Math.Round(100 - disabledPer, 2);

                models.Add(new
                {
                    //라이선스 전체 현황
                    createCnt = createCnt,
                    registerCnt = registerCnt,
                    nonRegisterCnt = nonRegisterCnt,
                    enabledCnt = enabledCnt,

                    //파이차트
                    enabledPer = enabledPer,
                    disabledPer = disabledPer
                });

                return Json(new
                {
                    success = true,
                    items = models
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

        // GET: LicenseV1/GetLicenseRegisterMonth/year
        public async Task<IActionResult> GetLicenseRegisterMonth(int year)
        {
            try
            {
                var entitiy = await _context.LicenseV1
                                   .Include(z => z.Devices)
                                   .Where(z => z.IsAccess)
                                   .Where(z => !z.IsDeleted)
                                   .Select(z => z.Devices.Where(m => !m.IsDeleted).OrderByDescending(m => m.CreatedDate).FirstOrDefault())
                                   .Where(z => z.CreatedDate.Year == year)
                                   .ToListAsync();

                int[] models = new int[]{
                    entitiy.Where(z => z.CreatedDate.Month == 1).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 2).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 3).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 4).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 5).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 6).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 7).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 8).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 9).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 10).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 11).Count(),
                    entitiy.Where(z => z.CreatedDate.Month == 12).Count()
                };

                return Json(new
                {
                    success = true,
                    total = entitiy.Count(),
                    items = models
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

        // GET: LicenseV1/CreateKey
        public async Task<IActionResult> CreateKey()
        {
            try
            {
                var guid = Guid.NewGuid().ToString().ToUpper();

                var me = await _context.LicenseV1.FirstOrDefaultAsync(m => m.LicenseKey == guid && !m.IsDeleted);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true,
                        items = guid
                    });
                }
                else
                {
                    await CreateKey();
                }
            }
            catch (Exception)
            {

                throw;
            }
            var models = await _context.UserV1
                               .Where(z => !z.IsDeleted)
                               .ToListAsync();

            return Json(new
            {
                success = true,
                items = models
            });
        }

        // GET: LicenseV1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseV1 = await _context.LicenseV1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licenseV1 == null)
            {
                return NotFound();
            }

            return View(licenseV1);
        }

        // GET: LicenseV1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LicenseV1/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicenseKey,UserId,CompanyId,ProgramId,IsEnabled,MachineCnt,Remark")] LicenseV1 licenseV1)
        {
            try
            {
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                licenseV1.Id = 0;
                licenseV1.IssuedDate = DateTime.Now;
                licenseV1.IsAccess = false;
                licenseV1.IsPerpetualLicense = true;
                licenseV1.DateCountWithIssuedDate = 0;
                licenseV1.LicenseExpireDate = null;
                licenseV1.IsCheckedUseLicense = false;
                licenseV1.RecycleCount = 0;
                licenseV1.IsDeleted = false;
                licenseV1.CreatorId = sessionId;
                licenseV1.CreatedDate = DateTime.Now;
                licenseV1.ModifierId = sessionId;
                licenseV1.ModifiedDate = DateTime.Now;

                _context.Add(licenseV1);
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

        // GET: LicenseV1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseV1 = await _context.LicenseV1.FindAsync(id);
            if (licenseV1 == null)
            {
                return NotFound();
            }
            return View(licenseV1);
        }

        // POST: LicenseV1/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,UserId,CompanyId,ProgramId,IsEnabled,MachineCnt,Remark")] LicenseV1 licenseV1)
        {
            if (id != licenseV1.Id)
            {
                return NotFound();
            }

            try
            {
                var me = await _context.LicenseV1.FirstOrDefaultAsync(m => m.Id == licenseV1.Id);

                if (me == null)
                {
                    return Json(new
                    {
                        success = true
                    });
                }
                var sessionId = int.Parse(SecurityClaims.GetCookieUserId(HttpContext));

                me.UserId = licenseV1.UserId;
                me.CompanyId = licenseV1.CompanyId;
                me.ProgramId = licenseV1.ProgramId;
                me.IsEnabled = licenseV1.IsEnabled;
                me.MachineCnt = licenseV1.MachineCnt;
                me.Remark = licenseV1.Remark;
                me.ModifierId = sessionId;
                me.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenseV1Exists(licenseV1.Id))
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

        // GET: LicenseV1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var me = await _context.LicenseV1.FirstOrDefaultAsync(m => m.Id == id);

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

        // POST: LicenseV1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenseV1 = await _context.LicenseV1.FindAsync(id);
            _context.LicenseV1.Remove(licenseV1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenseV1Exists(int id)
        {
            return _context.LicenseV1.Any(e => e.Id == id);
        }

        private double GetPercentage(double value, double total, int decimalplaces) {
            return System.Math.Round(value * 100 / total, decimalplaces); 
        }
    }
}
