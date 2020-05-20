using TransportCompany.Shared.Infrastructure.Model;

namespace TransportCompany.Customer.Domain.Services
{
    public interface ICustomerService : IDomainService
    {
        void RecalculateCustomerGrade(Entities.Customer customer, decimal grade);
        void UpdateCustomer(Entities.Customer customer, string name, string surname, string phoneNumber, string email);
    }
}
