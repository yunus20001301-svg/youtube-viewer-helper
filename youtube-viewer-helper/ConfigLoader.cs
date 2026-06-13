using System;
using System.IO;
using System.Text.Json;

namespace YoutubeViewerHelper
{
    public class BotConfig
    {
        public string VideoUrl { get; set; } = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        public int ViewCount { get; set; } = 10;
        public int DelayMs { get; set; } = 5000;
    }

    public static class ConfigLoader
    {
        public static BotConfig Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Config not found, using defaults.");
                return new BotConfig();
            }

            try
            {
                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<BotConfig>(json) ?? new BotConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading config: {ex.Message}");
                return new BotConfig();
            }
        }
    }
}