using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonkeyPatcherTests.TestObjects;

public class ComplexClass
{
    public async Task<ComplexClassReturnClass> GetTestClass(TestCaller caller)
    {
        var client = new HttpClient() { BaseAddress =new Uri($"https://aaaa.something{caller.Sync()}.abcdefg") };
        var someHttpResponse = client.GetAsync("some other weird uri");
        var result = JsonConvert.DeserializeObject<int>(await someHttpResponse.Result.Content.ReadAsStringAsync());
        var res1 = await caller.AsyncRet();
        var someNum = GetSomeResult1(result) * res1;

        return new ComplexClassReturnClass(someNum);
    }

    private static int GetSomeResult1(int a)
    {
        var x = 0;
        for (var i = 0; i < a; i++)
        {
            x += i *= i;
        }

        return (int) (x * x / 0.3) + 203;
    }
}

public class ComplexClassReturnClass
{
    public ComplexClassReturnClass(int someValue)
    {
        SomeValue = someValue;
    }

    public int SomeValue { get; set; }
}