using System.Collections.Generic;
using System.Linq;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Driver.Domain.Entities
{
    public class Driver : AggregateRoot
    {
        protected Driver()
        {
            Rides = new List<Ride>();

            DriversLicense = new DriversLicense();
            Car = new Car();
            CompanyDetails = new CompanyDetails();
            SystemInfo = new SystemInfo();
        }

        public Driver(string name, string surname, string phoneNumber, string email, Country nationality)
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

        public PersonalInfo PersonalInfo { get; set; }
        public SystemInfo SystemInfo { get; set; }
        public DriversLicense DriversLicense { get; set; }
        public Car Car { get; set; }
        public CompanyDetails CompanyDetails { get; set; }
        public DriverPriority Priority { get; set; }

        public ICollection<Ride> Rides { get; set; }

        public void Update(string name, string surname, string phoneNumber, string email)
        {
            PersonalInfo.Name = name;
            PersonalInfo.Surname = surname;
            PersonalInfo.PhoneNumber = phoneNumber;
            PersonalInfo.Email = email;
        }

        public void UpdateCar(Car car) => Car = car;
        public void UpdateCompanyDetails(CompanyDetails companyDetails) => CompanyDetails = companyDetails;
        public void UpdateDriversLicense(DriversLicense driversLicense) => DriversLicense = driversLicense;
        public void UpdateGrade(decimal grade) => SystemInfo.Grade = grade;

        public Ride GetCurrentRideWhenNoCustomerPickedUp()
            => Rides.SingleOrDefault(x => x.Status == RideStatus.OnTheWayToCustomer);
        public Ride GetCurrentRide() => Rides.SingleOrDefault(x => x.Status == RideStatus.OnGoing);
        public Ride GetLastRide()
            => Rides.OrderByDescending(x => x.CreatedDate).FirstOrDefault(x => x.Status == RideStatus.Completed);

        public void AddRide(Ride ride)
        {
            if (Rides == null) Rides = new List<Ride>();

            Rides.Add(ride);
        }
    }
}
