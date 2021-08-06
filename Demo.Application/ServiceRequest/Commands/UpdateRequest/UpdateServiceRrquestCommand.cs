using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Commands.UpdateRequest
{
    public class UpdateServiceRrquestCommand : IRequest
    {
        public Guid RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
    }
}
