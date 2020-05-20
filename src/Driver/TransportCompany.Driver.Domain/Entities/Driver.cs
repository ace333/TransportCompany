using System.Collections.Generic;
using System.Linq;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Entities
{
    public class Driver : AggregateRoot
    {
        public PersonalInfo PersonalInfo { get; set; }
        public SystemInfo SystemInfo { get; set; }
        public DriversLicense DriversLicense { get; set; }
        public Car Car { get; set; }
        public CompanyDetails CompanyDetails { get; set; }
        public DriverPriority Priority { get; set; }

        public ICollection<Ride> Rides { get; set; }

        public void AddRide(Ride ride)
        {
            if (Rides == null) Rides = new List<Ride>();

            Rides.Add(ride);
        }

        public void UpdateGrade(decimal grade) => SystemInfo.Grade = grade;
        public Ride GetCurrentRideWhenNoCustomerPickedUp()
            => Rides.SingleOrDefault(x => x.Status == RideStatus.OnTheWayToCustomer);
        public Ride GetCurrentRide() => Rides.SingleOrDefault(x => x.Status == RideStatus.OnGoing);
        public Ride GetLastRide()
            => Rides.OrderByDescending(x => x.CreatedDate).FirstOrDefault(x => x.Status == RideStatus.Completed);
    }
}
