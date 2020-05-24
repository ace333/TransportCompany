using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Events;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Order.Application.Consumers
{
    public class OrderCancelledConsumer : IConsumer<IOrderCancelled>
    {
        private readonly IOrderUnitOfWork _unitOfWork;

        public OrderCancelledConsumer(IOrderUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<IOrderCancelled> context)
        {
            var message = context.Message;

            var order = message.RequestorType == RequestorType.Customer
                ? await _unitOfWork.OrderRepository.GetCurrentOrderByCustomerId(message.RequestorId)
                : await _unitOfWork.OrderRepository.GetCurrentOrderByDriverId(message.RequestorId);            

            order.Cancel(message.Comments);
            order.AddDomainEvent(message.RequestorType == RequestorType.Customer 
                ? new RideTerminated(order.DriverId, RequestorType.Driver)
                : new RideTerminated(order.CustomerId, RequestorType.Customer));

            await _unitOfWork.CommitAsync();
        }
    }
}
