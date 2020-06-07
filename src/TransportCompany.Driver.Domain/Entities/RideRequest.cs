using System;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Entities
{
    public class RideRequest : Entity
    {
        protected RideRequest() { }

        public RideRequest(int customerId, CustomerDetails customerDetails, Address startPoint, Address destinationPoint)
        {
            CustomerId = customerId;
            CustomerDetails = customerDetails;
            StartPoint = startPoint;
            DestinationPoint = destinationPoint;
            Status = RideRequestStatus.WaitingForDriver;
        }

        public RideRequestStatus Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public Address StartPoint { get; set; }
        public Address DestinationPoint { get; set; }

        public void MarkAsFound() => Status = RideRequestStatus.DriverFound;

    }
}
