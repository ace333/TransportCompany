﻿using System.Collections.Generic;
using TransportCompany.Customer.Application.Dto.Base;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerCurrentRideDetailsQueryDto : CustomerRideDetailsDtoBase
    {
        public CustomerCurrentRideDetailsQueryDto(IReadOnlyCollection<AddressDto> routes,
            MoneyDto price,
            DriverDetailsDto driverDetails) : base(routes, price, driverDetails)
        {
        }
    }
}