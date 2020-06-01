using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseController
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<PaginatedList<CustomersQueryDto>> GetCustomers([FromQuery] CustomersQuery query)
            => await Mediator.Send(query);

        [HttpGet("{id}")]
        public async Task<CustomerDetailsQueryDto> GetCustomerDetails(int id, [FromQuery] CustomerDetailsQuery query)
        {
            query.SetId(id);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}/photo")]
        public async Task<CustomerPhotoQueryDto> GetCustomerPhoto(int id, [FromQuery] CustomerPhotoQuery query)
        {
            query.SetId(id);
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task CreateCustomer([FromBody] CreateCustomerCommand command)
            => await Mediator.Send(command);

        [HttpPut("{id}")]
        public async Task UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCustomer(int id, [FromBody] DeleteCustomerCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }

        [HttpPut("{id}/photo")]
        public async Task UploadCustomerPhoto(int id, [FromBody] UploadCustomerPhotoCommand command)
        {
            command.SetId(id);
            await Mediator.Send(command);
        }
    }
}