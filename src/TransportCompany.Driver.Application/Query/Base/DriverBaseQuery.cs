using TransportCompany.Shared.Application.Query;

namespace TransportCompany.Driver.Application.Query.Base
{
    public abstract class DriverBaseQuery : IdQuery
    {
        public int DriverId { get; private set; }

        public void SetArguments(int driverId, int id)
        {
            DriverId = driverId;
            SetId(id);
        }
    }
}
