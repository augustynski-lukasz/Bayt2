using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bayt2
{
    class Program
    {
        private static bool _cancelled;
        private const int TolDelayTime = 3000;
        private const int MainDelayTime = 444;

        static void Main(string[] args)
        {
            var tolTask = CreateLifeTimeTask();
            tolTask.Start();

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            Console.WriteLine("Computing Fibonacci sequence, press Ctrl+C to cancel.");

            var index = 0;
            foreach (var number in new FibonacciNumbers())
            {
                Console.WriteLine($"Fibonacci number F({index++}) is: {number}");
                Thread.Sleep(MainDelayTime);
                if(_cancelled) break;
            }

            tolTask.Wait();
            Console.CancelKeyPress -= new ConsoleCancelEventHandler(Console_CancelKeyPress);
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Cancelling");
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            {
                _cancelled = true;
                e.Cancel = true;
            }
        }

        static Task CreateLifeTimeTask()
        {            
            return new Task(async () =>
            {
                while(!_cancelled)
                {
                    var tol = Tools.GetProgramLifetime();
                    Console.WriteLine($"Application time of life: {tol:F0} seconds");
                    await Task.Delay(TolDelayTime);
                }
            });
        }
    }
}
