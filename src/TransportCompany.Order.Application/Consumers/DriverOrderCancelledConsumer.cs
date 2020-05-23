using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Events;
using TransportCompany.Order.Domain.Events.Consumed;
using TransportCompany.Order.Infrastructure.Persistence;

namespace TransportCompany.Order.Application.Consumers
{
    public class DriverOrderCancelledConsumer : IConsumer<DriverOrderCancelled>
    {
        private readonly IOrderUnitOfWork _orderUnitOfWork;

        public DriverOrderCancelledConsumer(IOrderUnitOfWork orderUnitOfWork)
        {
            _orderUnitOfWork = orderUnitOfWork;
        }

        public async Task Consume(ConsumeContext<DriverOrderCancelled> context)
        {
            var message = context.Message;
            var order = await _orderUnitOfWork.OrderRepository.GetCurrentOrderByDriverId(message.DriverId);

            order.Cancel();
            order.AddDomainEvent(new CustomerRideTerminated(order.CustomerId));

            await _orderUnitOfWork.CommitAsync();
        }
    }
}
