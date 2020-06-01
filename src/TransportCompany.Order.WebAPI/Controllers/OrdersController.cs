using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TransportCompany.Order.Application.Dto;
using TransportCompany.Order.Application.Query;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<PaginatedList<OrdersQueryDto>> GetOrders([FromQuery] OrdersQuery query)
            => await Mediator.Send(query);

        [HttpGet("{id}/income")]
        public async Task<FileResult> GetIncomeInvoice(int id, [FromQuery] OrderIncomeInvoiceQuery query)
        {
            query.SetId(id);
            return await Mediator.Send(query);
        }

        [HttpGet("{id}/payment")]
        public async Task<FileResult> GetPaymentInvoice(int id, [FromQuery] OrderPaymentInvoiceQuery query)
        {
            query.SetId(id);
            return await Mediator.Send(query);
        }
    }
}
