using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Interview
{
    public class AsyncAwaitVsTask
    {
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

            public static Task MakeFakeCallOnlyCPUAsync()
            {
                Console.WriteLine($"AsyncAwaitClass Before call: {Thread.CurrentThread.ManagedThreadId}");
                return Task.Run(() => Task.Delay(1));
            }
        }
    }
}