using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Services
{
    public class RouteService : IRouteService
    {       
        public Route CreateRoute(Address destination, Route previousRoute = null)
            => new Route(destination, previousRoute);
    }
}
