using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AsyncAwaitVsTask
    {
        public static async Task Execute1()
        {
            Console.WriteLine($"Execute Before: {Thread.CurrentThread.ManagedThreadId}");
            await AsyncAwaitClass.MakeFakeCallOnlyCPUAsync().ContinueWith(t =>
            {
                Calulate();

            });
            Console.WriteLine($"Execute After: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task Execute2()
        {
            Console.WriteLine($"Execute Before: {Thread.CurrentThread.ManagedThreadId}");
            await AsyncAwaitClass.MakeFakeCallOnlyCPUAsync();

            Calulate();

            Console.WriteLine($"Execute After: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static void Calulate()
        {
            Console.WriteLine($"Calulate Before Sleep: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(10);
            Console.WriteLine($"Calulate After Sleep: {Thread.CurrentThread.ManagedThreadId}");
        }

        public class AsyncAwaitClass
        {
            public static async Task MakeCallAsync()
            {
                Console.WriteLine($"AsyncAwaitClass Before call: {Thread.CurrentThread.ManagedThreadId}");
                var client = new RestClient("http://46.4.63.238/");
                var request = new RestRequest("sites.json", Method.Get);
                await client.GetAsync(request);
                Console.WriteLine($"AsyncAwaitClass After call: {Thread.CurrentThread.ManagedThreadId}");
            }

            public static async Task MakeFakeCallOnlyCPUAsync()
            {
                Console.WriteLine($"AsyncAwaitClass Before call: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(10);
                Console.WriteLine($"AsyncAwaitClass After call: {Thread.CurrentThread.ManagedThreadId}");

            }
        }
    }
}