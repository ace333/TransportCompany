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
    public class TakeCustomerCommandHandler : ICommandHandler<TakeCustomerCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public TakeCustomerCommandHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(TakeCustomerCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var ride = driver.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(driver, request.Id);

            ride.PickupCustomer();

            driver.AddDomainEvent(new CustomerPickedUp(ride.CustomerId));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
