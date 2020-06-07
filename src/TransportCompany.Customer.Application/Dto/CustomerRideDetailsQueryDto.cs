using System;
using System.Collections.Generic;
using TransportCompany.Customer.Application.Dto.Base;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerRideDetailsQueryDto : CustomerRideDetailsDtoBase
    {
        public CustomerRideDetailsQueryDto(
            IReadOnlyCollection<RouteDto> routes,
            RideStatus status,
            MoneyDto price,
            DateTime? finishedDate, 
            DriverDetailsDto driverDetails) : base(status, price)
        {
            Routes = routes;
            FinishedDate = finishedDate;
            DriverDetails = driverDetails;
        }

        public DateTime? FinishedDate { get; set; }
        public DriverDetailsDto DriverDetails { get; set; }
        public IReadOnlyCollection<RouteDto> Routes { get; set; }
    }
}
