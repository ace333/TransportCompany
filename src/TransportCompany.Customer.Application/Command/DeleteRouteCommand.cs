using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public class DeleteRouteCommand : IdCommand, ICommand
    {
        public int RouteId { get; set; }
    }
}
