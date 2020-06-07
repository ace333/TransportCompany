using System.Collections.Generic;
using TransportCompany.Driver.Application.Dto.Base;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriverRideDetailsQueryDto : DriverRideDetailsBaseDto
    {
        public DriverRideDetailsQueryDto(IReadOnlyCollection<AddressDto> stops, 
            MoneyDto income, 
            CustomerDetailsDto customerDetails,
            RideStatus status) : base(income, customerDetails, status)
        {
            Stops = stops;
        }

        public IReadOnlyCollection<AddressDto> Stops { get; set; }
    }
}
