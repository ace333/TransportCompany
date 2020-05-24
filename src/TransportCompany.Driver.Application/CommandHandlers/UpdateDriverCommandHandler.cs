using System;
using System.Collections.Generic;
using System.Text;
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
    public class UpdateDriverCommandHandler : ICommandHandler<UpdateDriverCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDriverService _driverService;

        public UpdateDriverCommandHandler(IDriverUnitOfWork unitOfWork, IDriverService driverService)
        {
            _unitOfWork = unitOfWork;
            _driverService = driverService;
        }

        public async Task<Unit> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            _driverService.UpdateDriver(driver, request.Name, request.Surname, request.PhoneNumber, request.Email);

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
