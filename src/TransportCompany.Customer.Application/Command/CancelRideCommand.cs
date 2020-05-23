using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class CancelRideCommand: IdCommand, ICommand
    {
        public string Comments { get; set; }
    }
}
