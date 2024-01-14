using Infra.DatabaseContexts;
using Infra.Factories;
using Infra.Settings.MigrationSettings;
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
            options.UseSqlServer(configuration.GetConnectionString());
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddRepositoriesDependencyInjection();
    }

    public static void UseInfraSettings(this IApplicationBuilder app)
    {
        app.MigrateDatabase();
    }
}
