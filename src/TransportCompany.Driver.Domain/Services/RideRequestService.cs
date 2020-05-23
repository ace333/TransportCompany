using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public class RideRequestService : IRideRequestService
    {
        public RideRequest CreateRideRequest(
            int customerId, 
            CustomerDetails customerDetails, 
            Address startPoint, 
            Address destinationPoint) 
            => new RideRequest(customerId, customerDetails, startPoint, destinationPoint);
    }
}
