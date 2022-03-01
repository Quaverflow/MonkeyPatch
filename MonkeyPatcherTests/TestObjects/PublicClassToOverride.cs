using System;
using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public class PublicClassToOverride
{
    public void VoidMethod() => throw new NotImplementedException("VoidMethod was not overwritten");
    public static void StaticVoidMethod() => throw new NotImplementedException("StaticVoidMethod was not overwritten");
    public virtual void VirtualVoidMethod() => throw new NotImplementedException("VirtualVoidMethod was not overwritten");
    public int MethodWithReturn() => throw new NotImplementedException("MethodWithReturn was not overwritten");
    public static int StaticMethodWithReturn() => throw new NotImplementedException("StaticMethodWithReturn was not overwritten");
    public virtual int VirtualMethodWithReturn() => throw new NotImplementedException("VirtualMethodWithReturn was not overwritten");

    public void ProtectedVirtualVoidMethod(int a) => ProtectedVirtualVoidMethod();
    protected virtual void ProtectedVirtualVoidMethod() => throw new NotImplementedException("ProtectedVirtualVoidMethod was not overwritten");
    public int ProtectedVirtualMethodWithReturn(int a) => ProtectedVirtualMethodWithReturn();
    protected virtual int ProtectedVirtualMethodWithReturn() => throw new NotImplementedException("VirtualMethodWithReturn was not overwritten");
    public void PrivateVoidMethod(int a) => PrivateVoidMethod();
    private void PrivateVoidMethod() => throw new NotImplementedException("VoidMethod was not overwritten");
    public static void PrivateStaticVoidMethod(int a) => PrivateStaticVoidMethod();
    private static void PrivateStaticVoidMethod() => throw new NotImplementedException("StaticVoidMethod was not overwritten");
    public int PrivateMethodWithReturn(int a) => PrivateMethodWithReturn();
    private int PrivateMethodWithReturn() => throw new NotImplementedException("MethodWithReturn was not overwritten");
    public static int PrivateStaticMethodWithReturn(int a) => PrivateStaticMethodWithReturn();
    private static int PrivateStaticMethodWithReturn() => throw new NotImplementedException("StaticMethodWithReturn was not overwritten");    
    
    public async Task VoidMethodAsync() => await Task.Run(()=>throw new NotImplementedException("Async VoidMethod was not overwritten"));
    public static async Task StaticVoidMethodAsync() => await Task.Run(() => throw new NotImplementedException("Async StaticVoidMethod was not overwritten"));
    public virtual async Task VirtualVoidMethodAsync() => await Task.Run(() => throw new NotImplementedException("Async VirtualVoidMethod was not overwritten"));
    public async Task<int> MethodWithReturnAsync() => await Task.Run(() =>
    {
        throw new NotImplementedException("Async MethodWithReturn was not overwritten");
        return 0;
    });
    public static async Task<int> StaticMethodWithReturnAsync() => await Task.Run(() =>
    {
        throw new NotImplementedException("Async StaticMethodWithReturn was not overwritten");
        return 0;
    });
    public virtual async Task<int> VirtualMethodWithReturnAsync() => await Task.Run<int>(() =>
    {
        throw new NotImplementedException("Async VirtualMethodWithReturn was not overwritten");
        return 0;
    });

    public async Task ProtectedVirtualVoidMethodAsync(int a) => await Task.Run(ProtectedVirtualVoidMethodAsync);
    protected virtual async Task ProtectedVirtualVoidMethodAsync() => await Task.Run(() => throw new NotImplementedException("Async ProtectedVirtualVoidMethod was not overwritten"));
    public async Task<int> ProtectedVirtualMethodWithReturnAsync(int a) => await Task.Run(ProtectedVirtualMethodWithReturnAsync);
    protected virtual async Task<int> ProtectedVirtualMethodWithReturnAsync() => await Task.Run(() =>
    {
        throw new NotImplementedException("Async VirtualMethodWithReturn was not overwritten");
        return 0;
    });
    public async Task PrivateVoidMethodAsync(int a) => await Task.Run(PrivateVoidMethodAsync);
    private async Task PrivateVoidMethodAsync() => await Task.Run(() => throw new NotImplementedException("Async VoidMethod was not overwritten"));
    public static async Task PrivateStaticVoidMethodAsync(int a) => await Task.Run(PrivateStaticVoidMethodAsync);
    private static async Task PrivateStaticVoidMethodAsync() => await Task.Run(() => throw new NotImplementedException("Async StaticVoidMethod was not overwritten"));
    public async Task<int> PrivateMethodWithReturnAsync(int a) => await PrivateMethodWithReturnAsync();
    private async Task<int> PrivateMethodWithReturnAsync() => await Task.Run(() =>
    {
        throw new NotImplementedException("Async MethodWithReturn was not overwritten");
        return 0;
    });
    public static async Task<int> PrivateStaticMethodWithReturnAsync(int a) => await Task.Run(PrivateStaticMethodWithReturnAsync);
    private static async Task<int> PrivateStaticMethodWithReturnAsync() => await Task.Run(() =>
    {
        throw new NotImplementedException("Async StaticMethodWithReturn was not overwritten");
        return 0;
    });
}