using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using MonkeyPatcher.MonkeyPatch.Concrete;
using MonkeyPatcher.MonkeyPatch.Concrete.Dto;
using MonkeyPatcher.MonkeyPatch.Shared;
using MonkeyPatcherTests.TestObjects;
using Xunit;

namespace MonkeyPatcherTests.Concrete;

public class TestComplexClass
{
    // throws because the TestCaller.Sync class calls ClassToOverride, which only throws NotImplementedExceptions.
    [Fact]
    public async Task Test_FailingOriginalVersion()
    {
        var sut = new ComplexClass();
        var exception = await sut.Invoking(x => x.GetTestClass(new TestCaller())).Should().ThrowAsync<NotImplementedException>();
        exception.And.Message.Should().Be("ToOverrideVoid");
    }  

    // throws because the httpclient can't find the fake address
    [Fact]
    public async Task Test_Failing_MockingOnly_Sync()
    {
        var sut = new ComplexClass();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.GetTestClass);
        mp.Override<TestCaller, int>(x => x.Sync(), ()=> 3);

        var exception = await sut.Invoking(x => x.GetTestClass(new TestCaller())).Should().ThrowAsync<AggregateException>();
        exception.And.Message.Should().Be("One or more errors occurred. (No such host is known. (aaaa.something3.abcdefg:443))");
    }

    // throws because the TestCaller.AsyncRet calls ClassToOverride, which only throws NotImplementedExceptions.
    [Fact]
    public async Task Test_Failing_Mocking_Sync_and_HttpClient()
    {
        var sut = new ComplexClass();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.GetTestClass);
        mp.Override<TestCaller, int>(x => x.Sync(), ()=> 3);


        mp.Override<HttpClient, Task<HttpResponseMessage>>(x => x.GetAsync(Any<string>.Value), ()=>
        {
            var message = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("3")
            };
            return Task.FromResult(message);
        });
        var exception = await sut.Invoking(x => x.GetTestClass(new TestCaller())).Should().ThrowAsync<NotImplementedException>();
        exception.And.Message.Should().Be("ToOverrideAsyncRet");
    }  
    
    [Fact]
    public async Task Test_Passing()
    {
        var sut = new ComplexClass();
        using var mp = MonkeyPatcherFactory.GetMonkeyPatch(sut.GetTestClass, 1000);
        mp.Override<TestCaller, int>(x => x.Sync(), ()=> 3);

        mp.Override<HttpClient, Task<HttpResponseMessage>>(x => x.GetAsync(Any<string>.Value), ()=> Task.FromResult(new HttpResponseMessage(HttpStatusCode.Accepted)
        {
            Content = new StringContent("3")
        }));
        mp.Override<TestCaller, Task>(x => x.AsyncRet(), ()=> Task.FromResult(1));
        var result = await sut.GetTestClass(new TestCaller());
        result.SomeValue.Should().Be(286);
    }
}