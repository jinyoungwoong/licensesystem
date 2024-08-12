using KWorks.License.Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class UserV1
    {
        [Key]
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public int PositionId { get; set; }
        public bool IsAdmin { get; set; }
        public bool FirstSubscriber { get; set; }
        public string Remark { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd HH:mm:ss}")]
        public DateTime ModifiedDate { get; set; }
        //
        public PropertyValueV1 Organizations { get; set; }
        public PropertyValueV1 Positions { get; set; }

        //public ICollection<AcceptanceV2> Acceptances { get; set; }

        public async Task<UserV1> SignInAsync(KWorksLicenseManagementContext _context, string id, string pw)
        {

            var db = _context;

            var me = await db.UserV1
                    .Include(m => m.Positions)
                    .FirstOrDefaultAsync(m => m.LoginId == id && m.Password == pw);

            return  me;
        }


    }
}
