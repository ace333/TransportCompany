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
    public class CancelRideCommandHandler : ICommandHandler<CancelRideCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public CancelRideCommandHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CancelRideCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.Id);
            Fail.IfNull(driver, request.Id);

            var ride = driver.GetCurrentRideWhenNoCustomerPickedUp();
            Fail.IfNull(ride, driver, request.Id);

            ride.Cancel();
            driver.AddDomainEvent(new RideCancelled(driver.Id));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
