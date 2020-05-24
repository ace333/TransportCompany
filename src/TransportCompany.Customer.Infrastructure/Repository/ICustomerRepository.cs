using System.Threading.Tasks;
using TransportCompany.Shared.Infrastructure.Persistence;
using TCustomer = TransportCompany.Customer.Domain.Entities.Customer;

namespace TransportCompany.Customer.Infrastructure.Repository
{
    public interface ICustomerRepository : IRepository<TCustomer>
    {
        Task<byte[]> GetCustomerPhotoById(int id);
        Task<TCustomer> GetCustomerWithRides(int id);
        Task<TCustomer> GetCustomerWithRidesAndPaymentMethods(int id);
        Task<TCustomer> GetCustomerWithFavoriteAddresses(int id);
    }
}
