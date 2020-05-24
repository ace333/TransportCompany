using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class AcceptRideRequestCommand: IdCommand, ICommand
    {
        public int RideRequestId { get; set; }
    }
}
