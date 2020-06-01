using System.Linq;
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
    public class RateDriverCommandHandler : ICommandHandler<RateDriverCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public RateDriverCommandHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RateDriverCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.CustomerId);
            Fail.IfNull(customer, request.CustomerId);

            var ride = customer.Rides.SingleOrDefault(x => x.Id == request.Id);
            Fail.IfNull(ride, request.Id);

            customer.AddDomainEvent(new DriverRated(ride.DriverId, request.Grade));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
