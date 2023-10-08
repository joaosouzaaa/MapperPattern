using Infra.DatabaseContexts;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.DependencyInjection;
public static class InfraDependencyInjectionHandler
{
    public static void AddInfraDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MapperPatternDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LocalConnection"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
    }

    public static void UseInfraSettings(this IApplicationBuilder app)
    {
        MigrationHandler.MigrateDatabase(app);
    }
}
