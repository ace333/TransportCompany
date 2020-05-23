using System.Linq;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Domain.ValueObjects;
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
            var start = new DestinationPoint(PointStatus.OnTheWay, PointType.PickupPoint, startPoint);
            var destination = new DestinationPoint(PointStatus.NotStarted, PointType.DestinationPoint, destinationPoint);

            var driversIncome = new Money(income.Currency, income.Amount * DriverIncomeFromSingleRidePercent);

            return new Ride(RideStatus.OnTheWayToCustomer, driversIncome, customerId, customerDetails, start, destination);
        }

        public void AddStop(Ride ride, Address startPoint, Address destinationPoint)
        {
            var stops = ride.Stops.ToList();
            var stopBefore = stops.SingleOrDefault(x => x.Address == startPoint);
            var index = stops.IndexOf(stopBefore) + 1;
            var stopAfter = stops[index];

            var stopBetween = _destinationPointService.CreateStopPoint(destinationPoint);

            stops.Add(stopAfter);
            stops[index] = stopBetween;

            ride.Stops = stops;
        }

        public void RemoveStop(Ride ride, Address startPoint)
        {
            var stopToRemove = ride.Stops.SingleOrDefault(x => x.Address == startPoint);
            ride.RemoveStop(stopToRemove);
        }
    }
}
