using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Domain.Services
{
    public interface ICustomerService : IDomainService
    {
        void UpdateCustomer(Entities.Customer customer, string name, string surname, string phoneNumber, string email);
    }
}
