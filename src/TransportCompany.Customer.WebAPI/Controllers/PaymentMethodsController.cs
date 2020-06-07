using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Customer.WebApi.Controllers
{
    [Route("api/customers/{customerId}/[controller]")]
    public class PaymentMethodsController : BaseController
    {
        public PaymentMethodsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task AddPaymentMethod(int customerId, [FromBody] AddPaymentMethodCommand command)
        {
            command.SetId(customerId);
            await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeletePaymentMethod(int customerId, int id, [FromBody] DeletePaymentMethodCommand command)
        {
            command.SetId(customerId);
            command.PaymentMethodId = id;

            await Mediator.Send(command);
        }

    }
}
