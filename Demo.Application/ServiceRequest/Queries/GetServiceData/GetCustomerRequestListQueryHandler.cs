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

namespace Demo.Application.ServiceRequest.Queries.GetServiceData
{
    public class GetCustomerRequestListQueryHandler : IRequestHandler<GetCustomerRequestListQuery, CustomerRequestVm>
    {
        private readonly IOIGDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCustomerRequestListQueryHandler> _logger;


        public GetCustomerRequestListQueryHandler(IOIGDbContext context, IMapper mapper, ILogger<GetCustomerRequestListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerRequestVm> Handle(GetCustomerRequestListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get Request List");

                var data = await _context.Customer
                .ProjectTo<CustomerRequestDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.CustomerName)
                .ToListAsync(cancellationToken);

                var vm = new CustomerRequestVm
                {
                    CustomerDetails = data
                };

                return vm;
            }
            catch (Exception ex)
            {
                _logger.LogError(new Exception(ex.ToString()), "Get Request List");
                throw ex;
            }
        }

            

        }
}
