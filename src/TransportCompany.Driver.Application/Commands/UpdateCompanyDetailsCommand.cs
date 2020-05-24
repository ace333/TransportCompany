using TransportCompany.Driver.Application.Dto;
using TransportCompany.Shared.Application.Command;
using TransportCompany.Shared.Application.Dto;

namespace TransportCompany.Driver.Application.Commands
{
    public sealed class UpdateCompanyDetailsCommand : IdCommand, ICommand
    {
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public BankDetailsDto BankDetails { get; set; }
        public AddressDto Address { get; set; }
        public int TaxIdentificationNumber { get; set; }
        public int NationalEconomyRegisterNumber { get; set; }
    }
}
