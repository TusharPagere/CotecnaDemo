using Demo.Application.ServiceRequest.Commands.CreateRequest;
using Demo.Application.ServiceRequest.Commands.DeleteRequest;
using Demo.Application.ServiceRequest.Commands.UpdateRequest;
using Demo.Application.ServiceRequest.Queries.GetServiceData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
    public class RequestDataController : BaseController
    {
        [HttpGet()]
        public async Task<ActionResult<CustomerRequestVm>> GetDataList()
        {
            var vm = await Mediator.Send(new GetCustomerRequestListQuery());

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateServiceRequest([FromBody] CreateServiceRequestCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> DeleteServiceRequest([FromBody] DeleteServiceRequestCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> UpdateServiceRequest([FromBody] UpdateServiceRrquestCommand command)
        {
            var res = await Mediator.Send(command);

            return Ok(res);
        }
    }
}
