using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Events.Consumed;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Application.Consumers
{
    public class RouteAddedConsumer : IConsumer<RouteAdded>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;

        public RouteAddedConsumer(IDriverUnitOfWork unitOfWork, IRideService rideService)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
        }

        public async Task Consume(ConsumeContext<RouteAdded> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(message.DriverId);

            var ride = driver.GetCurrentRide();
            _rideService.AddStop(ride, message.StartPoint, message.Destination);

            await _unitOfWork.CommitAsync();
        }
    }
}
