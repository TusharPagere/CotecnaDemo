using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Commands.CreateRequest
{
    public class CreateServiceRequestCommand : IRequest<Guid>
    {
       // public Guid RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public Boolean IsDeleted { get; set; }
        public Guid CustomerId { get; set; }
    }
}
