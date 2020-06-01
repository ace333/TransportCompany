using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Model;

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

        [HttpGet]
        public async Task<PaginatedList<DriversQueryDto>> GetDrivers([FromQuery] DriversQuery query)
            => await Mediator.Send(query);

        [HttpGet("{id}")]
        public async Task<DriverDetailsQueryDto> GetDriverDetails(int id, [FromQuery] DriverDetailsQuery query)
        {
            query.SetId(id);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}/photo")]
        public async Task<DriverPhotoQueryDto> GetDriverPhoto(int id, [FromQuery] DriverPhotoQuery query)
        {
            query.SetId(id);
            return await Mediator.Send(query);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDriver(int id, [FromBody] DeleteDriverCommand command)
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