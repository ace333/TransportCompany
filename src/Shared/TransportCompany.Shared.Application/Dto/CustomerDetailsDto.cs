namespace TransportCompany.Shared.Application.Dto
{
    public sealed class CustomerDetailsDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Grade { get; set; }
    }
}
