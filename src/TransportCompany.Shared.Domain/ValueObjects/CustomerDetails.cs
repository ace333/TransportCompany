using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Domain.ValueObjects
{
    public class CustomerDetails : ValueObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Grade { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToUpper();
            yield return Surname.ToUpper();
            yield return PhoneNumber.ToUpper();
            yield return Email.ToUpper();
            yield return Math.Round(Grade, 2);
        }
    }
}
