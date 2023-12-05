using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyFilms.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddHttpContextAccessor()
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}