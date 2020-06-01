using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Driver.WebApi.Controllers
{
    [Route("api/drivers/{driverId}/[controller]")]
    public class RideRequestsController : BaseController
    {
        public RideRequestsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPatch("{id}")]
        public async Task AcceptRideRequest(int driverId, int id, [FromBody] AcceptRideRequestCommand command)
        {
            command.SetArguments(driverId, id);
            await Mediator.Send(command);
        }
    }
}
