using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Entities
{
    public class Customer
    {
        public Customer()
        {
            ServiceRequest = new HashSet<ServiceRequest>();
        }

        [Key]
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Observations { get; set; }

        public ICollection<ServiceRequest> ServiceRequest { get; set; }
    }
}
