using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomerDetailsQueryDto
    {
        public CustomerDetailsQueryDto(string name, string surname, string phoneNumber, string email,
            Country nationality, decimal grade)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Nationality = nationality;
            Grade = grade;
        }

        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public Country Nationality { get; }
        public decimal Grade { get; }
    }
}
