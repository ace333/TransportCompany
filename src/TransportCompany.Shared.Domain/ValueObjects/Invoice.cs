using System;
using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Domain.ValueObjects
{
    public class Invoice: ValueObject
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] Content { get; set; }

        public Invoice(int issuerId, byte[] content)
        {
            CreatedDate = DateTime.UtcNow;
            Name = $"{issuerId}_Invoice_{CreatedDate.ToString("dd-MM-yyyy_HH-mm-ss")}.pdf";
            Content = content;
        }

        protected Invoice() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToUpper();
            yield return CreatedDate;
        }
    }
}
