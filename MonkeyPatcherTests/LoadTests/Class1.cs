using FluentAssertions;
using MonkeyPatcher.MonkeyPatch.Concrete;
using MonkeyPatcher.MonkeyPatch.Concrete.Dto;
using MonkeyPatcher.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using Utilities;
using Xunit;

namespace MonkeyPatcherTests.LoadTests;

public class Class1
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class12
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class13
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class14
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class15
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class16
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class17
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class18
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class11
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class121
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class132
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class134
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class145
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class156
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class167
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Class178
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Claass1
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clfass12
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clsass13
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clfass14
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Cldass15
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Cdlass16
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Cflass17
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Cdlass18
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clssass11
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clafss121
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Claass132
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Classs134
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clabss145
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clascs156
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clasxs167
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}
public class Clascs178
{
    [Fact]
    public void Test_Public_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VoidMethod());

        sut.Invoking(x => x.VoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => PublicClassToOverride.StaticVoidMethod());

        sut.Invoking(x => x.StaticVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Public_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.MethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.MethodWithReturn(), () => 3);

        sut.Invoking(x => x.MethodWithReturn()).Should().NotThrow();
        sut.MethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.StaticMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => PublicClassToOverride.StaticMethodWithReturn(), () => 3);

        sut.Invoking(x => x.StaticMethodWithReturn()).Should().NotThrow();
        sut.StaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_VirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.VirtualVoidMethod());

        sut.Invoking(x => x.VirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_VirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.VirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.VirtualMethodWithReturn(), () => 3);

        sut.Invoking(x => x.VirtualMethodWithReturn()).Should().NotThrow();
        sut.VirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Public_ProtectedVirtualVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualVoidMethod);
        mp.OverrideVoid<PublicClassToOverride>(x => x.ProtectedVirtualVoidMethod(Any<int>.Value));

        sut.Invoking(x => x.ProtectedVirtualVoidMethod()).Should().NotThrow();
    }


    [Fact]
    public void Test_Public_ProtectedVirtualReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.ProtectedVirtualMethodWithReturn);
        mp.Override<PublicClassToOverride, int>(x => x.ProtectedVirtualMethodWithReturn(Any<int>.Value), () => 3);

        sut.Invoking(x => x.ProtectedVirtualMethodWithReturn()).Should().NotThrow();
        sut.ProtectedVirtualMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Return()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateMethodWithReturn", AccessType.Private, () => 3));

        sut.Invoking(x => x.PrivateMethodWithReturn()).Should().NotThrow();
        sut.PrivateMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_Void()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateVoidMethod", AccessType.Private));

        sut.Invoking(x => x.PrivateVoidMethod()).Should().NotThrow();
    }

    [Fact]
    public void Test_Private_StaticReturn()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticMethodWithReturn);
        mp.OverrideNonPublicMethod<PublicClassToOverride, int>(new NonPublicMethodInfo<int>("PrivateStaticMethodWithReturn", AccessType.PrivateStatic, () => 3));

        sut.Invoking(x => x.PrivateStaticMethodWithReturn()).Should().NotThrow();
        sut.PrivateStaticMethodWithReturn().Should().Be(3);
    }

    [Fact]
    public void Test_Private_StaticVoid()
    {
        var sut = new CallingPublic();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.PrivateStaticVoidMethod);
        mp.OverrideNonPublicVoidMethod<PublicClassToOverride>(new NonPublicVoidMethodInfo("PrivateStaticVoidMethod", AccessType.PrivateStatic));

        sut.Invoking(x => x.PrivateStaticVoidMethod()).Should().NotThrow();
    }
}