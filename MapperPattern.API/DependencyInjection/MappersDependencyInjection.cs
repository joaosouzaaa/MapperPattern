using MapperPattern.API.Interfaces.Mappers;
using MapperPattern.API.Mappers;

namespace MapperPattern.API.DependencyInjection;

public static class MappersDependencyInjection
{
    public static void AddMappersDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICarFeatureMapper, CarFeatureMapper>();
        services.AddScoped<ICarMapper, CarMapper>();
        services.AddScoped<IColorMapper, ColorMapper>();
        services.AddScoped<IEngineMapper, EngineMapper>();
    }
}
