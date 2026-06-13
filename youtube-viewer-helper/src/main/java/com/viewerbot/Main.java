package com.viewerbot;

import java.util.logging.Logger;

public class Main {
    private static final Logger LOG = Logger.getLogger(Main.class.getName());

    public static void main(String[] args) {
        YouTubeViewerBot bot = new YouTubeViewerBot();
        ViewerScheduler scheduler = new ViewerScheduler(bot);

        String videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        LOG.info("Scheduling view for: " + videoUrl);
        scheduler.scheduleView(videoUrl, 2);

        // Keep main thread alive for demo
        try {
            Thread.sleep(10000);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        } finally {
            scheduler.stop();
            LOG.info("Bot shutdown complete");
        }
    }
}