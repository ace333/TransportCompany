using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Customer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DriversController : BaseController
    {
        public DriversController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task CreateDriver([FromBody] CreateDriverCommand command)
            => await Mediator.Send(command);

        [HttpPost("{id}/rides/accept")]
        public async Task AcceptRideRequest(int id, [FromBody] AcceptRideRequestCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPatch("{id}/rides/cancel")]
        public async Task CancelRide(int id, [FromBody] CancelRideCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDriver(int id, [FromBody] DeleteDriverCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPatch("{id}/rides/finish")]
        public async Task FinishRide(int id, [FromBody] FinishRideCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPatch("{id}/rate")]
        public async Task RateCustomer(int id, [FromBody] RateCustomerCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPatch("{id}/rides")]
        public async Task TakeCustomer(int id, [FromBody] TakeCustomerCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPut("{id}/car")]
        public async Task UpdateCar(int id, [FromBody] UpdateCarCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPut("{id}/company")]
        public async Task UpdateCompanyDetails(int id, [FromBody] UpdateCompanyDetailsCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPut("{id}/license")]
        public async Task UpdateDriversLicense(int id, [FromBody] UpdateDriversLicenseCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task UpdateDriver(int id, [FromBody] UpdateDriverCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPut("{id}/photo")]
        public async Task UpdatePhoto(int id, [FromBody] UploadDriverPhotoCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }
    }
}