using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolios.Persistence.Context;

namespace Portfolios.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<PortfolioDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PortfoliosDB")));

            return services;
        }
    }
}
