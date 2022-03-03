using System.Threading.Tasks;
using MonkeyPatcher.MonkeyPatch.Interfaces;
using MonkeyPatcher.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using Xunit;

namespace MonkeyPatcherTests.Interfaces;

public class MonkeyPatcherInterfaceAsyncTests
{

    [Fact]
    public async Task Test_MockAsync_ReturnTaskOfT()
    {
        var proxy = new Proxy<IClassToOverride>();
        proxy.Setup(x => x.DamnMethodAsync(Any<int>.Value), () => Task.FromResult(13));
        proxy.Setup(x => x.DamnMethod2(Any<string>.Value), () => 13);

        var sut = new TestClass(proxy.Instance);
        var result = await sut.TestDamnMethodAsyncTaskOfT(3);

        Assert.Equal("26", result);
    }

    [Fact]
    public async Task Test_MockAsync_ReturnTask()
    {

        var proxy = new Proxy<IClassToOverride>();
        proxy.Setup(x => x.DamnMethod(Any<int>.Value), () => 13);
        proxy.Setup(x => x.DamnMethodAsync2(Any<int>.Value), () => Task.CompletedTask);

        var sut = new TestClass(proxy.Instance);
        var result = await sut.TestMethodAsyncTask(3);

        Assert.Equal("13", result);
    }
}