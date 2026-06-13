using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeViewerHelper
{
    public class ViewerBot
    {
        private readonly BotConfig _config;
        private readonly HttpClient _httpClient;

        public ViewerBot(BotConfig config)
        {
            _config = config;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
        }

        public async Task RunAsync(CancellationToken token)
        {
            Console.WriteLine($"Target URL: {_config.VideoUrl}");
            Console.WriteLine($"Views to generate: {_config.ViewCount}");
            Console.WriteLine($"Delay between views: {_config.DelayMs}ms\n");

            int successCount = 0;
            int failCount = 0;

            for (int i = 0; i < _config.ViewCount; i++)
            {
                if (token.IsCancellationRequested)
                    break;

                Console.Write($"View {i + 1}/{_config.ViewCount}... ");

                try
                {
                    var response = await _httpClient.GetAsync(_config.VideoUrl, token);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("OK");
                        successCount++;
                    }
                    else
                    {
                        Console.WriteLine($"FAIL (HTTP {response.StatusCode})");
                        failCount++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                    failCount++;
                }

                if (i < _config.ViewCount - 1)
                    await Task.Delay(_config.DelayMs, token);
            }

            Console.WriteLine($"\nDone. Success: {successCount}, Failed: {failCount}");
        }
    }
}