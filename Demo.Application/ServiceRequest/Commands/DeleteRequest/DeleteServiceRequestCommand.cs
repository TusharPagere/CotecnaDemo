using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Commands.DeleteRequest
{
    public class DeleteServiceRequestCommand : IRequest
    {
        public Guid RequestId { get; set; }
    }
}
