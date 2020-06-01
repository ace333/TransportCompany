using TransportCompany.Order.Domain.Enums;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Order.Application.Dto
{
    public sealed class OrdersQueryDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Comments { get; set; }
        public Country ExecutionCountry { get; set; }
        public string Currency { get; set; }
        public decimal NetPaymentAmount { get; set; }           
    }
}
