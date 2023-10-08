using Infra.DependencyInjection;

namespace MapperPattern.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraDependencyInjectionHandler(configuration);
    }

    public static void UseAppHandler(this IApplicationBuilder app)
    {
        app.UseInfraSettings();
    }
}
