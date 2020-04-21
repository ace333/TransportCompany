using TransportCompany.Customer.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.Query
{
    public sealed class CustomerRidesQuery: PageableIdQuery, IQuery<PaginatedList<CustomerRidesQueryDto>>
    {
    }
}
