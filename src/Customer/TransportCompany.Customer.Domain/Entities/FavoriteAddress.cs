using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Entities
{
    public class FavoriteAddress : Entity
    {
        public string Name { get; set; }
        public FavoriteAddressType Type { get; set; }
        public Address Address { get; set; }
        public Customer Customer { get; set; }
    }
}
