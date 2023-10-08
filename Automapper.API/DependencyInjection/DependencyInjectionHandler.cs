using AutoMapper.API.AutoMapperSettings;
using Infra.DependencyInjection;

namespace AutoMapper.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraDependencyInjectionHandler(configuration);

        AutoMapperFactory.Inicialize();
    }

    public static void UseAppHandler(this IApplicationBuilder app)
    {
        app.UseInfraSettings();
    }
}
