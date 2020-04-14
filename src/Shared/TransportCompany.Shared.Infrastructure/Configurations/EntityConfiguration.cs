using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Shared.Infrastructure.Configurations
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> 
        where TEntity: Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd();
        }
    }
}
