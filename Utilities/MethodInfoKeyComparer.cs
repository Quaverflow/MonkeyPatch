using System.Reflection;
using Utilities.ExtensionMethods;

namespace Utilities;

internal class MethodInfoKeyComparer : IEqualityComparer<MethodInfo>
{
    public bool Equals(MethodInfo? x, MethodInfo? y) => x.GetKey() == y.GetKey();
    public int GetHashCode(MethodInfo obj) => HashCode.Combine(obj.GetKey());
}
