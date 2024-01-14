using Infra.DependencyInjection;

namespace MapperPattern.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddInfraDependencyInjectionHandler(configuration);

        services.AddMappersDependencyInjection();
        services.AddServicesDependencyInjection();
    }
}
