using System.Threading.Tasks;

namespace MonkeyPatcherTests.TestObjects;

public class  AnsweringEngine : IAnsweringEngine
{
    public int SomeProperty { get; set; }
    public int SomeGetProperty { get; }
    public int GetAnswer(string s) => throw new System.NotImplementedException();
    public Task<int> GetAnswer(int p, string s) => throw new System.NotImplementedException();
    public bool GetAnswer(int s) => throw new System.NotImplementedException();
    public string GetAnswer(bool s) => throw new System.NotImplementedException();
    public string GetAnswer(bool s, bool d) => throw new System.NotImplementedException();
}

public interface IAnsweringEngine
{
    int SomeProperty { get; set; }
    int SomeGetProperty { get; }
    int GetAnswer(string s);
    Task<int> GetAnswer(int p, string s);
    bool GetAnswer(int s);
    string GetAnswer(bool s);
    string GetAnswer(bool s,bool d);
}