using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Driver.Application.Consumers
{
    public class RideTerminatedConsumer : IConsumer<IRideTerminated>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public RideTerminatedConsumer(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<IRideTerminated> context)
        {
            var message = context.Message;

            if(message.DestinatedEntityType == RequestorType.Driver)
            {
                var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(message.DestinatedEntityId);

                var ride = driver.GetCurrentRideWhenNoCustomerPickedUp();
                ride.Cancel();

                await _unitOfWork.CommitAsync();
            }
        }
    }
}
