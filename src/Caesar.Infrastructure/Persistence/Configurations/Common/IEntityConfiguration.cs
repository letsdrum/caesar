using System;
using Caesar.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caesar.Infrastructure.Persistence.Configurations.Common
{
    public class IEntityConfiguration : IEntityTypeConfiguration<IEntity>
    {
        public void Configure(EntityTypeBuilder<IEntity> builder)
        {
            builder.Property(p => p.Id)
                .HasDefaultValueSql();
        }
    }
}