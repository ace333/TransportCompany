using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Customer.Domain.ValueObjects
{
    public class DriverDetails : ValueObject
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }
        public string CarRegistrationPlateNumber { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToUpper();
            yield return Math.Round(Grade, 2);
            yield return PhoneNumber.ToUpper();
            yield return CarModel.ToUpper();
            yield return CarRegistrationPlateNumber.ToUpper();
        }
    }
}
