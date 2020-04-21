using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Domain.Services
{
    public class RideService : IRideService
    {
        public void AddRoute(Ride ride, Route route)
        {
            var routeToRecalculate = ride.Routes.SingleOrDefault(x => x.StartPoint == route.StartPoint);
            Fail.IfNull(routeToRecalculate, ride, ride.Id);

            var newRoute = new Route(route.Destination, routeToRecalculate.Destination);
            routeToRecalculate.Destination = route.Destination;

            ride.AddRoute(route);
        }

        public void RemoveRoute(Ride ride, Route routeToDelete)
        {
            var routeWithStartPointChange = ride.Routes
                .SingleOrDefault(x => x.StartPoint == routeToDelete.Destination);

            routeWithStartPointChange.StartPoint = routeToDelete.StartPoint;

            ride.RemoveRoute(routeToDelete);
        }
    }
}
