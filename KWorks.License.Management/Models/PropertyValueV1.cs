using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class PropertyValueV1
    {
        [Key]
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
