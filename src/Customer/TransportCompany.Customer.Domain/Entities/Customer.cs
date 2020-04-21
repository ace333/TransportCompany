using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.Enums;
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

        public Ride GetCurrentRide() => Rides.SingleOrDefault(x => x.Status == RideStatus.OnGoing);

        protected Customer()
        {
            FavoriteAddresses = new List<FavoriteAddress>();
            Rides = new List<Ride>();
            PaymentMethods = new List<PaymentMethod>();

            SystemInfo = new SystemInfo();
        }

        public Customer(string name, string surname, string phoneNumber, string email, Country nationality)
            : this()
        {
            PersonalInfo = new PersonalInfo
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Email = email,
                Nationality = nationality
            };
        }
    }
}
