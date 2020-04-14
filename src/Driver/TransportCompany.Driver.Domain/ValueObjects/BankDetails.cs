using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Domain.ValueObjects
{
    public class BankDetails : ValueObject
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AccountNumber.ToUpper();
            yield return BankName.ToUpper();
        }
    }
}
