using Mono.Reflection;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static Utilities.Constants.BindingFlagsConst;

namespace Utilities.ExtensionMethods;

public static class ReflectionHelpers
{
    public static MethodInfo? MethodFinder(Type typeToQuery, string methodName, BindingFlags flags, params Type[] parameters)
        => typeToQuery.GetMethod(methodName, flags, parameters);

    public static MethodInfo? MethodFinder(Type typeToQuery, string methodName, BindingFlags flags)
        => typeToQuery.GetMethod(methodName, flags);

    public static MethodInfo FindMethod<T>(string methodName, BindingFlags flags, Type[]? methodParameters)
    {
        MethodInfo? method;
        try
        {
            method = methodParameters is { Length: 0 } ? MethodFinder(typeof(T), methodName, flags) : MethodFinder(typeof(T), methodName, flags, methodParameters ?? Type.EmptyTypes);
        }
        catch
        {
            throw new AmbiguousMatchException(@"More than one method with the same signature and return type were found. 
                                                       Please use the overload that takes a MethodInfo. You can use the ReflectionHelpers
                                                        to easily find the right overload.");
        }

        method.ThrowIfNull("Method was not found. Verify the access modifier.");

        if (method.GetMethodBody() == null)
        {
            throw new InvalidOperationException("Use the MonkeyIPatcher for mocking interfaces.");
        }
        return method;
    }

    public static string GetSignature(this MethodInfo method)
        => $"{AccessModifiers(method)}{ReturnType(method.ReturnType)} { method.Name}{TypeParameters(method)}({Parameters(method)})";

    private static string Parameters(MethodBase method)
    {
        var parameters = method.GetParameters();
        if (!parameters.Any())
        {
            return string.Empty;
        }

        var stringBuilder = new StringBuilder();

        var firstParam = true;
        var secondParam = false;
        foreach (var param in parameters)
        {
            if (firstParam)
            {
                firstParam = false;
                if (method.IsDefined(typeof(ExtensionAttribute), false))
                {
                    stringBuilder.Append("this ");
                    secondParam = true;
                    continue;
                }
            }
            else if (secondParam)
            {
                secondParam = false;
            }
            else
            {
                stringBuilder.Append(", ");
            }

            if (param.ParameterType.IsByRef)
            {
                stringBuilder.Append("ref ");
            }
            else if (param.IsOut)
            {
                stringBuilder.Append("out ");
            }
            stringBuilder.Append(param.ParameterType);
            stringBuilder.Append(" ");
            stringBuilder.Append(param.Name);
        }

        return stringBuilder.ToString();
    }

    private static string TypeParameters(MethodBase method)
    {
        if (!method.IsGenericMethod)
        {
            return string.Empty;
        }

        var stringBuilder = new StringBuilder();
        stringBuilder.Append("<");

        var genericArgs = method.GetGenericArguments();
        stringBuilder.Append(ReturnType(genericArgs[0]));

        for (var i = 1; i < genericArgs.Length; i++)
        {
            var argument = genericArgs[i];
            stringBuilder.Append(", ");
            stringBuilder.Append(ReturnType(argument));
        }

        stringBuilder.Append(">");

        return stringBuilder.ToString();

    }

    private static string AccessModifiers(MethodBase method)
    {
        var stringBuilder = new StringBuilder();
        if (method.IsPublic)
        {
            stringBuilder.Append("public ");
        }
        else if (method.IsPrivate)
        {
            stringBuilder.Append("private ");
        }
        else if (method.IsAssembly)
        {
            stringBuilder.Append("internal ");
        }

        if (method.IsFamily)
        {
            stringBuilder.Append("protected ");
        }

        if (method.IsStatic)
        {
            stringBuilder.Append("static ");
        }

        return stringBuilder.ToString();
    }

    public static string ReturnType(Type type)
    {
        var nullableType = Nullable.GetUnderlyingType(type);
        if (nullableType != null)
        {
            return nullableType.Name + "?";
        }

        if (!(type.IsGenericType && type.Name.Contains('`')))
        {
            return type.Name switch
            {
                "String" => "string",
                "Int32" => "int",
                "Decimal" => "decimal",
                "Object" => "object",
                "Void" => "void",
                _ => string.IsNullOrWhiteSpace(type.FullName) ? type.Name : type.FullName
            };
        }

        var stringBuilder = new StringBuilder(type.Name[..type.Name.IndexOf('`')]
        );
        stringBuilder.Append('<');
        var first = true;
        foreach (var t in type.GetGenericArguments())
        {
            if (!first)
            {
                stringBuilder.Append(',');
            }
            stringBuilder.Append(ReturnType(t));
            first = false;
        }
        stringBuilder.Append('>');
        return stringBuilder.ToString();
    }

    public static bool IsAsync(this MethodInfo method)
        => method.GetCustomAttribute<AsyncStateMachineAttribute>()?
                    .StateMachineType
                    .GetCustomAttribute<CompilerGeneratedAttribute>() != null;

    public static BindingFlags GetBindingFlags(this AccessType type)
        => type switch
        {
            AccessType.Private => BindingFlags.NonPublic | BindingFlags.Instance,
            AccessType.PrivateStatic => BindingFlags.NonPublic | BindingFlags.Static,
            AccessType.Public => BindingFlags.Public | BindingFlags.Instance,
            AccessType.PublicStatic => BindingFlags.Public | BindingFlags.Static,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "specified access type doesn't exist.")
        };

    public static MethodInfo[] GetLocalMethods(this MethodInfo? caller)
    {
        if (caller?.DeclaringType != null && (caller.DeclaringType.IsAbstract || caller.DeclaringType.IsInterface || caller.GetMethodBody() == null))
        {
            return Array.Empty<MethodInfo>();
        }

        // the where clause only gets the non null values.
        return (caller?.GetInstructions()
            .Where(x => x.Operand is MethodInfo)
            .Select(x => x.Operand as MethodInfo)
            .ToArray() ?? Array.Empty<MethodInfo>())!;
    }

    public static MethodInfo[] ExtractInnerMethodsFromAsyncMethod(this MethodInfo caller)
    {
        var stateMachine = caller.GetCustomAttribute<AsyncStateMachineAttribute>().ThrowIfNull();
        return stateMachine.StateMachineType.GetMethod("MoveNext", AllFlags).GetLocalMethods();
    }

    public static string GetKey(this MethodInfo methodInfo) =>
        $"{methodInfo.DeclaringType?.FullName}: {methodInfo.GetSignature()}";
}