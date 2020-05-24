using System.Collections.Generic;
using System.Threading.Tasks;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.Infrastructure.Model;
using TDriver = TransportCompany.Driver.Domain.Entities.Driver;

namespace TransportCompany.Driver.Application.Services
{
    public interface INotificationService : IScopedService
    {
        Task NotifyDriversAboutRequestedRide(int rideRequestId, Address startPoint, string customerName, 
            IEnumerable<TDriver> drivers);
    }
}
