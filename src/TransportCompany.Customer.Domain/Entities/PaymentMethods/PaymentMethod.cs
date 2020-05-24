using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Customer.Domain.Entities.PaymentMethods
{
    public abstract class PaymentMethod : Entity
    {
        public PaymentMethodType Type { get; set; }
        public bool IsPreffered { get; set; }
        public Customer Customer { get; set; }
    }
}
