using TransportCompany.Customer.Application.Dto;
using TransportCompany.Customer.Application.Query.Base;
using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Customer.Application.Query
{
    public sealed class CustomerRideDetailsQuery : CustomerBaseQuery, IQuery<CustomerRideDetailsQueryDto>
    {
    }
}
