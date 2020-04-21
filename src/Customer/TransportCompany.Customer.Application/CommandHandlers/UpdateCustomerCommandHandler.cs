using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Domain.Services;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _customerService = customerService;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.FindAsync(request.Id);
            Fail.IfNull(customer, request.Id);

            _customerService.UpdateCustomer(customer, request.Name, request.Surname, request.PhoneNumber, request.Email);

            _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
