namespace TransportCompany.Shared.Application.Dto
{
    public sealed class DriverDetailsDto
    {
        public string Name { get; set; }
        public decimal Grade { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }
        public string CarRegistrationPlateNumber { get; set; }
    }
}
