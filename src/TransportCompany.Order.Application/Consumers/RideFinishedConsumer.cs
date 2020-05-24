using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Events;
using TransportCompany.Order.Domain.Services;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Order.Application.Consumers
{
    public class RideFinishedConsumer : IConsumer<IRideFinished>
    {
        private readonly IOrderUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        public RideFinishedConsumer(IOrderUnitOfWork unitOfWork,
            IOrderService orderService)            
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;            
        }

        public async Task Consume(ConsumeContext<IRideFinished> context)
        {
            var message = context.Message;
            var order = await _unitOfWork.OrderRepository.GetCurrentOrderByDriverId(message.DriverId);

            var customersInvoice = _orderService.CreateCustomersInvoice(
                message.CustomerId,
                message.CustomerDetails.Name,
                message.CustomerDetails.Surname,
                message.CustomerDetails.PhoneNumber,
                message.CustomerDetails.Email);

            order.SetDriverInvoice(message.DriversInvoice);
            order.SetCustomerInvoice(customersInvoice);

            order.Complete();
            order.AddDomainEvent(new OrderCompleted(message.CustomerId, customersInvoice));

            await _unitOfWork.CommitAsync();
        }
    }
}
