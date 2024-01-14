using Domain.Constants.EnviromentConstants;
using Microsoft.Extensions.Configuration;

namespace Infra.Factories;
public static class ConnectionStringFactory
{
    public static string GetConnectionString(this IConfiguration configuration)
    {
        if (Environment.GetEnvironmentVariable("DOCKER_ENVIROMENT") == ContainerContants.DockerEnviroment)
            return configuration.GetConnectionString("ContainerConnection")!;

        return configuration.GetConnectionString("LocalConnection")!;
    }
}
