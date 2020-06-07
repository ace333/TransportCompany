using System.Linq;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public class RideService : IRideService
    {
        private const decimal DriverIncomeFromSingleRidePercent = 0.40M;
        private readonly IDestinationPointService _destinationPointService;

        public RideService(IDestinationPointService destinationPointService)
        {
            _destinationPointService = destinationPointService;
        }

        public Ride CreateNewRide(Address startPoint, Address destinationPoint, Money income,
            int customerId, CustomerDetails customerDetails)
        {
            var start = new DestinationPoint(PointStatus.OnTheWay, startPoint);
            var destination = new DestinationPoint(PointStatus.NotStarted, destinationPoint, start);

            var driversIncome = new Money(income.Currency, income.Amount * DriverIncomeFromSingleRidePercent);

            return new Ride(RideStatus.OnTheWayToCustomer, driversIncome, customerId, customerDetails, start, destination);
        }

        public void AddStop(Ride ride, Address startPoint, Address destinationPoint)
        {
            var previousPoint = ride.Stops.SingleOrDefault(x => x.Address == startPoint);
            var routeToUpdate = ride.Stops.SingleOrDefault(x => x.PreviousPoint == previousPoint);

            var newDestinationPoint = _destinationPointService.CreateDestinationPoint(destinationPoint, previousPoint);
            routeToUpdate.PreviousPoint = newDestinationPoint;

            ride.AddStop(newDestinationPoint);
        }

        public void RemoveStop(Ride ride, Address startPoint)
        {
            var stopToRemove = ride.Stops.SingleOrDefault(x => x.Address == startPoint);
            var nextStop= ride.Stops.SingleOrDefault(x => x.PreviousPoint == stopToRemove);

            nextStop.PreviousPoint = stopToRemove.PreviousPoint;
            ride.RemoveStop(stopToRemove);
        }

        public DestinationPoint GetNextStop(Ride ride)
        {
            var lastReachedPoint = ride.Stops.OrderByDescending(x => x.UpdatedDate)
                .FirstOrDefault(x => x.Status == PointStatus.Reached);

            return ride.Stops.SingleOrDefault(x => x.PreviousPoint == lastReachedPoint);
        }
    }
}
