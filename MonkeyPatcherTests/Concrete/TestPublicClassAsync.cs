using FluentAssertions;
using MonkeyPatcherTests.TestObjects;
using System.Threading.Tasks;
using MonkeyPatch.MonkeyPatch.Concrete;
using MonkeyPatch.MonkeyPatch.Shared;
using Utilities;
using Xunit;

namespace MonkeyPatcherTests.Concrete;

public class TestPublicClassAsync
{
    [Fact]
    public async Task Test_Public_AsyncTask()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethodAsync);
        mp.Override<PublicClassToOverride, Task>(x => x.VoidMethodAsync(), () => Task.CompletedTask);

        await sut.Invoking(x => x.VoidMethodAsync(Any<int>.Value)).Should().NotThrowAsync();
    }

    [Fact]
    public async Task Test_Public_StaticAsyncTask()
    {
        var sut = new CallingPublic(); 
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethodAsync);
        mp.Override<PublicClassToOverride, Task>(x => PublicClassToOverride.StaticVoidMethodAsync(), () => Task.CompletedTask);

        await sut.Invoking(x => x.StaticVoidMethodAsync(Any<int>.Value)).Should().NotThrowAsync();
    }

    [Fact]
    public async Task Test_Public_AsyncReturn()
    {
        var sut = new CallingPublic(); 
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturnAsync);
        mp.Override<PublicClassToOverride, Task>(x => x.MethodWithReturnAsync(), () => Task.FromResult(3));

        await sut.Invoking(x => x.MethodWithReturnAsync(Any<int>.Value)).Should().NotThrowAsync();
        (await sut.MethodWithReturnAsync(Any<int>.Value)).Should().Be(3);
    }

    [Fact]
    public async Task Test_Public_StaticAsyncReturn()
    {
        var sut = new CallingPublic(); 
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturnAsync);
        mp.Override(()=> PublicClassToOverride.StaticMethodWithReturnAsync(), () => Task.FromResult(3));

        await sut.Invoking(x => x.StaticMethodWithReturnAsync(Any<int>.Value)).Should().NotThrowAsync();
        (await sut.StaticMethodWithReturnAsync(Any<int>.Value)).Should().Be(3);
    }

    [Fact]
    public async Task Test_Public_VirtualAsyncTask()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethodAsync);
        mp.Override<PublicClassToOverride, Task>(x => x.VirtualVoidMethodAsync(), () => Task.CompletedTask);

        await sut.Invoking(x => x.VirtualVoidMethodAsync(Any<int>.Value)).Should().NotThrowAsync();
    }


    [Fact]
    public async Task Test_Public_VirtualReturnAsync()
    {
        var sut = new CallingPublic(); 
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturnAsync);
        mp.Override<PublicClassToOverride, Task>(x => x.VirtualMethodWithReturnAsync(), () => Task.FromResult(3));

        await sut.Invoking(x => x.VirtualMethodWithReturnAsync(Any<int>.Value)).Should().NotThrowAsync();
        (await sut.VirtualMethodWithReturnAsync(Any<int>.Value)).Should().Be(3);
    }

    [Fact]
    public async Task Test_Public_ProtectedVirtualTaskAsync()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethodAsync);
        mp.Override<PublicClassToOverride, Task>(x => x.ProtectedVirtualVoidMethodAsync(Any<int>.Value), () => Task.CompletedTask);

        await sut.Invoking(x => x.ProtectedVirtualVoidMethodAsync(Any<int>.Value)).Should().NotThrowAsync();
    }


    [Fact]
    public async Task Test_Public_ProtectedVirtualReturnAsync()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturnAsync);
        mp.Override<PublicClassToOverride, Task>(x => x.ProtectedVirtualMethodWithReturnAsync(Any<int>.Value), () => Task.FromResult(3));

        await sut.Invoking(x => x.ProtectedVirtualMethodWithReturnAsync(Any<int>.Value)).Should().NotThrowAsync();
        (await sut.ProtectedVirtualMethodWithReturnAsync(Any<int>.Value)).Should().Be(3);
    }

    [Fact]
    public async Task Test_Private_ReturnAsync()
    {
        var sut = new CallingPublic(); 
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturnAsync);
        mp.OverrideNonPublicMethod<PublicClassToOverride, Task>("PrivateMethodWithReturnAsync", AccessType.Private, () => Task.FromResult(3));

        await sut.Invoking(x => x.PrivateMethodWithReturnAsync(Any<int>.Value)).Should().NotThrowAsync();
        (await sut.PrivateMethodWithReturnAsync(Any<int>.Value)).Should().Be(3);
    }

    [Fact]
    public async Task Test_Private_AsyncTask()
    {
        var sut = new CallingPublic(); 
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethodAsync);
        mp.OverrideNonPublicMethod<PublicClassToOverride, Task>("PrivateVoidMethodAsync", AccessType.Private, () => Task.CompletedTask);

        await sut.Invoking(x => x.PrivateVoidMethodAsync(Any<int>.Value)).Should().NotThrowAsync();
    }

    [Fact]
    public async Task Test_Private_StaticReturnAsync()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturnAsync);
        mp.OverrideNonPublicMethod<PublicClassToOverride, Task>("PrivateStaticMethodWithReturnAsync", AccessType.PrivateStatic, () => Task.FromResult(3));

        await sut.Invoking(x => x.PrivateStaticMethodWithReturnAsync(Any<int>.Value)).Should().NotThrowAsync();
        (await sut.PrivateStaticMethodWithReturnAsync(Any<int>.Value)).Should().Be(3);
    }

    [Fact]
    public async Task Test_Private_StaticAsyncTask()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethodAsync);
        mp.OverrideNonPublicMethod<PublicClassToOverride, Task>("PrivateStaticVoidMethodAsync", AccessType.PrivateStatic, () => Task.CompletedTask);

        await sut.Invoking(x => x.PrivateStaticVoidMethodAsync(Any<int>.Value)).Should().NotThrowAsync();
    }
}