using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Domain.Events;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class RequestRideCommandHandler : ICommandHandler<RequestRideCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RequestRideCommandHandler(ICustomerUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RequestRideCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.FindAsync(request.Id);
            customer.AddDomainEvent(new RideRequested(
                customer.Id,
                _mapper.Map<Address>(request.StartPoint),
                _mapper.Map<Address>(request.DestinationPoint),
                _mapper.Map<CustomerDetails>(customer)));

            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
