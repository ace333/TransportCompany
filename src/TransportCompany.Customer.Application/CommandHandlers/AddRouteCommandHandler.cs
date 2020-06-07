using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Domain.Events;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class AddRouteCommandHandler : ICommandHandler<AddRouteCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;
        private readonly IMapper _mapper;

        public AddRouteCommandHandler(ICustomerUnitOfWork unitOfWork,
            IRideService rideService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddRouteCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.CustomerId);
            Fail.IfNull(customer, request.CustomerId);

            var ride = customer.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);
            
            var destinationPointAddress = _mapper.Map<Address>(request.DestinationPoint);

            var addedRoute = _rideService.AddRoute(ride, request.PreviousRouteId, destinationPointAddress);
            customer.AddDomainEvent(
                new RouteAdded(ride.DriverId, addedRoute.PreviousRoute.DestinationPoint, destinationPointAddress));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
