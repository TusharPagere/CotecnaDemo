using AutoMapper;
using Demo.Application.Common.Mapping;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Queries.GetServiceData
{
    public class CustomerRequestDto : IMapFrom<Customer>
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Observations { get; set; }
        public ICollection<Demo.Entities.ServiceRequest> ServiceRequest { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerRequestDto>()
            .ForMember(d => d.ServiceRequest, opt => opt.MapFrom(s => s.ServiceRequest));

        }

    }
}
