using KWorks.License.Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWorks.License.Management.Models
{
    public class NoticeV1
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool IsFixed { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifierId { get; set; }
        public DateTime ModifiedDate { get; set; }
        //
        public UserV1 Users { get; set; }
    }
}
