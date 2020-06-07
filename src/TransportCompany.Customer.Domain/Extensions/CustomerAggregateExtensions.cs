using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Domain.Entities;

namespace TransportCompany.Customer.Domain.Extensions
{
    public static class CustomerAggregateExtensions
    {
        public static ICollection<Route> OrderFromStart(this ICollection<Route> routes)
        {
            var orderedRoutes = new List<Route>();
            return OrderRoutesInternal(routes, orderedRoutes, routes.SingleOrDefault(x => x.PreviousRoute == null));
        }

        private static ICollection<Route> OrderRoutesInternal(ICollection<Route> stops,
            ICollection<Route> orderedRoutes, Route currentRoute)
        {
            if (orderedRoutes.Count == stops.Count) return orderedRoutes;

            orderedRoutes.Add(currentRoute);

            var nextStop = stops.SingleOrDefault(x => x.PreviousRoute == currentRoute);
            return OrderRoutesInternal(stops, orderedRoutes, nextStop);
        }
    }
}
