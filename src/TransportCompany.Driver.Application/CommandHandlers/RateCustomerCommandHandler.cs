using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Events;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class RateCustomerCommandHandler : ICommandHandler<RateCustomerCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public RateCustomerCommandHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<Unit> Handle(RateCustomerCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var ride = driver.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(driver, request.Id);

            driver.AddDomainEvent(new CustomerRated(ride.CustomerId, request.Grade));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
