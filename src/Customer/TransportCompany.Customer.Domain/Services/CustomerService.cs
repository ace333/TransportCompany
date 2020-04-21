namespace TransportCompany.Customer.Domain.Services
{
    public sealed class CustomerService : ICustomerService
    {
        public void UpdateCustomer(Entities.Customer customer, string name, string surname, string phoneNumber, string email)
        {
            customer.PersonalInfo.Name = name;
            customer.PersonalInfo.Surname = surname;
            customer.PersonalInfo.PhoneNumber = phoneNumber;
            customer.PersonalInfo.Email = email;
        }
    }
}
