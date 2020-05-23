using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Events.Consumed;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Application.Consumers
{
    public class RouteDeletedConsumer : IConsumer<RouteDeleted>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;

        public RouteDeletedConsumer(IDriverUnitOfWork unitOfWork, IRideService rideService)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
        }

        public async Task Consume(ConsumeContext<RouteDeleted> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(message.DriverId);

            var ride = driver.GetCurrentRide();
            _rideService.RemoveStop(ride, message.StartPoint);

            await _unitOfWork.CommitAsync();
        }
    }
}
