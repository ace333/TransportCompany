using System.Collections.Generic;
using System.Threading.Tasks;
using TransportCompany.Shared.Domain.ValueObjects;
using TDriver = TransportCompany.Driver.Domain.Entities.Driver;

namespace TransportCompany.Driver.Application.Services
{
    public class NotificationService : INotificationService
    {
        public Task NotifyDriversAboutRequestedRide(int rideRequestId, Address startPoint, string customerName, 
            IEnumerable<TDriver> drivers)
        {
            // Method should be able to calculate notify all available drivers about requested ride and a place of pick up.
            // All driver should be notified on its interface asynchronously with a use of e.g. SignalR lib.
            // For a demo purposes method would just return Task.CompletedTask.

            return Task.CompletedTask;
        }
    }
}
