using System.Threading.Tasks;
using MassTransit;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Application.Consumers
{
    public class CustomerPickedUpConsumer : IConsumer<ICustomerPickedUp>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CustomerPickedUpConsumer(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<ICustomerPickedUp> context)
        {
            var message = context.Message;
            var consumer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(message.CustomerId);

            var currentRide = consumer.GetCurrentRideWhileWaitingForDriver();
            currentRide.MarkAsOnGoing();

            await _unitOfWork.CommitAsync();
        }
    }
}
