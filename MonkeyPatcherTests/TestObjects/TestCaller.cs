using System;
using System.Threading.Tasks;
using static MonkeyPatcherTests.TestObjects.TestDependency;

namespace MonkeyPatcherTests.TestObjects;

public class TestCaller
{
    public int Sync() => ToOverride(2);
    public void SyncVoid() => ToOverrideVoid(2);
    public async Task<int> AsyncRet()
    {
        return await ToOverrideAsyncRet(2);
    }

    public async Task AsyncTask() => await ToOverrideAsyncTask(2);
    public async Task<int> MultipleCalls()
    {
        var x = await ToOverrideAsyncRet(2);
        x += ToOverride(x);
        ToOverrideVoid(x);

        return x;
    }
    public async Task<int> Deep()
    {
        var x = await ToOverrideAsyncRet(2);
        x += ToOverride(x);
        x+= ToOverrideDeep(x);

        return x;
    }

    public DateTime SyncReturnsStruct(DateTime x)
    {
        var res = ToOverrideReturnsStruct();
        return res;
    }

    public TestPoco SyncReturnClass(TestPoco x) => ToOverrideReturnClass();

}

public class TestPoco
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfBirth { get; set; }
}