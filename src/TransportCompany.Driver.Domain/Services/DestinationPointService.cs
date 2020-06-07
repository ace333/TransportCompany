using System.Linq;
using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public class DestinationPointService : IDestinationPointService
    {
        public DestinationPoint CreateDestinationPoint(Address address, DestinationPoint previousPoint = null)
            => new DestinationPoint(PointStatus.OnTheWay, address, previousPoint);

        public void UpdateDestinationPoint(Ride ride, int stopId)
        {
            var destinationPoint = ride.Stops.SingleOrDefault(x => x.Id == stopId);
            destinationPoint.Update(PointStatus.Reached);

            var nextDestinationPoint = ride.Stops.SingleOrDefault(x => x.PreviousPoint == destinationPoint);
            if (nextDestinationPoint != null) nextDestinationPoint.Update(PointStatus.OnTheWay);
        }
    }
}
