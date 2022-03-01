﻿using System.Collections.Concurrent;
using MonkeyPatcher.MonkeyPatch.Concrete.Dto;
using MonoMod.RuntimeDetour;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Utilities;
using Utilities.ExtensionMethods;

namespace MonkeyPatcher.MonkeyPatch.Concrete;

public class MonkeyPatch : IDisposable
{
    private static readonly List<IDetour?> _detours = new();
    private static List<MethodStructure> _systemUnderTest;
    private static ConcurrentQueue<(int, MethodStructure)> _systemUnderTestCallSpecific = new();
    private readonly Delegate _disposed;
    internal MonkeyPatch(Delegate disposed, MethodInfo caller, int maxScanningDepth)
    {
        _disposed = disposed;
        _systemUnderTest = caller.BuildMap(maxScanningDepth);
    }

    private static MethodStructure? GetStructure(MethodInfo original) => _systemUnderTest.FirstOrDefault(x => x.Key == original.GetKey());

    internal void Patch<TReturn>(MethodInfo original, Delegate? actual)
    {
        ProcessStructure(original, actual);

        var returnType = typeof(TReturn);
        if (typeof(TReturn).BaseType == typeof(Task))
        {
            var t = typeof(TReturn).GetGenericArguments();
            returnType = typeof(TReturn).GetGenericArguments().FirstOrDefault();
        }

        if (returnType.IsClass)
        {
            var method = WrapRefType;
            _detours.Add(new NativeDetour(original, method.Method));
        }
        else
        {
            var method = Wrap<TReturn>;
            _detours.Add(new NativeDetour(original, method.Method));
        }
    }
    internal void Patch(MethodInfo original, Delegate? actual)
    {
        ProcessStructure(original, actual);

        var method = WrapRefType;
        _detours.Add(new NativeDetour(original, method.Method));
    }

    private static void ProcessStructure(MethodInfo original, Delegate? actual)
    {
        actual.ThrowIfNull();

        MethodStructure? structure = null;
        var counter = 0;
        while (structure == null)
        {
            Thread.Sleep(1);
            counter++;
            (counter != 2000).ThrowIfAssumptionFailed("Internal error. Patcher hung.");

            structure = GetStructure(original);
            if (structure != null)
            {
                structure.IsDetoured = true;
                structure.Action = actual;
                break;
            }
        }
    }

    private static TReturn? Wrap<TReturn>(TReturn? returns)
    {
        var patch = GetStructure();
        try
        {
            var result = patch.Action.DynamicInvoke();
            if (result == null)
            {
                return default;
            }
            return (TReturn)result;
        }
        catch (Exception e)
        {
            _systemUnderTestCallSpecific.Clear();
            throw e.InnerException ?? e;
        }
    }
    private static object? WrapRefType()
    {
        var patch = GetStructure();
        try
        {
            var result = patch.Action.DynamicInvoke();
            return result;
        }
        catch (Exception e)
        {
            _systemUnderTestCallSpecific.Clear();
            throw e.InnerException;
        }
    }

    private static MethodStructure GetStructure()
    {
        if (!_systemUnderTestCallSpecific.Any())
        {
            _systemUnderTestCallSpecific = new ConcurrentQueue<(int, MethodStructure)>();
            var distinct = _systemUnderTest.Where(x => x.IsDetoured);
            foreach (var method in distinct)
            {
                for (var i = 0; i < method.Indexes.Count; i++)
                {
                    var t = method.Indexes[i];
                    _systemUnderTestCallSpecific.Enqueue((t, method));
                }
            }

        }

        (int, MethodStructure) sut;
        var counter = 0;
        while (!_systemUnderTestCallSpecific.TryDequeue(out sut))
        {
            Thread.Sleep(1);
            counter++;
            (counter != 2000).ThrowIfAssumptionFailed("Internal error. Patcher hung.");
        }
        return sut.Item2;
    }

    /// <summary>
    /// For methods that should return null or a value, with an optional callback function.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="expression"></param>
    /// <param name="actual"></param>
    //public void Override<TClass, TResult>(Expression<Func<TClass, TResult>> expression, Func<TResult> actual) where TClass : class
    //      => Patch(GenerateMethodInfo(expression.Body), actual);
    public void Override<TClass, TResult>(Expression<Func<TClass, TResult>> expression, Func<TResult>? actual) where TClass : class
          => Patch<TResult>(GenerateMethodInfo(expression.Body), actual);

    /// <summary>
    /// For void methods, with an optional callback.
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <param name="expression"></param>
    /// <param name="actual"></param>
    public void OverrideVoid<TClass>(Expression<Action<TClass>> expression, Action? actual = null) where TClass : class
    {
        Patch(GenerateMethodInfo(expression.Body), actual ?? EmptyMethod);
    }

    private static MethodInfo GenerateMethodInfo(Expression expression) => ((MethodCallExpression)expression).Method;

    /// <summary>
    /// For accessing non public methods with a return type
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="methodInfo"></param>
    public void OverrideNonPublicMethod<TClass, TResult>(NonPublicMethodInfo<TResult> methodInfo) where TClass : class
    {
        var (methodName, accessType, actual, methodParameters) = methodInfo;
        var originalMethod = ReflectionHelpers.FindMethod<TClass>(methodName, accessType.GetBindingFlags(), methodParameters);
        Patch<TResult>(originalMethod, actual);
    }

    /// <summary>
    /// For accessing non public void methods
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <param name="methodInfo"></param>
    public void OverrideNonPublicVoidMethod<TClass>(NonPublicVoidMethodInfo methodInfo) where TClass : class
    {
        var (methodName, accessType, methodParameters) = methodInfo;
        var originalMethod = ReflectionHelpers.FindMethod<TClass>(methodName, accessType.GetBindingFlags(), methodParameters);
        Patch(originalMethod, () => 0);
    }

    /// <summary>
    /// For accessing non public void methods
    /// </summary>
    /// <typeparam name="TClass"></typeparam>
    /// <param name="methodInfo"></param>
    public void OverrideNonPublicVoidMethodInvokeAction<TClass>(NonPublicVoidMethodWithActionInfo methodInfo) where TClass : class
    {
        var (methodName, accessType, actual, methodParameters) = methodInfo;
        var originalMethod = ReflectionHelpers.FindMethod<TClass>(methodName, accessType.GetBindingFlags(), methodParameters);
        Patch(originalMethod, actual);
    }

    private static void EmptyMethod() { }

    public void Dispose()
    {
        _systemUnderTest.Clear();
        _systemUnderTestCallSpecific.Clear();
        foreach (var x in _detours)
        {
            x?.Dispose();
        }
        _detours.Clear();
        _disposed.DynamicInvoke(true);
        GC.SuppressFinalize(this);
    }
}