using AutoMapper.API.AutoMapperSettings;
using Infra.DependencyInjection;

namespace AutoMapper.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCorsDependencyInjection();

        services.AddInfraDependencyInjectionHandler(configuration);

        AutoMapperFactory.Inicialize();

        services.AddServicesDependencyInjection();
    }
}
