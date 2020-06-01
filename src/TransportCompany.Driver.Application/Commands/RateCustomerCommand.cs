using TransportCompany.Driver.Application.Commands.Base;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public class RateCustomerCommand : DriverBaseCommand, ICommand
    {
        public decimal Grade { get; set; }
    }
}
