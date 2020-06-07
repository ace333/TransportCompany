using System.Collections.Generic;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Customer.Application.Dto.Base
{
    public abstract class CustomerRideDetailsDtoBase
    {
        protected CustomerRideDetailsDtoBase() { }

        protected CustomerRideDetailsDtoBase(RideStatus status, MoneyDto price)
        {
            Price = price;
            Status = status;
        }

        public RideStatus Status { get; set; }
        public MoneyDto Price { get; set;  }
    }
}
