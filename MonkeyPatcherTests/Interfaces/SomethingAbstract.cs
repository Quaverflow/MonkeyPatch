using System;

namespace MonkeyPatcherTests.Interfaces;

public abstract class SomethingAbstract
{
    public abstract int SomeAbstractReturns(string s);

    public virtual int SomeVirtualReturns(string s)
    {
        throw new NotImplementedException();
    }

    public int SomeReturns(string s)
    {
        throw new NotImplementedException();
    }
}