using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Driver.WebApi.Controllers
{
    [Route("api/drivers/{driverId}/rides/{rideId}/[controller]")]
    public class StopsController : BaseController
    {
        public StopsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<DriverNextStopDetailsQueryDto> GetNextStop(int driverId, int rideId, 
            [FromQuery] DriverNextStopDetailsQuery query)
        {
            query.SetArguments(driverId, rideId);
            return await Mediator.Send(query);
        }

        [HttpPatch("{id}")]
        public async Task UpdateStop(int driverId, int rideId, int id, [FromBody] UpdateStopCommand command)
        {
            command.SetArguments(driverId, rideId);
            command.StopId = id;

            await Mediator.Send(command);
        }
    }
}
