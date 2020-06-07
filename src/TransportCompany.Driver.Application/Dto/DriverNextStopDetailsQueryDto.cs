using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriverNextStopDetailsQueryDto
    {
        public DriverNextStopDetailsQueryDto(int stopId, AddressDto address)
        {
            StopId = stopId;
            Address = address;
        }

        public int StopId { get; }
        public AddressDto Address { get; }
    }
}
