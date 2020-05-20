using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Domain.Entities.PaymentMethods;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public PersonalInfo PersonalInfo { get; set; }
        public SystemInfo SystemInfo { get; set; }

        public ICollection<FavoriteAddress> FavoriteAddresses { get; set; }
        public ICollection<Ride> Rides { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public void AddRide(Ride ride)
        {
            if (!Rides.Any()) Rides = new List<Ride>();
            Rides.Add(ride);
        }

        public void UpdateGrade(decimal grade) => SystemInfo.Grade = grade;
        public Ride GetCurrentRide() => Rides.SingleOrDefault(x => x.Status == RideStatus.OnGoing);
        public Ride GetLastRide() => Rides.OrderByDescending(x => x.CreatedDate)
            .FirstOrDefault(x => x.Status == RideStatus.Completed);

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
