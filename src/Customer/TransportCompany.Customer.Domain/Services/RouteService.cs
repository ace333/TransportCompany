using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Services
{
    public class RouteService : IRouteService
    {
        public void ChangeRouteProperties(Route route, Address startPoint = null, Address destination = null)
        {
            route.StartPoint = startPoint ?? route.StartPoint;
            route.Destination = destination ?? route.Destination;
        }

        public Route CreateRoute(Address startPoint, Address destination)
            => new Route(startPoint, destination);

        public Route GetRouteByStartPoint(IEnumerable<Route> routes, Address startPoint)
            => routes.SingleOrDefault(x => x.StartPoint == startPoint);
    }
}
