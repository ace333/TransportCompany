using System.Collections.Generic;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Dto.Base
{
    public abstract class CustomerRideDetailsDtoBase
    {
        protected CustomerRideDetailsDtoBase() { }

        protected CustomerRideDetailsDtoBase(IReadOnlyCollection<AddressDto> routes,
            MoneyDto price,
            DriverDetailsDto driverDetails)
        {
            Routes = routes;
            Price = price;
            DriverDetails = driverDetails;
        }

        public DriverDetailsDto DriverDetails { get; set; }
        public MoneyDto Price { get; set;  }
        public IReadOnlyCollection<AddressDto> Routes { get; set; }
    }
}
