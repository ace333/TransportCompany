using System.Linq;
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
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CustomerRideInvoiceQueryHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FileResult> Handle(CustomerRideInvoiceQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.CustomerId);
            Fail.IfNull(customer, request.CustomerId);

            var ride = customer.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);
            Fail.IfNull(ride.Invoice, ride, request.Id);

            return new FileContentResult(ride.Invoice.Content, "application/pdf");
        }
    }
}
