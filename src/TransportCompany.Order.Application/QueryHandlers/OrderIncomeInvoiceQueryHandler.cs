using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TransportCompany.Order.Application.Query;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Order.Application.QueryHandlers
{
    public class OrderIncomeInvoiceQueryHandler : IQueryHandler<OrderIncomeInvoiceQuery, FileResult>
    {
        private readonly IOrderUnitOfWork _unitOfWork;

        public OrderIncomeInvoiceQueryHandler(IOrderUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FileResult> Handle(OrderIncomeInvoiceQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.FindAsync(request.Id);
            Fail.IfNull(order, request.Id);

            return new FileContentResult(order.CustomersInvoice.Content, "application/pdf");
        }
    }
}
