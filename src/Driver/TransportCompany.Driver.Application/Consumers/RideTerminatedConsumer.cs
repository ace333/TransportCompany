using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Domain.Events.Consumed;
using TransportCompany.Driver.Infrastructure.Persistence;

namespace TransportCompany.Driver.Application.Consumers
{
    public class RideTerminatedConsumer : IConsumer<DriverRideTerminated>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public RideTerminatedConsumer(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<DriverRideTerminated> context)
        {
            var message = context.Message;
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(message.DriverId);

            var ride = driver.GetCurrentRideWhenNoCustomerPickedUp();
            ride.Cancel();

            await _unitOfWork.CommitAsync();
        }
    }
}
