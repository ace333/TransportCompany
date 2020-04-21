using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Customer.Application.Command
{
    public class UpdateCustomerCommand : IdCommand, ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
