using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Events;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class FinishRideCommandHandler : ICommandHandler<FinishRideCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDriverService _driverService;

        public FinishRideCommandHandler(IDriverUnitOfWork unitOfWork, IDriverService driverService)
        {
            _unitOfWork = unitOfWork;
            _driverService = driverService;
        }

        public async Task<Unit> Handle(FinishRideCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.Id);
            Fail.IfNull(driver, request.Id);

            var ride = driver.GetCurrentRide();
            ride.Complete();

            var invoice = _driverService.GenerateInvoice(driver.Id, driver.PersonalInfo, driver.CompanyDetails, ride.Income);
            driver.AddDomainEvent(new RideFinished(driver.Id, ride.CustomerId, ride.CustomerDetails, invoice));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
