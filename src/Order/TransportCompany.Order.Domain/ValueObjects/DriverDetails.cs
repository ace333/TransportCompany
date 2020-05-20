using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Order.Domain.ValueObjects
{
    public class DriverDetails : ValueObject
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public byte[] Photo { get; set; }
        public string CarModel { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToUpper();
            yield return Math.Round(Grade, 2);
            yield return CarModel.ToUpper();
        }
    }
}
