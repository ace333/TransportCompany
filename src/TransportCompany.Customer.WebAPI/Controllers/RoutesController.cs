using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Customer.WebApi.Controllers
{
    [Route("api/customers/{customerId}/rides/{rideId}/[controller]")]
    public class RoutesController : BaseController
    {
        public RoutesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task AddRoute(int customerId, int rideId, [FromBody] AddRouteCommand command)
        {
            command.SetArguments(customerId, rideId);
            await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteRoute(int customerId, int rideId, int id, [FromBody] DeleteRouteCommand command)
        {
            command.SetArguments(customerId, rideId);
            command.RouteId = id;

            await Mediator.Send(command);
        }
    }
}
