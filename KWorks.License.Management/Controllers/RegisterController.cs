using KWorks.License.Management.Data;
using KWorks.License.Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Controllers
{
    [Produces("application/json")]
    public class RegisterController : Controller
    {
        private readonly KWorksLicenseManagementContext _context;

        public RegisterController(KWorksLicenseManagementContext context)
        {
            _context = context;
        }

        //POST: LicenseV1/Resister
        [HttpPost]
        public async Task<IActionResult> Index(
            string id = "",
            string macId = "",
            string externalIP = "",
            string internalIP = "",
            string serial = "",
            string pcUserName = "",
            string pcDeviceName = "")
        {
            try
            {
                var license = id;

                //#오류1.라이선스 미입력 오류
                if (license == null || license == string.Empty)
                {
                    return Ok(new { success = false, message = "라이선스 정보를 입력하시기 바랍니다.", machineCnt = 0 });
                    //return Json(new { success = false, message = "라이선스 정보를 입력하시기 바랍니다." });
                }

                //라이선스 공백제거
                license = license.Trim();

                //라이선스 입력 시 데이터 조회
                var entitiy = await _context.LicenseV1
                                    .Include(z => z.Devices)
                                    .Where(m => m.LicenseKey == license)
                                    .ToListAsync();

                //#오류2.라이선스 미존재 오류
                if (entitiy.Count == 0)
                    return Ok(new { success = false, message = "존재하지 않는 라이선스 입니다.", machineCnt = 0 });

                //#오류3.현재 사용 불가능 라이선스 오류 (IsEnabled = False)
                if (!entitiy.FirstOrDefault().IsEnabled)
                    return Ok(new { success = false, message = "사용 할 수 없는 라이선스 입니다.", machineCnt = 0 });

                //#오류4. 등록된 라이선스이며 추가로 다른 MacID 등록 오류
                //기존 MacID 일 경우 해당 오류문에 포함되지 않음
                if (entitiy.FirstOrDefault().IsAccess)
                {
                    var originRegisterMacId = entitiy.FirstOrDefault().Devices.OrderBy(z => z.Id).Last().MacAddress;
                    if (originRegisterMacId != macId)
                        return Ok(new { success = false, message = "이미 등록 된 라이선스 입니다.", machineCnt = 0 });
                }

                //디바이스 등록
                var deviceV1 = new DeviceV1();
                deviceV1.LicenseId = entitiy.FirstOrDefault().Id;
                deviceV1.CompanyId = entitiy.FirstOrDefault().CompanyId;
                deviceV1.MacAddress = macId;
                deviceV1.ExternalIpAddress = externalIP;
                deviceV1.InternalIpAddress = internalIP;
                deviceV1.SerialNo = serial;
                deviceV1.PC_UserName = pcUserName;
                deviceV1.PC_DeviceName = pcDeviceName;
                await deviceV1.CreateAsync(_context);

                //라이런스 사용처리
                var licneseV1 = new LicenseV1();
                licneseV1.Id = entitiy.FirstOrDefault().Id;
                await licneseV1.RegisterAsync(_context);

                //설비모니터링(서버) 라이선스 체크 후 설비보유수량 전달
                if(entitiy.FirstOrDefault().ProgramId == 20)
                    return Ok(new { success = true, message = "라이선스가 정상 등록되었습니다.", machineCnt = entitiy.FirstOrDefault().MachineCnt });

                //
                return Ok(new { success = true, message = "라이선스가 정상 등록되었습니다.", machineCnt = 0 });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message, machineCnt = 0 });
            }
        }
    }
}
