using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public class UpdateDriverCommand : IdCommand, ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
