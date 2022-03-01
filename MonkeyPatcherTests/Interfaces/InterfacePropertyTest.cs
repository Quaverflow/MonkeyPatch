using System;
using System.Collections.Generic;
using MonkeyPatcher.MonkeyPatch.Interfaces;
using MonkeyPatcherTests.TestObjects;
using Xunit;

namespace MonkeyPatcherTests.Interfaces;

public class InterfacePropertyTest
{
    [Fact]
    public void TestProperty()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.SomeProperty, () => 3);

        var obj = proxy.Object;
        Assert.Equal(3, obj.SomeProperty);
        obj.SomeProperty = 5;
        Assert.Equal(5, obj.SomeProperty);     
        obj.SomeProperty ++;
        Assert.Equal(6, obj.SomeProperty);
    }

    [Fact]
    public void TestPropertyCallback()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        var db = new List<string>();
        proxy.Setup(x => x.SomeProperty, () =>
        {
            db.Add("hello");
            return 3;
        });

        var obj = proxy.Object;
        Assert.Equal(3, obj.SomeProperty);
        Assert.Single(db);
        Assert.Equal("hello", db[0]);
    }

    [Fact]
    public void TestPropertyThrows()
    {
        var proxy = new Proxy<IAnsweringEngine>();
        proxy.Setup(x => x.SomeProperty, () => throw new InvalidOperationException("oh no!"));

        var ex = Assert.Throws<InvalidOperationException>(()=> proxy.Object.SomeProperty);
        Assert.Equal("oh no!", ex.Message);
    }
}