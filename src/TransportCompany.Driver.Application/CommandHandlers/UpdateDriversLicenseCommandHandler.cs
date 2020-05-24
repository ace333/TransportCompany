using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class UpdateDriversLicenseCommandHandler : ICommandHandler<UpdateDriversLicenseCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDriverService _driverService;

        public UpdateDriversLicenseCommandHandler(IDriverUnitOfWork unitOfWork, IDriverService driverService)
        {
            _unitOfWork = unitOfWork;
            _driverService = driverService;
        }

        public async Task<Unit> Handle(UpdateDriversLicenseCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            _driverService.UpdateDriversLicense(driver, request.DriversLicenseNumber, request.DriversLicenseDateOfIssue,
                request.DriversLicenseExpiryDate);

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
