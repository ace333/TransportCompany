using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency.ToUpper();
            yield return Math.Round(Amount, 2);
        }
    }
}
