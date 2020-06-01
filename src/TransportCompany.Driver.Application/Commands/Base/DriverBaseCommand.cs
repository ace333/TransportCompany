using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands.Base
{
    public abstract class DriverBaseCommand : IdCommand
    {
        public int DriverId { get; private set; }

        public void SetArguments(int driverId, int id)
        {
            DriverId = driverId;
            SetId(id);
        }
    }
}
