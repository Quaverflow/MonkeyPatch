using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonkeyPatch.MonkeyPatch.Interfaces;
using MonkeyPatch.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using Xunit;

namespace MonkeyPatcherTests.Interfaces;

public class InterfacesTests
{
    [Fact]
    public void Test_FirstAttempt()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<string>.Value), () => 3);
        proxy.Setup(x => x.GetAnswer(Any<bool>.Value), () => "3");
        proxy.Setup(x => x.GetAnswer(Any<int>.Value), () => false);
        var res1 = proxy.Instance.GetAnswer("asdf");
        Assert.Equal(3, res1);
        var res2 = proxy.Instance.GetAnswer(true);
        Assert.Equal("3", res2);
        var res3 = proxy.Instance.GetAnswer(12);
        Assert.False(res3);

        proxy.Setup(x => x.GetAnswer(Any<bool>.Value, Any<bool>.Value), () => "abc");
        var res4 = proxy.Instance.GetAnswer(false, true);
        Assert.Equal("abc", res4);
    }

    [Fact]
    public async Task Test_Async()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<int>.Value, Any<string>.Value), () =>Task.FromResult(12));

        var res1 = await proxy.Instance.GetAnswer(3, "asdf");
        Assert.Equal(12, res1);
    }

    [Fact]
    public void Test_Throws()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<string>.Value), () => throw new InvalidOperationException("3432"));

        var res1 = Assert.Throws<InvalidOperationException>(() => proxy.Instance.GetAnswer("asdf"));
        Assert.Equal("3432", res1.Message);
    }

    [Fact]
    public void Test_DoubleSetupShouldOverride()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<string>.Value), () => throw new InvalidOperationException("3432"));
        proxy.Setup(x => x.GetAnswer(Any<string>.Value), () => 3);

        var res1 = proxy.Instance.GetAnswer("asdf");
        Assert.Equal(3, res1);
    }

    [Fact]
    public void Test_Callback()
    {
        var db = new List<int>();
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<string>.Value),  () =>
        {
            db.Add(3);
            return 3;
        });

        var res1 = proxy.Instance.GetAnswer("asdf");
        Assert.Equal(3, res1);
        Assert.NotEmpty(db);
        Assert.Equal(3, db[0]);
    }


    [Fact]
    public void Test_Invokation()
    {
        var db = new List<string>();
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<string>.Value), x =>
        {
            db.Add((string)x.Arguments[0]);
            return 3;
        });

        var res1 = proxy.Instance.GetAnswer("asdf");
        Assert.Equal(3, res1);
        Assert.NotEmpty(db);
        Assert.Equal("asdf", db[0]);
    }


    [Fact]
    public void Test_Invokation2()
    {
        var db = new List<bool>();
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.GetAnswer(Any<bool>.Value, Any<bool>.Value), x =>
        {
            db.Add((bool) x.Arguments[0]);
            db.Add((bool) x.Arguments[1]);
            return "hi";
        });

        var res1 = proxy.Instance.GetAnswer(true, false);
        Assert.Equal("hi", res1);
        Assert.NotEmpty(db);
        Assert.True(db[0]);
        Assert.False(db[1]);
    }

    [Fact]
    public void Test_Abstract()
    {
        var proxy = new Proxy<SomethingAbstract>();
        proxy.Setup(x => x.SomeAbstractReturns(Any<string>.Value), () => 13);

        Assert.Equal(13, proxy.Instance.SomeAbstractReturns("hello"));
    }


    [Fact]
    public void Test_Virtual()
    {
        var proxy = new Proxy<SomethingAbstract>();
        proxy.Setup(x => x.SomeVirtualReturns(Any<string>.Value), () => 13);

        Assert.Equal(13, proxy.Instance.SomeVirtualReturns("hello"));
    } 
}