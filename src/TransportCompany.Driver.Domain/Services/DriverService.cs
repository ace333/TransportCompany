using System;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Enums;
using TransportCompany.Shared.Domain.ValueObjects;
using TDriver = TransportCompany.Driver.Domain.Entities.Driver;

namespace TransportCompany.Driver.Domain.Services
{
    public class DriverService : IDriverService
    {
        public TDriver CreateDriver(string name, string surname, string phoneNumber, string email, Country nationality)
            => new TDriver(name, surname, phoneNumber, email, nationality);

        public Invoice GenerateInvoice(int driverId, PersonalInfo driversPersonalInfo, CompanyDetails comapnyDetails, 
            Money rideIncome)
        {
            // Method should be able to create a *.pdf invoice file with customer details and payment amount
            // For a demo purposes the file would be just empty byte array
            return new Invoice(driverId, new byte[0]);
        }

        public void UpdateDriver(TDriver driver, string name, string surname, string phoneNumber, string email)
            => driver.Update(name, surname, phoneNumber, email);

        public void UpdateDriversCar(TDriver driver, string carModel, string carRegistrationPlateNumber)
            => driver.UpdateCar(new Car(carModel, carRegistrationPlateNumber));

        public void UpdateDriversCompanyDetails(TDriver driver, string companyName, string ownerName, BankDetails bankDetails, Address address, int taxIdentificationNumber, int nationalEconomyRegisterNumber)
        => driver.UpdateCompanyDetails(
            new CompanyDetails(companyName, ownerName, bankDetails, address, taxIdentificationNumber, 
                nationalEconomyRegisterNumber)
            );

        public void UpdateDriversLicense(TDriver driver, string licenseNumber, DateTime dateOfIssue, DateTime expiryDate)
            => driver.UpdateDriversLicense(new DriversLicense(licenseNumber, dateOfIssue, expiryDate));
    }
}
