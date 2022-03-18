using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Utilities;

public static class Guards
{
    public static T ThrowIfNull<T>([NotNull] this T? argument, [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument == null)
        {
            throw new ArgumentNullException(paramName);
        }

        return argument;
    }

    public static void ThrowIfNullOrEmptyCollection([NotNull] this object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
    {
        switch (argument)
        {
            case null:
                throw new ArgumentNullException($"{paramName}");
            case IEnumerable<object> objects when !objects.Any():
                throw new ArgumentNullException($"{paramName}");
        }
    }

    public static void ThrowIfAssumptionFailed(this bool conditionToMeet, string message = "The assumption was false.")
    {
        if (!conditionToMeet)
        {
            throw new InvalidOperationException(message);
        }
    }
}
