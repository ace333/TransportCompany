using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Domain.ValueObjects
{
    public class DriversLicense : ValueObject
    {
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpiryDate { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number.ToUpper();
            yield return DateOfIssue.Date;
            yield return ExpiryDate.Date;
        }
    }
}
