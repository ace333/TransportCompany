using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Order.Domain.ValueObjects
{
    public class PaymentAmount: ValueObject
    {
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public int Tax { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(NetValue, 2);
            yield return Math.Round(GrossValue, 2);
            yield return Tax;
        }
    }
}
