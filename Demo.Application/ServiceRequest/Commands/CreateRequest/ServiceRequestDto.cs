using AutoMapper;
using Demo.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.ServiceRequest.Commands.CreateRequest
{
    public class ServiceRequestDto : IMapFrom<Demo.Entities.ServiceRequest>
    {
        public Guid RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public Boolean IsDeleted { get; set; }
        public Guid CustomerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Demo.Entities.ServiceRequest, ServiceRequestDto>();

        }
    }
}
