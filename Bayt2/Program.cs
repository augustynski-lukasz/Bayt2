using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bayt2
{
    class Program
    {
        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private const int TolDelayTime = 13000;
        private const int MainDelayTime = 444;

        private static void Main()
        {
            var tolTask = CreateLifeTimeTask(_cancellationTokenSource.Token);
            tolTask.Start();

            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Computing Fibonacci sequence, press Ctrl+C to cancel.");

            var index = 0;
            foreach (var number in new FibonacciNumbers())
            {
                Console.WriteLine($"Fibonacci number F({index++}) is: {number}");
                Thread.Sleep(MainDelayTime);
                if(_cancellationTokenSource.Token.IsCancellationRequested) break;
            }

            tolTask.Wait();
            Console.CancelKeyPress -= Console_CancelKeyPress;
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Cancelling");
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            {
                _cancellationTokenSource.Cancel();
                e.Cancel = true;
            }
        }

        static Task CreateLifeTimeTask(CancellationToken cancellationToken)
        {            
            return new Task(async () =>
            {
                while(!cancellationToken.IsCancellationRequested)
                {
                    var tol = Tools.GetProgramLifetime();
                    Console.WriteLine($"Application time of life: {tol:F0} seconds");
                    await Task.Delay(TolDelayTime, cancellationToken)
                        .ContinueWith(tsk => { }); ;
                }
            });
        }
    }
}
