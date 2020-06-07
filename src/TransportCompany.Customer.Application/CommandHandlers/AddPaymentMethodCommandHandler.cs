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
    public class AddPaymentMethodCommandHandler : ICommandHandler<AddPaymentMethodCommand>
    {
        private readonly ICustomerUnitOfWork _unitOfWork;
        private readonly IPaymentMethodService _paymentMethodService;

        public AddPaymentMethodCommandHandler(ICustomerUnitOfWork unitOfWork, IPaymentMethodService paymentMethodService)
        {
            _unitOfWork = unitOfWork;
            _paymentMethodService = paymentMethodService;
        }

        public async Task<Unit> Handle(AddPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetCustomerWithPaymentMethods(request.Id);
            Fail.IfNull(customer, request.Id);

            var paymentMethod = _paymentMethodService.CreatePaymentMethod(request.Type, request.Email, request.Password, 
                request.PhoneNumber,request.IsAlwaysLoggedIn, request.CardNumber, request.ExpiryDate, request.CvvCode, request.Country);

            customer.AddPaymentMethod(paymentMethod);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
