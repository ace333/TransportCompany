using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public class DeletePaymentMethodCommand : IdCommand, ICommand
    {
        public int PaymentMethodId { get; set; }
    }
}
