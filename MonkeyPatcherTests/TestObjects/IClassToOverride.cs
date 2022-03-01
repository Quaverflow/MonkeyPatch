using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public interface IClassToOverride
{
    public int DamnMethod(int a);
    public int DamnMethod2(string a);
    public void DamnMethod4(bool a);

    public Task<int> DamnMethodAsync(int a);
    public async Task DamnMethodAsync2(int a) => await Task.FromResult(DamnMethod2(a.ToString()));
    public int DamnMethodOverload(int a);
    public string DamnMethodOverload(int a, int b);
}