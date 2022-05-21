using Caesar.Application.Common.Interfaces;
using Caesar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caesar.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<CaesarContext>(options => 
                options.UseNpgsql(configuration["ConnectionString"],
                contextOpts => contextOpts.SetPostgresVersion(9, 6)));

            services.AddScoped<ICaesarContext>(provider => provider.GetService<CaesarContext>());

            return services;
        }
    }
}