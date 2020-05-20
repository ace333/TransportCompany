using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Domain.Events;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class CancelRideCommandHandler : ICommandHandler<CancelRideCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CancelRideCommandHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CancelRideCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.Id);
            Fail.IfNull(customer, request.Id);

            var ride = customer.GetCurrentRide();
            ride.Cancel();

            customer.AddDomainEvent(new RideCancelled(customer.Id, request.Comments));
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
