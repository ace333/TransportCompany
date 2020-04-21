using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public class RateDriverCommand : IdCommand, ICommand
    {
        public int Grade { get; set; }
    }
}
