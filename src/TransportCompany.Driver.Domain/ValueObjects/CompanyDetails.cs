using System.Collections.Generic;
using TransportCompany.Shared.Domain.Base;
using TransportCompany.Shared.Domain.ValueObjects;

namespace TransportCompany.Driver.Domain.ValueObjects
{
    public class CompanyDetails : ValueObject
    {
        public CompanyDetails() { }

        public CompanyDetails(string companyName, 
            string ownerName, 
            BankDetails bankDetails, 
            Address address, 
            int taxIdentificationNumber, 
            int nationalEconomyRegisterNumber)
        {
            CompanyName = companyName;
            OwnerName = ownerName;
            BankDetails = bankDetails;
            Address = address;
            TaxIdentificationNumber = taxIdentificationNumber;
            NationalEconomyRegisterNumber = nationalEconomyRegisterNumber;
        }

        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public BankDetails BankDetails { get; set; }
        public Address Address { get; set; }
        public int TaxIdentificationNumber { get; set; }
        public int NationalEconomyRegisterNumber { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CompanyName.ToUpper();
            yield return OwnerName.ToUpper();
            yield return TaxIdentificationNumber;
            yield return NationalEconomyRegisterNumber;
        }
    }
}
