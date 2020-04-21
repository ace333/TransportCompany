using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer(request.Name, request.Surname, request.PhoneNumber,
                request.Email, request.Nationality);

            _unitOfWork.Add(customer);
            _unitOfWork.Commit();

            return Task.FromResult(Unit.Value);
        }
    }
}
