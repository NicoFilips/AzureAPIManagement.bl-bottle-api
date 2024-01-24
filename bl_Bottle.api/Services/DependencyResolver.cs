using FlaschenPostAPI.Util;

namespace FlaschenPostAPI.Services;

public static class DependencyResolver
{

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddBottleUtilService();
        return services;
    }
}