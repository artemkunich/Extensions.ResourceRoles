using System.Reflection;

namespace ResourceRoles.Internal;

internal class DefaultAssemblyRoles
{
    public Assembly Assembly { get; init; }
    public string[] Roles { get; init; }
}