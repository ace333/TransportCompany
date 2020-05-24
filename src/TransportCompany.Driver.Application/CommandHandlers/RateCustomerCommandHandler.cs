using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Driver.Application.Commands;
using TransportCompany.Driver.Domain.Events;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Driver.Application.CommandHandlers
{
    public class RateCustomerCommandHandler : ICommandHandler<RateCustomerCommand>
    {
        private readonly IDriverUnitOfWork _unitOfWork;

        public RateCustomerCommandHandler(IDriverUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        public async Task<Unit> Handle(RateCustomerCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.FindAsync(request.Id);
            Fail.IfNull(driver, request.Id);

            var lastRide = driver.GetLastRide();
            driver.AddDomainEvent(new CustomerRated(lastRide.CustomerId, request.Grade));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
