using TransportCompany.Driver.Application.Commands.Base;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class UpdateStopCommand : DriverBaseCommand, ICommand
    {
        public int StopId { get; set; }
    }
}
