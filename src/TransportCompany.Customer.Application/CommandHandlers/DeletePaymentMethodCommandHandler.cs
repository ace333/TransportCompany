using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransportCompany.Customer.Application.Command;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Utils;

namespace TransportCompany.Customer.Application.CommandHandlers
{
    public class DeletePaymentMethodCommandHandler : ICommandHandler<DeletePaymentMethodCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        public DeletePaymentMethodCommandHandler(ICustomerUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithPaymentMethods(request.Id);
            Fail.IfNull(customer, request.Id);

            var paymentMethod = customer.PaymentMethods.SingleOrDefault(x => x.Id == request.PaymentMethodId);
            Fail.IfNull(paymentMethod, request.PaymentMethodId);

            customer.RemovePaymentMethod(paymentMethod);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
