namespace TransportCompany.Shared.Application.Dto
{
    public sealed class AddressDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set;  }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
