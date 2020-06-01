using TransportCompany.Driver.Application.Dto;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Driver.Application.Query
{
    public sealed class DriversQuery : PageableQuery, IQuery<PaginatedList<DriversQueryDto>>
    {
    }
}
