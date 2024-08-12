using KWorks.License.Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class LicenseV1
    {
        public int Id { get; set; }
        public string LicenseKey { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int ProgramId { get; set; }
        public DateTime IssuedDate { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsAccess { get; set; }
        public bool IsPerpetualLicense { get; set; }
        public int? DateCountWithIssuedDate { get; set; }
        public DateTime? LicenseExpireDate { get; set; }
        public bool IsCheckedUseLicense { get; set; }
        public int RecycleCount { get; set; }
        public int MachineCnt { get; set; } //설비보유대수
        public string Remark { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        //
        public UserV1 Users { get; set; }
        public CompanyV1 Companyes { get; set; }
        public PropertyValueV1 Programs { get; set; }
        public ICollection<DeviceV1> Devices { get; set; }

        public async Task RegisterAsync(KWorksLicenseManagementContext _context)
        {
            var db = _context;
            var me = await db.LicenseV1.FirstOrDefaultAsync(m => m.Id == this.Id);
            if (me == null) return;

            me.IsAccess = true;
            me.RecycleCount = me.RecycleCount + 1;
            me.ModifiedDate = DateTime.Now;

            await db.SaveChangesAsync();
        }
    }
}
