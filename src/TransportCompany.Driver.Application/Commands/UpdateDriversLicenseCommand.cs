using System;
using TransportCompany.Shared.Application.Command;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class UpdateDriversLicenseCommand : IdCommand, ICommand
    {
        public string DriversLicenseNumber { get; set; }
        public DateTime DriversLicenseDateOfIssue { get; set; }
        public DateTime DriversLicenseExpiryDate { get; set; }
    }
}
