using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Events.Consumed;
using TransportCompany.Customer.Infrastructure.Persistence;

namespace TransportCompany.Customer.Application.Consumers
{
    public class RideTerminatedConsumer : IConsumer<CustomerRideTerminated>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public RideTerminatedConsumer(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CustomerRideTerminated> context)
        {
            var message = context.Message;
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(message.CustomerId);

            var ride = customer.GetCurrentRide();
            ride.Cancel();

            await _unitOfWork.CommitAsync();
        }
    }
}
