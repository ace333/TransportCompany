using TransportCompany.Customer.Application.Command.Base;
using TransportCompany.Customer.Application.Dto;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class AddRouteCommand : CustomerBaseCommand, ICommand
    {
        public AddressDto StartPoint { get; set; }
        public AddressDto DestinationPoint { get; set; }
    }
}
