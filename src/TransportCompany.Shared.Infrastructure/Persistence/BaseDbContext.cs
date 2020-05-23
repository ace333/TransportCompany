using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Infrastructure.Persistence
{
    public abstract class BaseDbContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        private readonly IBusControl _busControl;

        protected BaseDbContext(DbContextOptions<TDbContext> options, IBusControl busControl)
        {
            _busControl = busControl;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .SelectMany(x => x.Entity.DomainEvents);

            foreach (var @event in domainEvents)
            {
                await _busControl.Publish(@event, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
