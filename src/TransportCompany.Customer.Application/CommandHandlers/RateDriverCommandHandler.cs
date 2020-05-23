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
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithRides(request.Id);
            Fail.IfNull(customer, request.Id);

            var lastRide = customer.GetLastRide();
            customer.AddDomainEvent(new DriverRated(lastRide.DriverId, request.Grade));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
