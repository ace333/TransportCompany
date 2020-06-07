using System.Collections.Generic;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Services
{
    public interface IRideService : IDomainService
    {
        Ride CreateRide(Money price, int driverId, DriverDetails driverDetails, Address startPoint, Address destination);        
        Route AddRoute(Ride ride, int previousRouteId, Address destination);
        Route RemoveRoute(Ride ride, int routeId);
    }
}
