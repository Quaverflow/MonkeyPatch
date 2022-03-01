using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public class CallingPublic
{
    private readonly PublicClassToOverride _classToOverride;

    public CallingPublic()
    {
        _classToOverride = new PublicClassToOverride();
    }

    public void VoidMethod() => _classToOverride.VoidMethod();
    public void StaticVoidMethod() => PublicClassToOverride.StaticVoidMethod();
    public void VirtualVoidMethod() => _classToOverride.VirtualVoidMethod();
    public void ProtectedVirtualVoidMethod() => _classToOverride.ProtectedVirtualVoidMethod(0);
    public int MethodWithReturn() => _classToOverride.MethodWithReturn();
    public int StaticMethodWithReturn() => PublicClassToOverride.StaticMethodWithReturn();
    public int VirtualMethodWithReturn() => _classToOverride.VirtualMethodWithReturn();
    public int ProtectedVirtualMethodWithReturn() => _classToOverride.ProtectedVirtualMethodWithReturn(0);
    public void PrivateVoidMethod() => _classToOverride.PrivateVoidMethod(0);
    public void PrivateStaticVoidMethod() => PublicClassToOverride.PrivateStaticVoidMethod(0);
    public int PrivateMethodWithReturn() => _classToOverride.PrivateMethodWithReturn(0);
    public int PrivateStaticMethodWithReturn() => PublicClassToOverride.PrivateStaticMethodWithReturn(0);
    public async Task VoidMethodAsync(int a) => await _classToOverride.VoidMethodAsync();
    public async Task StaticVoidMethodAsync(int a) => await PublicClassToOverride.StaticVoidMethodAsync();
    public async Task VirtualVoidMethodAsync(int a) => await  _classToOverride.VirtualVoidMethodAsync();
    public async Task ProtectedVirtualVoidMethodAsync(int a) => await  _classToOverride.ProtectedVirtualVoidMethodAsync(0);
    public async Task<int> MethodWithReturnAsync(int a) => await  _classToOverride.MethodWithReturnAsync();
    public async Task<int> StaticMethodWithReturnAsync(int a) => await  PublicClassToOverride.StaticMethodWithReturnAsync();
    public async Task<int> VirtualMethodWithReturnAsync(int a) => await  _classToOverride.VirtualMethodWithReturnAsync();
    public async Task<int> ProtectedVirtualMethodWithReturnAsync(int a) => await  _classToOverride.ProtectedVirtualMethodWithReturnAsync(0);
    public async Task PrivateVoidMethodAsync(int a) =>  await _classToOverride.PrivateVoidMethodAsync(0);
    public async Task PrivateStaticVoidMethodAsync(int a) => await  PublicClassToOverride.PrivateStaticVoidMethodAsync(0);
    public async Task<int> PrivateMethodWithReturnAsync(int a) => await  _classToOverride.PrivateMethodWithReturnAsync(0);
    public async Task<int> PrivateStaticMethodWithReturnAsync(int a) => await  PublicClassToOverride.PrivateStaticMethodWithReturnAsync(0);
}
