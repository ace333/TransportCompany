using AutoMapper;
using MassTransit;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Events;
using TransportCompany.Order.Domain.Services;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Domain.ValueObjects;
using TransportCompany.Shared.EventStore.Events;

namespace TransportCompany.Order.Application.Consumers
{
    public class AvailableDriverFoundConsumer : IConsumer<IAvailableDriverFound>
    {
        private readonly IOrderUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public AvailableDriverFoundConsumer(IOrderUnitOfWork unitOfWork,
            IOrderService orderService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<IAvailableDriverFound> context)
        {
            var message = context.Message;
            var order = new Domain.Entities.Order(message.CustomerId, message.DriverId);

            order.SetExecutionCountry(_orderService.GetExecutionCountry(message.DestinationPoint.Country));
            order.SetPaymentAmount(_orderService.GetPaymentAmount(
                string.Join(" ", message.StartPoint.Street, message.StartPoint.HouseNumber),
                message.StartPoint.City,
                message.StartPoint.State,
                string.Join(" ", message.DestinationPoint.Street, message.DestinationPoint.HouseNumber),
                message.DestinationPoint.City,
                message.DestinationPoint.State,
                message.DestinationPoint.Country));

            var money = _mapper.Map<Money>(order.PaymentAmount);

            order.AddDomainEvent(new OrderCreated(
                message.CustomerId,
                message.DriverId,
                money, 
                message.DriverDetails,
                message.StartPoint,
                message.DestinationPoint));

            _unitOfWork.Add(order);
            await _unitOfWork.CommitAsync();
        }
    }
}
