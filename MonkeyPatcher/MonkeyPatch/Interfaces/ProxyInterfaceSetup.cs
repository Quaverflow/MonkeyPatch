using System.Linq.Expressions;
using System.Reflection;
using Castle.DynamicProxy;

namespace MonkeyPatcher.MonkeyPatch.Interfaces;

public static class InterfaceProxySetup
{
    
    /// <summary>
    /// For setting up methods that should return null or a value, and Properties.
    /// Allows access to the invocation parameters.
    /// Returns the proxy to allow chaining.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="proxy"></param>
    /// <param name="original"></param>
    /// <param name="actual"></param>
    public static Proxy<T> Setup<T, TResult>(this Proxy<T> proxy, Expression<Func<T, TResult>> original, Func<IInvocation, TResult>? actual) where T : class
    {
        switch (original.Body)
        {
            case MethodCallExpression methodBody:
                proxy.Interceptors.Add(new Interceptor(GenerateMethodDelegate<TResult>(methodBody), actual, false, false, true));
                break;
            case MemberExpression propertyExpression:
                proxy.Interceptors.Add(new Interceptor(GenerateGetPropertyDelegate(propertyExpression), actual, false, true, false));
                break;
        }

        return proxy;
    }
    
    public static Proxy<T> Setup<T, TResult>(this Proxy<T> proxy, Expression<Func<T, TResult>> original, Func<TResult>? actual) where T : class
    {
        switch (original.Body)
        {
            case MethodCallExpression methodBody:
                proxy.Interceptors.Add(new Interceptor(GenerateMethodDelegate<TResult>(methodBody), actual, false, false, false));
                break;
            case MemberExpression propertyExpression:
                proxy.Interceptors.Add(new Interceptor(GenerateGetPropertyDelegate(propertyExpression), actual, false, true, false));
                break;
        }

        return proxy;
    }

    private static Delegate GenerateMethodDelegate<TResult>(MethodCallExpression methodBody)
    {
        var ArgTypes = methodBody.Arguments.Select(x => x.Type).ToList();
        ArgTypes.Add(typeof(TResult));
        var delegateType = Expression.GetDelegateType(ArgTypes.ToArray());
        return Delegate.CreateDelegate(delegateType, null, methodBody.Method);
    }

    private static Delegate GenerateGetPropertyDelegate(MemberExpression propertyExpression)
    {
        var property = propertyExpression.Member as PropertyInfo;
        var delegateType = Expression.GetDelegateType(property.PropertyType);
        return Delegate.CreateDelegate(delegateType, null, property.GetMethod);
    }


    /// <summary>
    /// For setting up void methods. Returns the proxy to allow chaining.
    /// Allows access to the invocation parameters.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="proxy"></param>
    /// <param name="original"></param>
    /// <param name="actual"></param>
    public static Proxy<T> SetupVoid<T>(this Proxy<T> proxy, Expression<Action<T>> original, Action<IInvocation>? actual = null) where T : class
    {
        switch (original.Body)
        {
            case MethodCallExpression methodBody:
                proxy.Interceptors.Add(new Interceptor(GenerateVoidMethodDelegate(methodBody), actual, false, false, true));
                break;
            case MemberExpression:
                throw new InvalidOperationException("To setup properties please use the SetupWithInvocation extension method");
        }

        return proxy;
    }

    private static Delegate GenerateVoidMethodDelegate(MethodCallExpression methodBody)
    {
        var ArgTypes = methodBody.Arguments.Select(x => x.Type).ToList();
        ArgTypes.Add(typeof(void));
        var delegateType = Expression.GetDelegateType(ArgTypes.ToArray());
        return Delegate.CreateDelegate(delegateType, null, methodBody.Method);
    }
}