using TransportCompany.Customer.Application.Command.Base;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class CancelRideCommand: CustomerBaseCommand, ICommand
    {
        public string Comments { get; set; }
    }
}
