using System.Collections.Generic;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public PersonalInfo PersonalInfo { get; set; }
        public SystemInfo SystemInfo { get; set; }

        public ICollection<FavoriteAddress> FavoriteAddresses { get; set; }
        public ICollection<Ride> Rides { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
