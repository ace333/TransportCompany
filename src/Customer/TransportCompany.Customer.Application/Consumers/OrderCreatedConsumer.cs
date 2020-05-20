using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Customer.Domain.Events.Consumed;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;

namespace TransportCompany.Customer.Application.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;

        public OrderCreatedConsumer(ICustomerUnitOfWork unitOfWork, IRideService rideService)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            var message = context.Message;
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(message.CustomerId);

            var newRide = _rideService.CreateRide(message.Price, 
                message.DriverId,
                message.DriverDetails, 
                message.StartPoint, 
                message.Destination);

            customer.AddRide(newRide);
            await _unitOfWork.CommitAsync();
        }
    }
}
