using MonkeyPatcher.MonkeyPatch.Concrete;
using System;
using Utilities;
using Xunit;

namespace MonkeyPatcherTests.UsageSamples.Interface;

public class UsageSampleConcreteTypes
{
    [Fact]
    public void Private()
    {
        var sut = new ConsumerClass();
        using var monkeyPatch = MonkeyPatcherFactory.GetMonkeyPatch(sut.SayHelloVoid);

        monkeyPatch.OverrideNonPublicMethod<ClassToOverride, string>("HelloPrivate", AccessType.PrivateStatic, ()=> "hello", typeof(string));

        
        Assert.Equal("hello", sut.SayHelloVoid(string.Empty));

    }
}

public class ClassToOverride
{
    public static string HelloPublic(string s) => HelloPrivate(s);
    private static string HelloPrivate(string s) => throw new NotImplementedException("method not overwritten!");
    
}

public class ConsumerClass
{
    public string SayHelloVoid(string s) => ClassToOverride.HelloPublic(s);
}








