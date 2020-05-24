using System;
using System.Collections.Generic;
using System.Linq;
using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.Entities
{
    public class Ride : Entity
    {
        protected Ride() { }

        public Ride(RideStatus status, 
            Money income, 
            int customerId,
            CustomerDetails customerDetails,            
            params DestinationPoint[] stops)
        {
            Status = status;
            Income = income;
            CustomerId = customerId;
            CustomerDetails = customerDetails;            
            Stops = stops;
        }
        
        public RideStatus Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Money Income { get; set; }
        public int CustomerId { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public Invoice Invoice { get; set; }

        public Driver Driver { get; set; }
        public IEnumerable<DestinationPoint> Stops { get; set; }

        public void Cancel() => Status = RideStatus.Cancelled;
        public void Complete() => Status = RideStatus.Completed;
        public void PickupCustomer() => Status = RideStatus.OnGoing;

        public void RemoveStop(DestinationPoint destinationPoint) => Stops = Stops.Where(x => x != destinationPoint);
    }
}
