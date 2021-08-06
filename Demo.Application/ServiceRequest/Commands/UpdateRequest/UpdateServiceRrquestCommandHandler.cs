using Demo.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Application.ServiceRequest.Commands.UpdateRequest
{
    public class UpdateServiceRrquestCommandHandler : IRequestHandler<UpdateServiceRrquestCommand>
    {
        private readonly IOIGDbContext _context;
        private readonly ILogger<UpdateServiceRrquestCommandHandler> _logger;

        public UpdateServiceRrquestCommandHandler(IOIGDbContext context, ILogger<UpdateServiceRrquestCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateServiceRrquestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("while updating service request");
                var entity = await _context.ServiceRequest.FindAsync(request.RequestId);

                if (entity != null)
                {
                    entity.RequestId = request.RequestId;
                    entity.RequestDate = request.RequestDate;
                    entity.Status = request.Status;

                    await _context.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while updating service request  : ", ex.Message);
                throw ex;
            }
        }
    }
}
