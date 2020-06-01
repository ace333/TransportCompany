using System.Collections.Generic;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Dto.Base
{
    public abstract class CustomerRideDetailsDtoBase
    {
        protected CustomerRideDetailsDtoBase() { }

        protected CustomerRideDetailsDtoBase(IReadOnlyCollection<AddressDto> routes,
            RideStatus status,
            MoneyDto price,
            DriverDetailsDto driverDetails)
        {
            Routes = routes;
            Price = price;
            DriverDetails = driverDetails;
            Status = status;
        }

        public RideStatus Status { get; set; }
        public DriverDetailsDto DriverDetails { get; set; }
        public MoneyDto Price { get; set;  }
        public IReadOnlyCollection<AddressDto> Routes { get; set; }
    }
}
