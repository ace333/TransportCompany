using System;
using System.Collections.Generic;
using TransportCompany.Customer.Application.Dto.Base;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerRideDetailsQueryDto : CustomerRideDetailsDtoBase
    {
        public CustomerRideDetailsQueryDto(IReadOnlyCollection<AddressDto> routes,
            MoneyDto price, 
            DateTime finishedDate, 
            DriverDetailsDto driverDetails) : base(routes, price, driverDetails)
        {
            FinishedDate = finishedDate;
        }

        public DateTime FinishedDate { get; set; }
    }
}
