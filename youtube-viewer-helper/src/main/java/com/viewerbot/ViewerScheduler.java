package com.viewerbot;

import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;
import java.util.logging.Logger;

public class ViewerScheduler {
    private static final Logger LOG = Logger.getLogger(ViewerScheduler.class.getName());
    private final ScheduledExecutorService scheduler;
    private final YouTubeViewerBot bot;

    public ViewerScheduler(YouTubeViewerBot bot) {
        this.bot = bot;
        this.scheduler = Executors.newSingleThreadScheduledExecutor();
    }

    public void scheduleView(String videoUrl, int delaySeconds) {
        scheduler.schedule(() -> {
            LOG.info("Starting scheduled view for: " + videoUrl);
            bot.watchVideo(videoUrl);
            LOG.info("Completed view for: " + videoUrl);
        }, delaySeconds, TimeUnit.SECONDS);
    }

    public void stop() {
        scheduler.shutdown();
        bot.shutdown();
    }
}