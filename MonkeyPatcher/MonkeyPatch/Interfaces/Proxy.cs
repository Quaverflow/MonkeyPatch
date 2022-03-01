using Castle.DynamicProxy;

namespace MonkeyPatcher.MonkeyPatch.Interfaces;

public class Proxy<T> where T : class
{
    public T Object => GenerateProxy();
    internal readonly InterfaceSet<Interceptor> Interceptors = new();

    private static readonly ProxyGenerator Generator = new();
    private static readonly ProxyGenerationOptions Options = new() { Selector = new MethodSelector() };
    private T GenerateProxy() => (T)Generator.CreateInterfaceProxyWithoutTarget(typeof(T), Type.EmptyTypes, Options, Interceptors.ToArray());
}


