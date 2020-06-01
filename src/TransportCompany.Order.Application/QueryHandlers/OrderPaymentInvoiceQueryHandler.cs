using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Order.Application.Query;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Order.Application.QueryHandlers
{
    public class OrderPaymentInvoiceQueryHandler : IQueryHandler<OrderPaymentInvoiceQuery, FileResult>
    {
        private readonly IOrderUnitOfWork _unitOfWork;

        public OrderPaymentInvoiceQueryHandler(IOrderUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FileResult> Handle(OrderPaymentInvoiceQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.FindAsync(request.Id);
            Fail.IfNull(order, request.Id);

            return new FileContentResult(order.DriversInvoice.Content, "application/pdf");
        }
    }
}
