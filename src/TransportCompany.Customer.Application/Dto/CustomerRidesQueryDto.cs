using System;
using TransportCompany.Customer.Application.Dto.Base;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerRidesQueryDto : CustomerRideDetailsDtoBase
    {
        public int Id { get; set; }
        public DateTime? FinishedDate { get; set; }
        public string CarModel { get; set; }
    }
}
