using Demo.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.ServiceRequest.Commands.DeleteRequest
{
    public class DeleteServiceRequestCommandHandler : IRequestHandler<DeleteServiceRequestCommand>
    {
        private readonly IOIGDbContext _context;
        private readonly ILogger<DeleteServiceRequestCommandHandler> _logger;

        public DeleteServiceRequestCommandHandler(IOIGDbContext context, ILogger<DeleteServiceRequestCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteServiceRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                    var entity = await _context.ServiceRequest.FindAsync(request.RequestId);

                    if (entity != null)
                    {
                        entity.RequestId = request.RequestId;
                        entity.IsDeleted = true;
                        _logger.LogInformation("----- soft deleting service request", entity);

                        await _context.SaveChangesAsync(cancellationToken);
                        
                    }

                    return Unit.Value;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error while soft deleting service request : ", ex.Message);
                throw ex;
            }
        }

    }
}
