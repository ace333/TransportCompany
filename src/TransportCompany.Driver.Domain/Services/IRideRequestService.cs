using TransportCompany.Driver.Domain.Entities;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Services
{
    public interface IRideRequestService : IDomainService
    {
        RideRequest CreateRideRequest(int customerId, CustomerDetails customerDetails, Address startPoint,
            Address destinationPoint);
    }
}
