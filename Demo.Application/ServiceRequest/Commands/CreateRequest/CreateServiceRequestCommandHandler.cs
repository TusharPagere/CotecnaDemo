using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.ServiceRequest.Commands.CreateRequest
{
    public class CreateServiceRequestCommandHandler : IRequestHandler<CreateServiceRequestCommand, Guid>
    {
        private readonly IOIGDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateServiceRequestCommandHandler> _logger;

        public CreateServiceRequestCommandHandler(IOIGDbContext context, IMapper mapper, ILogger<CreateServiceRequestCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateServiceRequestCommand request, CancellationToken cancellationToken)
        {

            Guid externalId = Guid.Empty;
            try
            {
                var servRequest = await _context.ServiceRequest
                .ProjectTo<ServiceRequestDto>(_mapper.ConfigurationProvider)
                .Where(item => !item.IsDeleted)
                .Where(item => item.CustomerId == request.CustomerId)
                .Where(item => item.RequestDate == request.RequestDate)
                .ToListAsync(cancellationToken);

                if(servRequest.Count == 0)
                {
                    var entity = new Demo.Entities.ServiceRequest
                    {
                        RequestId = new Guid(),
                        RequestDate = request.RequestDate,
                        CustomerId = request.CustomerId,
                        Status = request.Status,
                        IsDeleted = false


                    };
                    _logger.LogInformation("----- creating service request", entity);
                    _context.ServiceRequest.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);
                    externalId = entity.RequestId;
                }
                else
                {
                    //externalId = Guid.Empty();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Error while creating service request", ex.Message);
                throw ex;
            }
            return externalId;
        }
    }
}
