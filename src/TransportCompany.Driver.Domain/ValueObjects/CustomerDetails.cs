using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Domain.ValueObjects
{
    public class CustomerDetails: ValueObject
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Grade { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToUpper();
            yield return PhoneNumber.ToUpper();
            yield return Math.Round(Grade, 2);
        }
    }
}
