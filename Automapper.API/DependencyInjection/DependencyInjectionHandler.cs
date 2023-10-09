using AutoMapper.API.AutoMapperSettings;
using AutoMapper.API.Interfaces;
using AutoMapper.API.Services;
using Infra.DependencyInjection;

namespace AutoMapper.API.DependencyInjection;

public static class DependencyInjectionHandler
{
    public static void AddDependencyInjectionHandler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfraDependencyInjectionHandler(configuration);

        AutoMapperFactory.Inicialize();

        services.AddScoped<ICarService, CarService>();
    }
}
