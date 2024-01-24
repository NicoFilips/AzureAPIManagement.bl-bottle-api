namespace FlaschenPostAPI.Util;

public static class DependencyInjection
{
    /// <summary>
    /// Adds IBeerUtil as a transient service to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the service to.</param>
    public static IServiceCollection AddBottleUtilService(this IServiceCollection services)
    {
        // Registers IBeerUtil as a transient service
        services.AddTransient<IBottleUtil, BottleUtil>();
        return services;
    }
}