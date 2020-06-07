using System;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Entities
{
    public class DestinationPoint : Entity
    {
        protected DestinationPoint() { }

        public DestinationPoint(PointStatus pointStatus, Address address, DestinationPoint previousPoint = null)
        {
            Status = pointStatus;
            Address = address;
            PreviousPoint = previousPoint;
        }

        public Address Address { get; set; }
        public PointStatus Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DestinationPoint PreviousPoint { get; set; }

        public Ride Ride { get; set; }

        public void Update(PointStatus status)
        {
            UpdatedDate = DateTime.Now;
            Status = status;
        }
    }
}
