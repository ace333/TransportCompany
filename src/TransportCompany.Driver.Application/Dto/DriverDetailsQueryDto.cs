using TransportCompany.Driver.Domain.Enums;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriverDetailsQueryDto
    {
        public DriverDetailsQueryDto(string name, 
            string surname, 
            string phoneNumber, 
            string email, 
            Country nationality, 
            DriverPriority priority,
            decimal grade, 
            CarDto car, 
            CompanyDetailsDto companyDetails, 
            DriversLicenceDto driversLicence)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Nationality = nationality;
            Priority = priority;
            Grade = grade;
            Car = car;
            CompanyDetails = companyDetails;
            DriversLicence = driversLicence;
        }

        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public Country Nationality { get; }
        public DriverPriority Priority { get; }
        public decimal Grade { get; }
        public CarDto Car { get; }
        public CompanyDetailsDto CompanyDetails { get; }
        public DriversLicenceDto DriversLicence { get; }
    }
}
