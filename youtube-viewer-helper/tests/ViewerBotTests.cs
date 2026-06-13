using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace YoutubeViewerHelper.Tests
{
    public class ViewerBotTests
    {
        [Fact]
        public async Task RunAsync_WithValidConfig_DoesNotThrow()
        {
            var config = new BotConfig
            {
                VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                ViewCount = 2,
                DelayMs = 100
            };

            var bot = new ViewerBot(config);
            var cts = new CancellationTokenSource();

            // Should complete without exception
            await bot.RunAsync(cts.Token);
        }

        [Fact]
        public void ConfigLoader_LoadsDefault_WhenFileMissing()
        {
            var config = ConfigLoader.Load("nonexistent.json");
            Assert.NotNull(config);
            Assert.Equal(10, config.ViewCount);
        }
    }
}