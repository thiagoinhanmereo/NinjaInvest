using CleanArch.Application.Contracts.Persistence;
using CleanArch.Persistence.Repositories;
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
            services.AddDbContext<PortfoliosDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PortfoliosDB")));
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
