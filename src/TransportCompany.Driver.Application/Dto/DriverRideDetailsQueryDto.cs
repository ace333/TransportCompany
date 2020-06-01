using System;
using System.Collections.Generic;
using TransportCompany.Driver.Application.Dto.Base;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriverRideDetailsQueryDto : DriverRideDetailsBaseDto
    {
        public DriverRideDetailsQueryDto(IReadOnlyCollection<AddressDto> stops, MoneyDto income, 
            CustomerDetailsDto customerDetails) : base(stops, income, customerDetails)
        {
        }
    }
}
