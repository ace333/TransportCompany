using TransportCompany.Customer.Application.Command.Base;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public class DeleteRouteCommand : CustomerBaseCommand, ICommand
    {
        public int RouteId { get; set; }
    }
}
