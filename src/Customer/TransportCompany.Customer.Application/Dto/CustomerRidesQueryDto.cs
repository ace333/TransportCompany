using System;
using TransportCompany.Customer.Application.Dto.Base;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerRidesQueryDto : CustomerRideDetailsDtoBase
    {
        public DateTime FinishedDate { get; set; }
    }
}
