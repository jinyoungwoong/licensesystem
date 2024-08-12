using KWorks.License.Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class DeviceV1
    {
        public int Id { get; set; }
        public int LicenseId { get; set; }
        public int CompanyId { get; set; }
        public string MacAddress { get; set; }
        public string ExternalIpAddress { get; set; }
        public string InternalIpAddress { get; set; }
        public string SerialNo { get; set; }
        public string PC_UserName { get; set; }
        public string PC_DeviceName { get; set; }
        public string Remark { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }

        internal async Task CreateAsync(KWorksLicenseManagementContext _context)
        {
            var db = _context;

            Remark = "";
            IsDeleted = false;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            CreatorId = 0;
            ModifierId = 0;

            db.Add(this);

            await db.SaveChangesAsync();
        }
    }
}
