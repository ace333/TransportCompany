using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriversQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CarModel { get; set; }
        public string CarRegistrationPlateNumber { get; set; }
        public DriverPriority Priority { get; set; }
        public string CompanyName { get; set; }
        public int TaxIdentificationNumber { get; set; }
        public Country Nationality { get; set; }
    }
}
