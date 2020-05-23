using System;
using System.Collections.Generic;
using System.Linq;
using TransportCompany.Customer.Domain.Enums;
using TransportCompany.Customer.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Customer.Domain.Entities
{
    public class Ride : Entity
    {
        protected Ride() { }

        public Ride(Money price, int driverId, DriverDetails driverDetails, params Route[] routes)
        {
            Price = price;
            DriverId = driverId;
            DriverDetails = driverDetails;
            Routes = routes;
            Status = RideStatus.WaitingForDriver;
        }

        public DateTime? FinishedDate { get; set; }
        public RideStatus Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Money Price { get; set; }
        public int DriverId { get; set; }
        public DriverDetails DriverDetails { get; set; }
        public Invoice Invoice { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Route> Routes { get; set; }

        public void Cancel() 
        {
            FinishedDate = DateTime.Now;
            Status = RideStatus.Cancelled;
        }

        public void AddRoute(Route route) => Routes.Add(route);
        public void RemoveRoute(Route route) => Routes.Remove(route);
        public Route GetRoute(int routeId) => Routes.SingleOrDefault(x => x.Id == routeId);
    }
}
