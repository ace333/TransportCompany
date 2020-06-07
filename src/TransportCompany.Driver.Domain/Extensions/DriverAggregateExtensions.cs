using System.Collections.Generic;
using System.Linq;
using TransportCompany.Driver.Domain.Entities;

namespace TransportCompany.Driver.Domain.Extensions
{
    public static class DriverAggregateExtensions
    {
        public static ICollection<DestinationPoint> OrderFromStart(this ICollection<DestinationPoint> stops)
        {
            var orderedStops = new List<DestinationPoint>();
            return OrderStopsInternal(stops, orderedStops, stops.SingleOrDefault(x => x.PreviousPoint == null));
        }

        private static ICollection<DestinationPoint> OrderStopsInternal(ICollection<DestinationPoint> stops,
            ICollection<DestinationPoint> orderedStops, DestinationPoint currentStop)
        {
            if (orderedStops.Count == stops.Count) return orderedStops;

            orderedStops.Add(currentStop);

            var nextStop = stops.SingleOrDefault(x => x.PreviousPoint == currentStop);
            return OrderStopsInternal(stops, orderedStops, nextStop);
        }
    }
}
