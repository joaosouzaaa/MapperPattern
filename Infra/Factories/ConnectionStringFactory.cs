using Microsoft.Extensions.Configuration;

namespace Infra.Factories;
public static class ConnectionStringFactory
{
    public static string GetConnectionString(this IConfiguration configuration)
    {
        if (Environment.GetEnvironmentVariable("DOCKER_ENVIROMENT") == "DEV_DOCKER_MAPPER")
            return configuration.GetConnectionString("ContainerConnection")!;

        return configuration.GetConnectionString("LocalConnection")!;
    }
}
