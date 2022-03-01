using System;
using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public class TestDependency
{
    public static int ToOverride(int a) => throw new NotImplementedException("ToOverrideVoid");
    public static void ToOverrideVoid(int a) => throw new NotImplementedException("ToOverrideVoid");
    public static int ToOverrideDeep(int a) => ToOverrideDeepLayer2(a);
    private static int ToOverrideDeepLayer2(int i) => ToOverride(i);
    public static Task ToOverrideAsyncTask(int a) => throw new NotImplementedException("ToOverrideAsyncTask");
    public static Task<int> ToOverrideAsyncRet(int a) => throw new NotImplementedException("ToOverrideAsyncRet");
    public static DateTime ToOverrideReturnsStruct() => throw new NotImplementedException("ToOverrideReturnsStruct");
    public static TestPoco ToOverrideReturnClass() => throw new NotImplementedException("ToOverrideReturnClass");
}