using System.Reflection;
using Akunich.Extensions.ResourceRoles.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Akunich.Extensions.ResourceRoles;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddResourceRolesProvider<TResource>(this IServiceCollection services) =>
        services.AddSingleton<IResourceRolesProvider,ResourceRolesProvider>();
    
    public static IServiceCollection SetRoles<TResource>(this IServiceCollection services, params string[] roles)
    {
        var resourceRoles = new Internal.ResourceRoles
        {
            ResourceType = typeof(TResource),
            Roles = roles
        };

        return services.AddSingleton(resourceRoles);
    }
    
    public static IServiceCollection SetDefaultRoles(this IServiceCollection services, Assembly assembly, params string[] roles)
    {
        var defaultAssemblyRoles = new DefaultAssemblyRoles
        {
            Assembly = assembly,
            Roles = roles
        };

        return services.AddSingleton(defaultAssemblyRoles);
    }
    
    public static IServiceCollection SetDefaultRoles(this IServiceCollection services, params string[] roles)
    {
        var defaultRoles = new DefaultRoles
        {
            Roles = roles
        };

        return services.AddSingleton(defaultRoles);
    }
}