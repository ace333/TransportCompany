using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Driver.WebApi.Controllers
{
    [Route("api/drivers/{driverId}/[controller]")]
    public class RidesController : BaseController
    {
        public RidesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<PaginatedList<DriverRidesQueryDto>> GetRides(int driverId, [FromQuery] DriverRidesQuery query)
        {
            query.SetId(driverId);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<DriverRideDetailsQueryDto> GetRideDetails(int driverId, int id,
            [FromQuery] DriverRideDetailsQuery query)
        {
            query.SetArguments(driverId, id);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}/invoice")]
        public async Task<FileResult> GetRideInvoice(int driverId, int id, [FromQuery] DriverRideInvoiceQuery query)
        {
            query.SetArguments(driverId, id);
            return await Mediator.Send(query);
        }

        [HttpPatch("{id}")]
        public async Task TakeCustomer(int driverId, int id, [FromBody] TakeCustomerCommand command)
        {
            command.SetArguments(driverId, id);
            await Mediator.Send(command);
        }

        [HttpPatch("{id}/cancel")]
        public async Task CancelRide(int driverId, int id, [FromBody] CancelRideCommand command)
        {
            command.SetArguments(driverId, id);
            await Mediator.Send(command);
        }

        [HttpPatch("{id}/finish")]
        public async Task FinishRide(int driverId, int id, [FromBody] FinishRideCommand command)
        {
            command.SetArguments(driverId, id);
            await Mediator.Send(command);
        }

        [HttpPost("{id}/rate")]
        public async Task RateCustomer(int driverId, int id, [FromBody] RateCustomerCommand command)
        {
            command.SetArguments(driverId, id);
            await Mediator.Send(command);
        }
    }
}
