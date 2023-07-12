namespace ResourceRoles;

public interface IResourceRolesProvider
{
    string[] GetRoles(Type resourceType);
}

public static class ResourceRolesProviderExtensions
{
    public static string[] GetRoles<TResource>(this IResourceRolesProvider provider) =>
        provider.GetRoles(typeof(TResource));
}