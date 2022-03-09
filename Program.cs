using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //VirtualOverrideVsNew.Execute();
            //RefOut.Execute();

            //await AsyncAwaitVsTask.Execute1();
            await AsyncAwaitVsTask.Execute2();


            Console.ReadKey();
        }

    }
}