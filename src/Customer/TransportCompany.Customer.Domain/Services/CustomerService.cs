namespace TransportCompany.Customer.Domain.Services
{
    public sealed class CustomerService : ICustomerService
    {
        public void RecalculateCustomerGrade(Entities.Customer customer, decimal grade)
        {
            var rideCount = customer.Rides.Count;
            var gradesSum = customer.SystemInfo.Grade * (rideCount - 1);
            var newGrade = (gradesSum + grade) / rideCount;

            customer.UpdateGrade(newGrade);
        }

        public void UpdateCustomer(Entities.Customer customer, string name, string surname, string phoneNumber, string email)
        {
            customer.PersonalInfo.Name = name;
            customer.PersonalInfo.Surname = surname;
            customer.PersonalInfo.PhoneNumber = phoneNumber;
            customer.PersonalInfo.Email = email;
        }
    }
}
