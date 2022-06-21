using System.Threading;
using System.Threading.Tasks;
using Caesar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caesar.Application.Common.Interfaces
{
    public interface ICaesarContext
    {
        DbSet<Todo> Todos { get; set; }

        DbSet<Email> Emails { get; set; }

        DbSet<EmailTemplate> EmailTemplates { get; set; }

        DbSet<Phone> Phones { get; set; }

        DbSet<Service> Services { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}