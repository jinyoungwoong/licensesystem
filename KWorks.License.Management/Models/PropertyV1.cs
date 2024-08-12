using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class PropertyV1
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Kind { get; set; }
        public string Remark { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<PropertyValueV1> PropertyValues { get; set; }
    }
}
