using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Application.Utils;
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
            var route = _routeService.CreateRoute(startPoint, destination);
            return new Ride(price, driverId, driverDetails, route);
        }

        public void AddRoute(Ride ride, Route route)
        {
            var routeToRecalculate = _routeService.GetRouteByStartPoint(ride.Routes, route.StartPoint);
            Fail.IfNull(routeToRecalculate, ride, ride.Id);

            var newRoute = _routeService.CreateRoute(route.Destination, routeToRecalculate.Destination);
            _routeService.ChangeRouteProperties(routeToRecalculate, destination: route.Destination);

            ride.AddRoute(newRoute);
        }

        public void RemoveRoute(Ride ride, Route routeToDelete)
        {
            var routeWithStartPointChange = _routeService.GetRouteByStartPoint(ride.Routes, routeToDelete.Destination);
            Fail.IfNull(routeWithStartPointChange, ride, ride.Id);

            _routeService.ChangeRouteProperties(routeWithStartPointChange, destination: routeToDelete.StartPoint);
            ride.RemoveRoute(routeToDelete);
        }
    }
}
