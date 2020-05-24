using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public class RateCustomerCommand : IdCommand, ICommand
    {
        public decimal Grade { get; set; }
    }
}
