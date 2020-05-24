using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class UpdateCarCommand : IdCommand, ICommand
    {
        public string CarModel { get; set; }
        public string CarRegistrationPlateNumber { get; set; }
    }
}
