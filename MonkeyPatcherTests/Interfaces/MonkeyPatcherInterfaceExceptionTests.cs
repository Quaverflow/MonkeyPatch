using System;
using System.Threading.Tasks;
using MonkeyPatcher.MonkeyPatch.Interfaces;
using MonkeyPatcher.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using Xunit;

namespace MonkeyPatcherTests.Interfaces;

public class MonkeyPatcherInterfaceExceptionTes
{
    [Fact]
    public void Test_MockThrows()
    {
        var proxy = new Proxy<IClassToOverride>();
        proxy.Setup(x => x.DamnMethod(Any<int>.Value), () => throw new InvalidOperationException("Oh No!"));
        var sut = new TestClass(proxy.Instance);
        var result = Assert.Throws<InvalidOperationException>(() => sut.TestMethod(3));
        Assert.Equal("Oh No!", result.Message);
    }

    [Fact]
    public void Test_MockThrows2()
    {
        var proxy = new Proxy<IClassToOverride>();
        proxy.Setup(x => x.DamnMethod2(Any<string>.Value), () => throw new InvalidOperationException("Oh No!"));
        var sut = new TestClass(proxy.Instance);
        var result = Assert.Throws<InvalidOperationException>(() => sut.TestMethod(3));

        Assert.Equal("Oh No!", result.Message);
    }

    [Fact]
    public async Task Test_MockThrowsAsync()
    {

        var proxy = new Proxy<IClassToOverride>();
        proxy.Setup(x => x.DamnMethodAsync2(Any<int>.Value), ()=> throw new Exception("Oh No!"));

        var sut = new TestClass(proxy.Instance);
        var result = await Assert.ThrowsAsync<Exception>(() => sut.TestDamnMethodAsyncTaskOfT(3));

        Assert.Equal("Oh No!", result.Message);
    }
}

