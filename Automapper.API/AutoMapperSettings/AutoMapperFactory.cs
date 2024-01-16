using System.Reflection;

namespace AutoMapper.API.AutoMapperSettings;

public static class AutoMapperFactory
{
    public static IMapper Mapper { get; private set; }

    public static void Inicialize()
    {
        var mapperConfiguration = new MapperConfiguration(mapperConfiguration =>
        {
            var profiles = Assembly.GetExecutingAssembly().GetExportedTypes().Where(p => p.IsClass && typeof(Profile).IsAssignableFrom(p));

            foreach (var profile in profiles)
                mapperConfiguration.AddProfile((Profile)Activator.CreateInstance(profile)!);
        });

        Mapper = mapperConfiguration.CreateMapper();
    }
}
