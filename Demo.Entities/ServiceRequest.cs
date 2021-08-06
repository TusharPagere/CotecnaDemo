using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Entities
{
    public class ServiceRequest
    {
        [Key]
        public Guid RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public Boolean IsDeleted { get; set; }
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
