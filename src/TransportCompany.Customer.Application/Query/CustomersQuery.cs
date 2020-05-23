using System.Threading.Tasks;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Application.Query
{
    public class CustomersQuery: PageableQuery, IQuery<PaginatedList<CustomersQueryDto>>
    {
    }
}
