using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Queries.GetServiceData
{
    public class GetCustomerRequestListQuery : IRequest<CustomerRequestVm>
    {
    }
}
