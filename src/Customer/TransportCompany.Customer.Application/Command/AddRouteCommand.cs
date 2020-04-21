using TransportCompany.Customer.Application.Dto;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class AddRouteCommand : IdCommand, ICommand
    {
        public AddressDto StartPoint { get; set; }
        public AddressDto DestinationPoint { get; set; }
    }
}
