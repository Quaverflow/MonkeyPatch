using FluentAssertions;
using MonkeyPatcher.MonkeyPatch.Concrete;
using MonkeyPatcher.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MonkeyPatcherTests;

public class PreliminaryTests

{
    [Fact]
    public void Test_SyncRet()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.Sync);
        mp.Override<TestDependency, int>(x => TestDependency.ToOverride(Any<int>.Value), () => 3);

        var res = sut.Sync();
        res.Should().Be(3);
    }

    [Fact]
    public void Test_SyncVoid()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.SyncVoid);
        mp.OverrideVoid<TestDependency>(x => TestDependency.ToOverrideVoid(Any<int>.Value));

        sut.Invoking(x => x.SyncVoid()).Should().NotThrow();
    }

    [Fact]
    public async Task Test_Multiple()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MultipleCalls);
        mp.Override<TestDependency, Task>(x => TestDependency.ToOverrideAsyncRet(Any<int>.Value), () => Task.FromResult(3));
        mp.OverrideVoid<TestDependency>(x => TestDependency.ToOverrideVoid(Any<int>.Value));
        mp.Override<TestDependency, int>(x => TestDependency.ToOverride(Any<int>.Value), () => 3);

        await sut.Invoking(x => x.MultipleCalls()).Should().NotThrowAsync();
        var res = await sut.MultipleCalls();
        res.Should().Be(6);
    }
    [Fact]
    public async Task Test_Deep()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MultipleCalls);
        mp.Override<TestDependency, Task>(x => TestDependency.ToOverrideAsyncRet(Any<int>.Value), () => Task.FromResult(3));
        mp.OverrideVoid<TestDependency>(x => TestDependency.ToOverrideVoid(Any<int>.Value));
        mp.Override<TestDependency, int>(x => TestDependency.ToOverride(Any<int>.Value), () => 3);

        await sut.Invoking(x => x.Deep()).Should().NotThrowAsync();
        var res = await sut.Deep();
        res.Should().Be(6);
    }

    [Fact]
    public void Test_ChangeReturnAfterCallingMethod()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.Sync);
        mp.Override<TestDependency, int>(x => TestDependency.ToOverride(Any<int>.Value), () => 3);

        var res = sut.Sync();
        res.Should().Be(3);


        mp.Override<TestDependency, int>(x => TestDependency.ToOverride(Any<int>.Value), () => 10);
        var res2 = sut.Sync();
        res2.Should().Be(10);

    }

    [Fact]
    public void Test_Throw()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.Sync);
        mp.Override<TestDependency, int>(x => TestDependency.ToOverride(Any<int>.Value), () => throw new Exception("hello"));

        var res = Assert.Throws<Exception>(() => sut.Sync());
        res.Message.Should().Be("hello");
    }

    [Fact]
    public async Task Test_AsyncRet()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.AsyncRet);
        mp.Override<TestDependency, Task>(x => TestDependency.ToOverrideAsyncRet(Any<int>.Value), () => Task.FromResult(3));

        var res = await sut.AsyncRet();
        res.Should().Be(3);

    }

    [Fact]
    public async Task Test_AsyncTask()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.AsyncTask);
        mp.Override<TestDependency, Task>(x => TestDependency.ToOverrideAsyncTask(Any<int>.Value), () => Task.CompletedTask);
        await sut.Invoking(x => x.AsyncTask()).Should().NotThrowAsync();
    }

    [Fact]
    public void Test_ReturnStruct()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.SyncReturnsStruct);

        var datetime = DateTime.UtcNow;
        mp.Override<TestDependency, DateTime>(x => TestDependency.ToOverrideReturnsStruct(), () => datetime);
        sut.Invoking(x => x.SyncReturnsStruct(Any<DateTime>.Value)).Should().NotThrow();
        sut.SyncReturnsStruct(Any<DateTime>.Value).Should().Be(datetime);

    }

    [Fact]
    public void Test_ReturnClass()
    {
        var sut = new TestCaller();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.SyncReturnClass);

        var poco = new TestPoco()
        {
            Age = 3,
            DateOfBirth = DateTime.UtcNow,
            Name = "Hello"
        };

        mp.Override<TestDependency, TestPoco>(x => TestDependency.ToOverrideReturnClass(), () => poco);
        sut.Invoking(x => x.SyncReturnClass(Any<TestPoco>.Value)).Should().NotThrow();

        var res = sut.SyncReturnClass(Any<TestPoco>.Value);
        res.Age.Should().Be(poco.Age);
        res.Name.Should().Be(poco.Name);
        res.DateOfBirth.Should().Be(poco.DateOfBirth);

    }

}


