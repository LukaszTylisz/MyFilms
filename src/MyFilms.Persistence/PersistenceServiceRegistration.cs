using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFilms.Application.Contracts.Persistence;
using MyFilms.Persistence.DatabaseContext;
using MyFilms.Persistence.Repositories;
using MyFilms.Persistence.Seeders;

namespace MyFilms.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MovieDatabaseContext>(options =>

            options.UseSqlServer(configuration.GetConnectionString("MyFilmsConnectionString")));
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<DataSeeder>();
        return services;
    }
}