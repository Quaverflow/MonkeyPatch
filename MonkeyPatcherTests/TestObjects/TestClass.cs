using System;
using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public class TestClass
{
    private readonly IClassToOverride ToOverride;

    public TestClass(IClassToOverride toOverride)
    {
        ToOverride = toOverride;
    }

    public TestClass()
    {
        ToOverride = new ClassToOverride();
    }

    public string SomeString { get; set; }
    public DateTime SomeDateTime { get; set; }

    public string TestMethod(int a)
    {
        var first = ToOverride.DamnMethod(a);
        var second = ToOverride.DamnMethod2("a");
        var result = first + second;
        return result.ToString();
    }
    public bool TestMethodWithStatic() => ClassToOverride.DamnMethod3(true);
    public string TestMethodWithInterface(int a)
    {
        var first = ToOverride.DamnMethod(a);
        var second = ToOverride.DamnMethod2("a");
        var result = first + second;
        return result.ToString();
    }
    public string TestMethodWithVoidReturn()
    {
        ToOverride.DamnMethod4(true);
        return "ok";
    }
    public string TestVirtualMethod()
    {
        var classToOverride = new ClassToOverride();
        return classToOverride.DamnVirtualMethod();
    }
    public async Task<string> TestDamnMethodAsyncTaskOfT(int a)
    {
        var first = await ToOverride.DamnMethodAsync(a);
        var second = ToOverride.DamnMethod2("a");
        var result = first + second;
        return result.ToString();
    }
    public async Task<string> TestMethodAsyncTask(int a)
    {
        var first = ToOverride.DamnMethod(a);
        await ToOverride.DamnMethodAsync2(a);
        return first.ToString();
    }
    public int TestOverload1()
    {
        return ToOverride.DamnMethodOverload(1);
    }
    public string TestOverload2()
    {
        return ToOverride.DamnMethodOverload(1, 1);
    }

}