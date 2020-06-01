using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Driver.Application.Query;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Query;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.Query
{
    public class DriverRideInvoiceQueryHandler : IQueryHandler<DriverRideInvoiceQuery, FileResult>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public DriverRideInvoiceQueryHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FileResult> Handle(DriverRideInvoiceQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var ride = driver.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(driver, request.Id);
            Fail.IfNull(ride.Invoice, ride, request.Id);

            return new FileContentResult(ride.Invoice.Content, "application/pdf");
        }
    }
}
