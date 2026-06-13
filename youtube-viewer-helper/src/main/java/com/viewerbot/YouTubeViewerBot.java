package com.viewerbot;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import java.time.Duration;

public class YouTubeViewerBot {
    private WebDriver driver;
    private boolean running;

    public YouTubeViewerBot() {
        ChromeOptions options = new ChromeOptions();
        options.addArguments("--headless", "--disable-gpu", "--no-sandbox");
        driver = new ChromeDriver(options);
        driver.manage().timeouts().pageLoadTimeout(Duration.ofSeconds(30));
        running = false;
    }

    public void watchVideo(String videoUrl) {
        if (running) {
            throw new IllegalStateException("Bot is already watching a video");
        }
        running = true;
        try {
            driver.get(videoUrl);
            // Simulate watching by waiting for page load
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        } finally {
            running = false;
        }
    }

    public boolean isRunning() {
        return running;
    }

    public void shutdown() {
        if (driver != null) {
            driver.quit();
        }
    }
}