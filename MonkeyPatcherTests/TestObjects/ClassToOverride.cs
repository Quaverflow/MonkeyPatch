using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public class ClassToOverride : IClassToOverride
{
    public int DamnMethod(int a) => a * 2;
    public int DamnMethodOverload(int a) => a * 2;
    public string DamnMethodOverload(int a, int b) => (a * b).ToString();
    public int DamnMethod2(string a) => 2;
    public static bool DamnMethod3(bool b) => b;

    public void DamnMethod4(bool b)
    {
        var x = b;
    }

    public virtual string DamnVirtualMethod() => "I'm virtual";

    public async Task<int> DamnMethodAsync(int a) => await Task.FromResult(DamnMethod(a));
    public async Task DamnMethodAsync2(int a) => await Task.FromResult(DamnMethod2(a.ToString()));
}