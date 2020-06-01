using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Order.Application.Dto;
using TransportCompany.Order.Application.Query;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Infrastructure.Model;
using TransportCompany.Shared.Infrastructure.Extensions;

namespace TransportCompany.Order.Application.QueryHandlers
{
    public class OrdersQueryHandler : IQueryHandler<OrdersQuery, PaginatedList<OrdersQueryDto>>
    {
        private readonly IOrderUnitOfWork _unitOfWork;

        public OrdersQueryHandler(IOrderUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PaginatedList<OrdersQueryDto>> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.OrderRepository.GetAll()
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new OrdersQueryDto
                {
                    Id = x.Id,
                    Status = x.Status,
                    Comments = x.Comments,
                    Currency = x.PaymentAmount.Currency,
                    ExecutionCountry = x.ExecutionCountry,
                    NetPaymentAmount = x.PaymentAmount.NetValue
                })
                .AsPaginatedList(request.GetPagingElements());
        }
    }
}
