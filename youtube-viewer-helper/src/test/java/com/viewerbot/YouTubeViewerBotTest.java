package com.viewerbot;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class YouTubeViewerBotTest {
    private YouTubeViewerBot bot;

    @BeforeEach
    public void setUp() {
        bot = new YouTubeViewerBot();
    }

    @AfterEach
    public void tearDown() {
        bot.shutdown();
    }

    @Test
    public void testBotInitialState() {
        assertFalse(bot.isRunning(), "Bot should not be running initially");
    }

    @Test
    public void testWatchVideo() {
        bot.watchVideo("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        assertFalse(bot.isRunning(), "Bot should not be running after watch");
    }

    @Test
    public void testConcurrentWatchThrowsException() {
        bot.watchVideo("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        assertThrows(IllegalStateException.class, () -> {
            bot.watchVideo("https://www.youtube.com/watch?v=9bZkp7q19f0");
        });
    }
}