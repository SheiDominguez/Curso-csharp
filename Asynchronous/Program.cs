using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Loading...");
            //Asynchronous.WaitForIt();
            //await Asynchronous.WaitForIt2();
            var timeElapsed = await Paralelo.Main();
            Console.WriteLine($"Both processes finished after {timeElapsed / 1000m} seconds");
        }
    }

    class Asynchronous
    {
        public static async Task WaitForIt()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Five Seconds Complete");
        }

        public static async Task WaitForIt2()
        {
            await Task.Delay(10000);
            Console.WriteLine("Ten Seconds Complete");
        }

    }

    class Paralelo
    {
        public static async Task<long> Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var task1 = Proceso1();
            var task2 = Proceso2();

            //await Task.WhenAll(Proceso1(), Proceso2());
            await Task.WhenAll(task1, task2); // --> Espera a que se terminen todas las promesas
            // await Task.WhenAny(task1,task2); --> Solo importa si alguna se terminó

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }

        public static async Task Proceso1()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
            });
        }

        public static async Task Proceso2()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }
    }
}
