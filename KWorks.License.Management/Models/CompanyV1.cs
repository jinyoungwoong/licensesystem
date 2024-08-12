using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class CompanyV1
    {
        public int Id { get; set; }
        public string Company_Name { get; set; }
        public string CEO_Name { get; set; }
        public string Manager_Name { get; set; }
        public string Company_Tel { get; set; }
        public string Manager_Tel { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public string Remark { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
