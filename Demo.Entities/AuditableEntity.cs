using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Entities
{
    public class AuditableEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
