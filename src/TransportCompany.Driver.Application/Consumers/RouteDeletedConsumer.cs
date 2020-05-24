using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Application.Consumers
{
    public class RouteDeletedConsumer : IConsumer<IRouteDeleted>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;

        public RouteDeletedConsumer(IDriverUnitOfWork unitOfWork, IRideService rideService)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
        }

        public async Task Consume(ConsumeContext<IRouteDeleted> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(message.DriverId);

            var ride = driver.GetCurrentRide();
            _rideService.RemoveStop(ride, message.StartPoint);

            await _unitOfWork.CommitAsync();
        }
    }
}
