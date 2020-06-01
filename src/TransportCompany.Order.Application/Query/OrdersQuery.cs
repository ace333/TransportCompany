using TransportCompany.Order.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Order.Application.Query
{
    public sealed class OrdersQuery: PageableQuery, IQuery<PaginatedList<OrdersQueryDto>>
    {
    }
}
