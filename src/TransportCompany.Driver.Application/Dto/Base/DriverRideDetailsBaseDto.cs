using System;
using System.Collections.Generic;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Dto.Base
{
    public abstract class DriverRideDetailsBaseDto
    {
        protected DriverRideDetailsBaseDto() { }

        protected DriverRideDetailsBaseDto(MoneyDto income,
            CustomerDetailsDto customerDetails,
            RideStatus status)
        {            
            Income = income;
            CustomerDetails = customerDetails;
            Status = status;
        }

        public CustomerDetailsDto CustomerDetails { get; set; }
        public MoneyDto Income { get; set; }
        public RideStatus Status { get; set; }
    }
}
