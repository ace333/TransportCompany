using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Application.Consumers
{
    public class OrderCreatedConsumer : IConsumer<IOrderCreated>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;

        public OrderCreatedConsumer(IDriverUnitOfWork unitOfWork,
            IRideService rideService)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
        }

        public async Task Consume(ConsumeContext<IOrderCreated> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.FindAsync(message.DriverId);

            var newRide = _rideService.CreateNewRide(
                message.StartPoint,
                message.Destination,
                message.Price,
                message.CustomerId,
                message.CustomerDetails);

            driver.AddRide(newRide);
            await _unitOfWork.CommitAsync();   
        }
    }
}
