using System.Collections.Generic;
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
    }
}
