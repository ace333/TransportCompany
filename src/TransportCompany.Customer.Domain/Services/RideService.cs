using System.Linq;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Services
{
    public class RideService : IRideService
    {
        private readonly IRouteService _routeService;

        public RideService(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public Ride CreateRide(Money price, int driverId, DriverDetails driverDetails, Address startPoint, Address destination)
        {
            var startRoute = _routeService.CreateRoute(startPoint);
            var destinationRoute = _routeService.CreateRoute(destination, startRoute);
            return new Ride(price, driverId, driverDetails, startRoute, destinationRoute);
        }

        public void AddRoute(Ride ride, Address startPoint, Address destination)
        {
            var routeMatchedByStartPoint = ride.Routes.SingleOrDefault(x => x.DestinationPoint == startPoint);
            var routeToUpdate = ride.Routes.SingleOrDefault(x => x.PreviousRoute == routeMatchedByStartPoint);

            var newRoute = _routeService.CreateRoute(destination, routeMatchedByStartPoint);
            routeToUpdate.PreviousRoute = newRoute;

            ride.AddRoute(newRoute);
        }       

        public Route AddRoute(Ride ride, int previousRouteId, Address destination)
        {
            var previousRoute = ride.Routes.SingleOrDefault(x => x.Id == previousRouteId);
            var routeToUpdate = ride.Routes.SingleOrDefault(x => x.PreviousRoute == previousRoute);

            var newRoute = _routeService.CreateRoute(destination, previousRoute);
            routeToUpdate.PreviousRoute = newRoute;

            ride.AddRoute(newRoute);
            return newRoute;
        }

        public Route RemoveRoute(Ride ride, int routeId)
        {
            var routeToDelete = ride.Routes.SingleOrDefault(x => x.Id == routeId);
            var nextRoute = ride.Routes.SingleOrDefault(x => x.PreviousRoute == routeToDelete);

            nextRoute.PreviousRoute = routeToDelete.PreviousRoute;
            ride.RemoveRoute(routeToDelete);
            return routeToDelete;
        }
    }
}
