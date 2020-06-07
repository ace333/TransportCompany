using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Services
{
    public interface IRouteService: IDomainService
    {
        Route CreateRoute(Address destination, Route previousRoute = null);
    }
}
