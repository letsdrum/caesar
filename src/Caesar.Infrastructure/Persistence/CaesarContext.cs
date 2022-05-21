using System;
using System.Threading;
using System.Threading.Tasks;
using Caesar.Application.Common.Interfaces;
using Caesar.Domain.Common;
using Caesar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caesar.Infrastructure.Persistence
{
    public class CaesarContext : DbContext, ICaesarContext
    {
        public DbSet<Todo> Todos { get; set; }

        public CaesarContext(DbContextOptions options) 
            : base(options)
        {

        }

        public override int SaveChanges()
        {
            AuditEntities();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AuditEntities();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void AuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}