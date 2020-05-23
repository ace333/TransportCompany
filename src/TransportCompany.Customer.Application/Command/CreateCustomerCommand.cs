using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Customer.Application.Command
{
    public sealed class CreateCustomerCommand : ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Country Nationality { get; set; }
    }
}
