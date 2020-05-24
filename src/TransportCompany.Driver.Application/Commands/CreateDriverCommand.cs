using System;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Domain.Enums;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class CreateDriverCommand : ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Country Nationality { get; set; }
        public string DriversLicenseNumber { get; set; }
        public DateTime DriversLicenseDateOfIssue { get; set; }
        public DateTime DriversLicenseExpiryDate { get; set; }
        public string CarModel { get; set; }
        public string CarRegistrationPlateNumber { get; set; }
    }
}
