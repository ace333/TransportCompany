using System;
using System.Collections.Generic;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Dto.Base
{
    public abstract class DriverRideDetailsBaseDto
    {
        protected DriverRideDetailsBaseDto() { }

        protected DriverRideDetailsBaseDto(IReadOnlyCollection<AddressDto> stops,
            MoneyDto income,
            CustomerDetailsDto customerDetails)
        {
            Stops = stops;
            Income = income;
            CustomerDetails = customerDetails;            
        }

        public CustomerDetailsDto CustomerDetails { get; set; }
        public MoneyDto Income { get; set; }
        public IReadOnlyCollection<AddressDto> Stops { get; set; }        
    }
}
