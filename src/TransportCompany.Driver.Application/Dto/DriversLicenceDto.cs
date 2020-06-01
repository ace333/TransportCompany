using System;

namespace TransportCompany.Driver.Application.Dto
{
    public sealed class DriversLicenceDto
    {
        public string DriversLicenseNumber { get; set; }
        public DateTime DriversLicenseDateOfIssue { get; set; }
        public DateTime DriversLicenseExpiryDate { get; set; }
    }
}
