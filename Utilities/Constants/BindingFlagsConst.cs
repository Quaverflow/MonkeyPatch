using System.Reflection;

namespace Utilities.Constants;

public static class BindingFlagsConst
{
    public const BindingFlags AllFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
}