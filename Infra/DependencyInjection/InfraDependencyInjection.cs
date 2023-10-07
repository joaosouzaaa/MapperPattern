using Infra.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.DependencyInjection;
public static class InfraDependencyInjection
{
    public static void AddInfraDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MapperPatternDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LocalConnection"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
    }
}
