using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Application.Events;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class DeleteRouteCommandHandler : ICommandHandler<DeleteRouteCommand>
    {
        private readonly ICustomerUnitOfWork _customerUnitOfWork;
        private readonly IRideService _rideService;

        public DeleteRouteCommandHandler(ICustomerUnitOfWork customerUnitOfWork, IRideService rideService)
        {
            _customerUnitOfWork = customerUnitOfWork;
            _rideService = rideService;
        }

        public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerUnitOfWork.CustomerRepository.GetCustomerWithRides(request.Id);
            Fail.IfNull(customer, request.Id);

            var ride = customer.GetCurrentRide();
            Fail.IfNull(ride, customer, request.Id);

            var routeToDelete = ride.GetRoute(request.RouteId);
            Fail.IfNull(routeToDelete, request.RouteId);

            _rideService.RemoveRoute(ride, routeToDelete);
            customer.AddDomainEvent(new RouteDeleted(routeToDelete.StartPoint, routeToDelete.Destination));

            await _customerUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
