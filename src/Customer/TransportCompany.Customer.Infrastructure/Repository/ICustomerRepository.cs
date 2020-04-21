using System.Threading.Tasks;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Repository
{
    public interface ICustomerRepository : IRepository<Domain.Entities.Customer>
    {
        Task<byte[]> GetCustomerPhotoById(int id);
        Task<Domain.Entities.Customer> GetCustomerWithRides(int id);
        Task<Domain.Entities.Customer> GetCustomerWithPaymentMethods(int id);
        Task<Domain.Entities.Customer> GetCustomerWithFavoriteAddresses(int id);
    }
}
