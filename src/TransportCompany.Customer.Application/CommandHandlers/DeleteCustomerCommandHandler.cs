using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.FindAsync(request.Id);

            _unitOfWork.Delete(customer);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
