using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Services;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class CreateDriverCommandHandler : ICommandHandler<CreateDriverCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDriverService _driverService;

        public CreateDriverCommandHandler(IDriverUnitOfWork unitOfWork, IDriverService driverService)
        {
            _unitOfWork = unitOfWork;
            _driverService = driverService;
        }

        public async Task<Unit> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = _driverService.CreateDriver(request.Name, request.Surname, request.PhoneNumber,
                request.Email, request.Nationality);

            _driverService.UpdateDriversLicense(driver, request.DriversLicenseNumber, request.DriversLicenseDateOfIssue,
                request.DriversLicenseExpiryDate);
            _driverService.UpdateDriversCar(driver, request.CarModel, request.CarRegistrationPlateNumber);

            _unitOfWork.Add(driver);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
