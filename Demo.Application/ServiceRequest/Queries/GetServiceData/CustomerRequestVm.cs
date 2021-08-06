using Demo.Application.Common.Mapping;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Queries.GetServiceData
{
    public class CustomerRequestVm : IMapFrom<Customer>
    {
        public IList<CustomerRequestDto> CustomerDetails { get; set; }
    }
}
