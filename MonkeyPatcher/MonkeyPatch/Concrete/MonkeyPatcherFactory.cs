namespace MonkeyPatcher.MonkeyPatch.Concrete;

public static class MonkeyPatcherFactory
{
    private static bool _available = true;
    private static object _lock = new ();
    /// <summary>
    /// Generates an instance of the monkey patcher.
    /// maxScanningDepth allows you to specify how deep the analyzer should scan for methods to override.
    /// A shallow scan will execute very fast but
    /// you must make sure that your method to override is not called in a deeper layer of your method, or the mapping will be faulty
    /// </summary>
    /// <param name="sut"></param>
    /// <param name="maxScanningDepth"></param>
    /// <returns></returns>
    public static MonkeyPatch GetMonkeyPatch(Delegate sut, int maxScanningDepth = 5)
    {
            
        var methodInfo = sut.Method;
        while (!_available)
        {
            //todo figure out a better way to do this
            //this is fundamental in preventing the concurrency issue do not remove!
            Thread.Sleep(1);
        }
        _available = false;

        return new MonkeyPatch(Disposed, methodInfo, maxScanningDepth);
    }

    public static void Disposed(ref bool disposed)
    {
        _available = disposed;
    }
}