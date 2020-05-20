using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Domain.ValueObjects
{
    public class SystemInfo: ValueObject
    {
        public decimal Grade { get; set; }
        public DateTime? UpdatedDate { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Grade;
            yield return UpdatedDate;
        }
    }
}
