using TransportCompany.Customer.Application.Command.Base;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public class RateDriverCommand : CustomerBaseCommand, ICommand
    {
        public decimal Grade { get; set; }
    }
}
