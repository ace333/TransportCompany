using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Application.Services;
using TransportCompany.Driver.Domain.Events.Consumed;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Application.Consumers
{
    public class RideRequestedConsumer : IConsumer<RideRequested>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IRideRequestService _rideRequestService;
        private readonly INotificationService _notificationService;

        public RideRequestedConsumer(IDriverUnitOfWork unitOfWork,
            IRideRequestService rideRequestService,
            INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _rideRequestService = rideRequestService;
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<RideRequested> context)
        {
            var message = context.Message;
            var drivers = await _unitOfWork.DriverRepository.GetAllAvailableDrivers();

            var rideRequest = _rideRequestService.CreateRideRequest(message.CustomerId,
                message.CustomerDetails,
                message.StartPoint,
                message.DestinationPoint);

            _unitOfWork.Add(rideRequest);

            await _unitOfWork.CommitAsync();
            await _notificationService.NotifyDriversAboutRequestedRide(
                rideRequest.Id, message.StartPoint, message.CustomerDetails.Name, drivers);
        }
    }
}
