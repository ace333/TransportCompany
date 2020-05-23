using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Application.Dto
{
    public sealed class CustomersQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Country Nationality { get; set; }
    }
}
