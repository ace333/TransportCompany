using System.Linq;
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
    public class UpdateStopCommandHandler : ICommandHandler<UpdateStopCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IDestinationPointService _destinationPointService;

        public UpdateStopCommandHandler(IDriverUnitOfWork unitOfWork, IDestinationPointService destinationPointService)
        {
            _unitOfWork = unitOfWork;
            _destinationPointService = destinationPointService;
        }

        public async Task<Unit> Handle(UpdateStopCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetDriverWithRides(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var ride = driver.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);

            _destinationPointService.UpdateDestinationPoint(ride, request.StopId);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
