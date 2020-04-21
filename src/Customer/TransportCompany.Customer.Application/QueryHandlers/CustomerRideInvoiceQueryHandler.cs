using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Customer.Application.Query;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.QueryHandlers
{
    public class CustomerRideInvoiceQueryHandler: IQueryHandler<CustomerRideInvoiceQuery, FileResult>
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;

        public CustomerRideInvoiceQueryHandler(ICustomerUnitOfWork customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
        }

        public async Task<FileResult> Handle(CustomerRideInvoiceQuery request, CancellationToken cancellationToken)
        {
            var ride = await _customerUnitOfWork.RideRepository.FindAsync(request.Id);
            Fail.IfNull(ride, request.Id);
            Fail.IfNull(ride.Invoice, ride, request.Id);

            return new FileContentResult(ride.Invoice.Content, "application/pdf");
        }
    }
}
