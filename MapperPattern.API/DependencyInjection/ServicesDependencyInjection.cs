using MapperPattern.API.Interfaces.Services;
using MapperPattern.API.Services;

namespace MapperPattern.API.DependencyInjection;

public static class ServicesDependencyInjection
{
    public static void AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();

        services.AddScoped<IColorFacadeService, ColorService>();
        services.AddScoped<IColorService, ColorService>();
    }
}
