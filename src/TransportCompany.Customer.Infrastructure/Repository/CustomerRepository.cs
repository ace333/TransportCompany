using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Customer.Infrastructure.Repository
{
    public class CustomerRepository : Repository<Domain.Entities.Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
            : base(customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<byte[]> GetCustomerPhotoById(int id)
        {
            return await _customerDbContext.Customers.Where(x => x.Id == id)
                .Select(x => x.PersonalInfo.Photo)
                .SingleOrDefaultAsync();
        }

        public async Task<Domain.Entities.Customer> GetCustomerWithRides(int id)
        {
            return await _customerDbContext.Customers
                .Include(x => x.Rides)
                    .ThenInclude(y => y.Routes)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Domain.Entities.Customer> GetCustomerWithPaymentMethods(int id)
        {
            return await _customerDbContext.Customers
                .Include(x => x.PaymentMethods)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Domain.Entities.Customer> GetCustomerWithFavoriteAddresses(int id)
        {
            return await _customerDbContext.Customers
                .Include(x => x.FavoriteAddresses)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}
