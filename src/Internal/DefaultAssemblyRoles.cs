using System.Reflection;

namespace Akunich.Extensions.ResourceRoles.Internal;

internal class DefaultAssemblyRoles
{
    public Assembly Assembly { get; init; }
    public string[] Roles { get; init; }
}