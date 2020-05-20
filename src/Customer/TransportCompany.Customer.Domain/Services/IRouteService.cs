using System.Collections.Generic;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Domain.Services
{
    public interface IRouteService: IDomainService
    {
        Route CreateRoute(Address startPoint, Address destination);
        Route GetRouteByStartPoint(IEnumerable<Route> routes, Address startPoint);
        void ChangeRouteProperties(Route route, Address startPoint = null, Address destination = null);
    }
}
