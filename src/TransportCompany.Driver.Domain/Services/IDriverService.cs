using System;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.Services;
using TransportCompany.Shared.Domain.ValueObjects;
using TDriver = TransportCompany.Driver.Domain.Entities.Driver;

namespace TransportCompany.Driver.Domain.Services
{
    public interface IDriverService : IDomainService
    {
        TDriver CreateDriver(string name, string surname, string phoneNumber, string email, Country nationality);
        void UpdateDriver(TDriver driver, string name, string surname, string phoneNumber, string email);
        void UpdateDriversCar(TDriver driver, string carModel, string carRegistrationPlateNumber);
        void UpdateDriversCompanyDetails(TDriver driver, string companyName, string ownerName, BankDetails bankDetails,
            Address address, int taxIdentificationNumber, int nationalEconomyRegisterNumber);
        void UpdateDriversLicense(TDriver driver, string licenseNumber, DateTime dateOfIssue, DateTime expiryDate);
        Invoice GenerateInvoice(int driverId, PersonalInfo driversPersonalInfo, CompanyDetails comapnyDetails, 
            Money rideIncome);
        void RecalculateDriversGrade(TDriver driver, decimal grade);
    }
}
