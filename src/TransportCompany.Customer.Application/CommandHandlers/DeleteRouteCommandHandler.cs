using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Domain.Events;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class DeleteRouteCommandHandler : ICommandHandler<DeleteRouteCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IRideService _rideService;

        public DeleteRouteCommandHandler(ICustomerUnitOfWork unitOfWork, IRideService rideService)
        {
            _unitOfWork = unitOfWork;
            _rideService = rideService;
        }

        public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.CustomerId);
            Fail.IfNull(customer, request.CustomerId);

            var ride = customer.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);

            var routeToDelete = ride.GetRoute(request.RouteId);
            Fail.IfNull(routeToDelete, request.RouteId);

            _rideService.RemoveRoute(ride, routeToDelete);
            customer.AddDomainEvent(new RouteDeleted(ride.DriverId, routeToDelete.StartPoint));

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
