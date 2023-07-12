using System.Reflection;

namespace ResourceRoles.Internal;

internal class ResourceRolesProvider : IResourceRolesProvider
{
    private readonly Dictionary<Type, string[]> _resourcesRoles;
    
    private readonly Dictionary<Assembly, string[]> _defaultAssembliesRoles;
    
    private readonly DefaultRoles _defaultRoles;

    public ResourceRolesProvider(
        IEnumerable<ResourceRoles> resourcesRoles,
        IEnumerable<DefaultAssemblyRoles> defaultAssembliesRoles,
        DefaultRoles defaultRoles = null)
    {
        _resourcesRoles = new Dictionary<Type, string[]>();
        foreach (var resourceRoles in resourcesRoles)
        {
            _resourcesRoles[resourceRoles.ResourceType] = resourceRoles.Roles;
        }
        
        _defaultAssembliesRoles = new Dictionary<Assembly, string[]>();
        foreach (var defaultAssemblyRoles in defaultAssembliesRoles)
        {
            _defaultAssembliesRoles[defaultAssemblyRoles.Assembly] = defaultAssemblyRoles.Roles;
        }

        _defaultRoles = defaultRoles ?? new DefaultRoles { Roles = Array.Empty<string>() };
    }

    public string[] GetRoles(Type resourceType)
    {
        if (_resourcesRoles.TryGetValue(resourceType, out var roles))
            return roles;
        
        if (_defaultAssembliesRoles.TryGetValue(resourceType.Assembly, out roles))
            return roles;

        return _defaultRoles.Roles;
    }
}