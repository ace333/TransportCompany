using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class RequestRideCommand: IdCommand, ICommand
    {
        public AddressDto StartPoint { get; set; }
        public AddressDto DestinationPoint { get; set; }
    }
}
