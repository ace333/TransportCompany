using TransportCompany.Shared.Domain.Services;
using TCustomer = TransportCompany.Customer.Domain.Entities.Customer;

namespace TransportCompany.Customer.Domain.Services
{
    public interface ICustomerService : IDomainService
    {
        void RecalculateCustomerGrade(TCustomer customer, decimal grade);
        void UpdateCustomer(TCustomer customer, string name, string surname, string phoneNumber, string email);
    }
}
