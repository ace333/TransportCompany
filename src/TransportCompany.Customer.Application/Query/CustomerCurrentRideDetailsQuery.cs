using TransportCompany.Customer.Application.Dto;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.Query
{
    public sealed class CustomerCurrentRideDetailsQuery : IdQuery, IQuery<CustomerCurrentRideDetailsQueryDto>
    {
    }
}
