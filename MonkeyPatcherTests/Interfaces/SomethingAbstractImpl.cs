namespace MonkeyPatcherTests.Interfaces;

public class SomethingAbstractImpl : SomethingAbstract
{
    public override int SomeAbstractReturns(string s)
    {
        throw new System.NotImplementedException();
    }
}