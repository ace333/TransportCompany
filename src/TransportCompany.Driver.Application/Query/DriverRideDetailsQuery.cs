using TransportCompany.Driver.Application.Dto;
using TransportCompany.Driver.Application.Query.Base;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Driver.Application.Query
{
    public sealed class DriverRideDetailsQuery : DriverBaseQuery, IQuery<DriverRideDetailsQueryDto>
    {
    }
}
