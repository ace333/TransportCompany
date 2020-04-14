using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Shared.Domain.ValueObjects
{
    public class PersonalInfo: ValueObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Country Nationality { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
            yield return PhoneNumber;
            yield return Email;
            yield return Nationality;
        }
    }
}
