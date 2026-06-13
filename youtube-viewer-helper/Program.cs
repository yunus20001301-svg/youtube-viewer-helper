using System;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeViewerHelper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("YouTube Viewer Helper v1.0");
            Console.WriteLine("===========================");

            var config = ConfigLoader.Load("config.json");
            var bot = new ViewerBot(config);

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("\nShutting down...");
                cts.Cancel();
                e.Cancel = true;
            };

            await bot.RunAsync(cts.Token);
        }
    }
}