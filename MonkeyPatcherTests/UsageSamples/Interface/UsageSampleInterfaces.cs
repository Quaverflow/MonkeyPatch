using MonkeyPatcher.MonkeyPatch.Concrete;
using System;
using System.Runtime.InteropServices.ComTypes;
using MonkeyPatcher.MonkeyPatch.Interfaces;
using MonkeyPatcher.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using Utilities;
using Xunit;

namespace MonkeyPatcherTests.UsageSamples.Interface;

public class UsageSampleConcreteTypes
{
    [Fact]
    public void Private()
    {
        var proxy = new Proxy<ISomeInterface>();


        proxy.Setup(x => x.HelloPublic(Any<string>.Value, Any<bool>.Value),
            invocation =>
            {
                Assert.Equal("Philip takes a bath", invocation.Arguments[0] as string);
                Assert.False((bool)invocation.Arguments[1]);
                return "poultry";
            });
        
        var sut = new ConsumerClass(proxy.Instance);
        Assert.Equal("poultry", sut.SayHelloVoid("Philip takes a bath"));
    }
}

public interface ISomeInterface
{
    string HelloPublic(string s, bool b);

}

public class ConsumerClass
{
    private readonly ISomeInterface _someInterface;

    public ConsumerClass(ISomeInterface someInterface)
    {
        _someInterface = someInterface;
    }

    public string SayHelloVoid(string s) => _someInterface.HelloPublic(s, false);
}








