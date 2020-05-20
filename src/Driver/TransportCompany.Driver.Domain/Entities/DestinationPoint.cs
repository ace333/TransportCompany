using System;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Entities
{
    public class DestinationPoint : Entity
    {
        protected DestinationPoint() { }

        public DestinationPoint(PointStatus pointStatus, PointType pointType, Address address)
        {
            Status = pointStatus;
            Type = pointType;
            Address = address;
        }

        public Address Address { get; set; }
        public PointStatus Status { get; set; }
        public PointType Type { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Ride Ride { get; set; }
    }
}
