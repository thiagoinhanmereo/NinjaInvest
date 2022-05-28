using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Portfolios.Application.Contracts;

namespace Portfolios.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.TryAddScoped<ICommandDispatcher, CommandDispatcher>();
            services.TryAddScoped<IQueryDispatcher, QueryDispatcher>();

            // INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
            services.Scan(selector =>
             {
                 selector.FromAssembliesOf(typeof(IQueryHandler<,>))
                         .AddClasses(filter =>
                         {
                             filter.AssignableTo(typeof(IQueryHandler<,>));
                         })
                         .AsImplementedInterfaces()
                         .WithScopedLifetime();
             });

            services.Scan(selector =>
            {
                selector.FromAssembliesOf(typeof(ICommandHandler<,>))
                        .AddClasses(filter =>
                        {
                            filter.AssignableTo(typeof(ICommandHandler<,>));
                        })
                        .AsImplementedInterfaces()
                        .WithScopedLifetime();
            });


            return services;
        }
    }
}
