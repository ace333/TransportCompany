using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Events;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class AcceptRideRequestCommandHandler : ICommandHandler<AcceptRideRequestCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AcceptRideRequestCommandHandler(IDriverUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AcceptRideRequestCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.DriverId);
            Fail.IfNull(driver, request.DriverId);

            var rideRequest = await _unitOfWork.RideRequestRepository.FindAsync(request.Id);
            Fail.IfNull(rideRequest, request.Id);

            var driverDetails = _mapper.Map<DriverDetails>(driver);

            rideRequest.MarkAsFound();

            driver.AddDomainEvent(new AvailableDriverFound(driver.Id, rideRequest.CustomerId, rideRequest.CustomerDetails,
                driverDetails, rideRequest.StartPoint, rideRequest.DestinationPoint));
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
