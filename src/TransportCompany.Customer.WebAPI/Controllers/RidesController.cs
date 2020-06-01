using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.WebApi.Controllers
{
    [Route("api/customers/{customerId}/[controller]")]
    public class RidesController : BaseController
    {
        public RidesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task RequestRide(int customerId, [FromBody] RequestRideCommand command)
        {
            command.SetId(customerId);
            await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<PaginatedList<CustomerRidesQueryDto>> GetCustomerRides(int customerId, 
            [FromQuery] CustomerRidesQuery query)
        {
            query.SetId(customerId);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<CustomerRideDetailsQueryDto> GetCustomerRideDetails(int customerId, int id,
            [FromQuery] CustomerRideDetailsQuery query)
        {
            query.SetArguments(customerId, id);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}/invoice")]
        public async Task<FileResult> GetCustomerRideInvoice(int customerId, int id, [FromQuery] CustomerRideInvoiceQuery query)
        {
            query.SetArguments(customerId, id);
            return await Mediator.Send(query);
        }

        [HttpPatch("{id}/cancel")]
        public async Task CancelCurrentRide(int customerId, int id, [FromBody] CancelRideCommand command)
        {
            command.SetArguments(customerId, id);
            await Mediator.Send(command);
        }

        [HttpPost("{id}/route")]
        public async Task AddRoute(int customerId, int id, [FromBody] AddRouteCommand command)
        {
            command.SetArguments(customerId, id);
            await Mediator.Send(command);
        }

        [HttpDelete("{id}/route")]
        public async Task DeleteRoute(int customerId, int id, [FromBody] DeleteRouteCommand command)
        {
            command.SetArguments(customerId, id);
            await Mediator.Send(command);
        }

        [HttpPost("{id}/rate")]
        public async Task RateDriver(int customerId, int id, [FromBody] RateDriverCommand command)
        {
            command.SetArguments(customerId, id);
            await Mediator.Send(command);
        }
    }
}
