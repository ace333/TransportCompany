﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportCompany.Driver.Domain.ValueObjects;
using TransportCompany.Shared.Domain.Base;

namespace TransportCompany.Driver.Infrastructure.Configurations
{
    public class SystemInfoConfiguration
    {
        public static void Configure<TEntity>(OwnedNavigationBuilder<TEntity, SystemInfo> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Grade)
                .HasColumnType("decimal(18, 2)");

            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate();
        }
    }
}
