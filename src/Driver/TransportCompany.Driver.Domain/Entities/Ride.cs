using System;
using System.Collections.Generic;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Entities
{
    public class Ride : Entity
    {
        public RideStatus Status { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Money Income { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public Invoice Invoice { get; set; }

        public Driver Driver { get; set; }
        public IEnumerable<DestinationPoint> Stops { get; set; }
    }
}
