using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Customer.Application.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Customer.Application.Consumers
{
    public class OrderCompletedConsumer : IConsumer<IOrderCompleted>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public OrderCompletedConsumer(ICustomerUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }

        public async Task Consume(ConsumeContext<IOrderCompleted> context)
        {
            var message = context.Message;
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRidesAndPaymentMethods(message.CustomerId);

            var preferredPaymentMethod = customer.GetPrefferedPaymentMethod();
            var currentRide = customer.GetCurrentRide();

            currentRide.Complete();

            await _paymentService.PerformPayment(preferredPaymentMethod, currentRide.Price);
            await _unitOfWork.CommitAsync();
        }
    }
}
