using System;

namespace TransportCompany.Shared.Application.Dto
{
    public sealed class InvoiceDto
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] Content { get; set; }
    }
}
