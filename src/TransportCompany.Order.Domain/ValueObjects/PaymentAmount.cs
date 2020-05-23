using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Order.Domain.ValueObjects
{
    public class PaymentAmount: ValueObject
    {
        public string Currency { get; set; }
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
        public int Tax { get; set; }

        public PaymentAmount(string currency, decimal grossValue, int tax)
        {
            Currency = currency.ToUpper();
            GrossValue = grossValue;
            Tax = tax;
            NetValue = grossValue * (1 - tax / 100);
        }

        protected PaymentAmount() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(NetValue, 2);
            yield return Math.Round(GrossValue, 2);
            yield return Currency.ToUpper();
            yield return Tax;
        }
    }
}
