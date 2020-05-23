using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Domain.Entities;
using TransportCompany.Customer.Domain.Events;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Dto;
using TransportCompany.Shared.Application.Utils;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class AddRouteCommandHandler : ICommandHandler<AddRouteCommand>
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;
        private readonly IRideService _rideService;

        public AddRouteCommandHandler(ICustomerUnitOfWork customerUnitOfWork,
            IRideService rideService)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _rideService = rideService;
        }

        public async Task<Unit> Handle(AddRouteCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerUnitOfWork.CustomerRepository.GetCustomerWithRides(request.Id);
            Fail.IfNull(customer, request.Id);

            var ride = customer.GetCurrentRide();
            Fail.IfNull(ride, customer, request.Id);

            var startPointAddress = CreateAddressFromDto(request.StartPoint);
            var destinationPointAddress = CreateAddressFromDto(request.DestinationPoint);

            _rideService.AddRoute(ride, new Route(startPointAddress, destinationPointAddress));
            customer.AddDomainEvent(new RouteAdded(ride.DriverId, startPointAddress, destinationPointAddress));

            await _customerUnitOfWork.CommitAsync();

            return Unit.Value;
        }

        // TO DO : automapper
        private Address CreateAddressFromDto(AddressDto addressDto)
            => new Address(
                addressDto.HouseNumber,
                addressDto.ZipCode,
                addressDto.Street,
                addressDto.City,
                addressDto.State,
                addressDto.Country);
    }
}
