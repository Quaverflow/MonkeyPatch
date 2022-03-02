namespace MonkeyPatcher.MonkeyPatch.Concrete;

public static class MonkeyPatcherFactory
{
    private static bool _available = true;
    private static readonly object Lock = new();

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
        //Double check to make sure the thread is aware of the state of the object upon entering the lock.
        WaitForAccess();
        lock (Lock)
        {
            WaitForAccess();
            _available = false;
            return new MonkeyPatch(Disposed, sut.Method, maxScanningDepth);
        }
    }

    private static void WaitForAccess()
    {

        while (!_available) { /* Wait for the previous test to complete */ }
    }

    private static void Disposed(ref bool disposed)
    {
        _available = disposed;
    }
}