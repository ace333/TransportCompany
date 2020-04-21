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
        private readonly ICustomerUnitOfWork _customerUnitOfWork;

        public DeleteCustomerCommandHandler(ICustomerUnitOfWork customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerUnitOfWork.CustomerRepository.FindAsync(request.Id);

            _customerUnitOfWork.Delete(customer);
            await _customerUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
