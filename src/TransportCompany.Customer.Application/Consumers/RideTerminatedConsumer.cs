using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Application.Consumers
{
    public class RideTerminatedConsumer : IConsumer<IRideTerminated>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public RideTerminatedConsumer(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<IRideTerminated> context)
        {
            var message = context.Message;

            if(message.DestinatedEntityType == Shared.Domain.Enums.RequestorType.Customer)
            {
                var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(message.DestinatedEntityId);

                var ride = customer.GetCurrentRide();
                ride.Cancel();

                await _unitOfWork.CommitAsync();
            }
        }
    }
}
