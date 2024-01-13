using AutoMapper.API.Interfaces;
using AutoMapper.API.Services;

namespace AutoMapper.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>(); 

        services.AddScoped<IColorFacadeService, ColorService>();
        services.AddScoped<IColorService, ColorService>();
    }
}
