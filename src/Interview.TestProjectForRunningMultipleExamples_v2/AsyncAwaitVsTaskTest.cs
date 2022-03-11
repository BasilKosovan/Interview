using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Interview.AsyncAwaitVsTask;

namespace Interview.TestProjectForRunningMultipleExamples_v2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Ignore]
        public void Test_1_CPU_Execute_1_WithContinue()
        {
            Console.WriteLine($"Execute1 Before: {Thread.CurrentThread.ManagedThreadId}");
            AsyncAwaitClass.MakeFakeCallOnlyCPUAsync().ContinueWith(t =>
            {
                Calulate();
                Console.WriteLine($"Execute1 After: {Thread.CurrentThread.ManagedThreadId}");
            }).Wait();            
        }

        [TestMethod]
        [Ignore]
        public async Task Test_1_CPU_Execute_2_WithAwait()
        {
            Console.WriteLine($"Execute2 Before: {Thread.CurrentThread.ManagedThreadId}");
            await AsyncAwaitClass.MakeFakeCallOnlyCPUAsync();

            Calulate();
            Console.WriteLine($"Execute2 After: {Thread.CurrentThread.ManagedThreadId}");
        }

        [TestMethod]
        public void Test_2_I_O_Execute_1_WithContinue()
        {
            Console.WriteLine($"Execute1 Before: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"AsyncAwaitClass Before call: {Thread.CurrentThread.ManagedThreadId}");
            var client = new RestClient("http://46.4.63.238/");
            var request = new RestRequest("sites.json", Method.Get);
            client.GetAsync(request).ContinueWith(t =>
            {
                Console.WriteLine($"AsyncAwaitClass After call: {Thread.CurrentThread.ManagedThreadId}");
                Calulate();
                Console.WriteLine($"Execute1 After: {Thread.CurrentThread.ManagedThreadId}");
            }).Wait();           
        }

        [TestMethod]
        public async Task Test_2_I_O_Execute_2_WithAwait()
        {
            Console.WriteLine($"Execute2 Before: {Thread.CurrentThread.ManagedThreadId}");
            await AsyncAwaitClass.MakeCallAsync();

            Calulate();

            Console.WriteLine($"Execute2 After: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}


