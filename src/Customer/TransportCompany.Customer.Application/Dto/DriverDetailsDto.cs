namespace TransportCompany.Customer.Application.Dto
{
    public sealed class DriverDetailsDto
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public byte[] Photo { get; set; }
        public string CarModel { get; set; }
    }
}
