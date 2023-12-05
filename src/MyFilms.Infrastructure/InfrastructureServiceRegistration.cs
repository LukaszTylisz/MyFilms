using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFilms.Application.Contracts.Logging;

using MyFilms.Infrastructure.Logging;


namespace MyFilms.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}