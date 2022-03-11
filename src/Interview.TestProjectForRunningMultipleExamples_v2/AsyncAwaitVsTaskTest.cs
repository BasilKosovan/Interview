using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            AsyncAwaitClass.MakeCallAsync().ContinueWith(t =>
            {
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


