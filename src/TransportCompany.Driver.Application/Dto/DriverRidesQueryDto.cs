using TransportCompany.Driver.Application.Dto.Base;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriverRidesQueryDto : DriverRideDetailsBaseDto
    {         
        public AddressDto Destination { get; set; }
        public AddressDto StartPoint { get; set; }
    }
}
