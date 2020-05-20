using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Events;
using TransportCompany.Order.Domain.Events.Consumed;
using TransportCompany.Order.Infrastructure.Persistence;

namespace TransportCompany.Order.Application.Consumers
{
    public class CustomerOrderCancelledConsumer : IConsumer<CustomerOrderCancelled>
    {
        private readonly IOrderUnitOfWork _unitOfWork;

        public CustomerOrderCancelledConsumer(IOrderUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CustomerOrderCancelled> context)
        {
            var message = context.Message;
            var order = await _unitOfWork.OrderRepository.GetCurrentOrderByCustomerId(message.CustomerId);

            order.Cancel(message.Comments);
            order.AddDomainEvent(new DriverRideTerminated(order.DriverId));

            await _unitOfWork.CommitAsync();
        }
    }
}
