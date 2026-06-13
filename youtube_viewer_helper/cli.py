import argparse
from .viewer import YouTubeViewer
from .config import Config

def main():
    parser = argparse.ArgumentParser(description="YouTube Viewer Helper")
    parser.add_argument("video_url", help="URL of the YouTube video to watch")
    parser.add_argument("--headless", action="store_false", help="Run in non-headless mode")
    parser.add_argument("--watch-time", type=int, default=30, help="Watch time in seconds")

    args = parser.parse_args()

    config = Config(headless=args.headless)
    viewer = YouTubeViewer(headless=config.headless)
    viewer.watch_video(args.video_url, watch_time=args.watch_time)

if __name__ == "__main__":
    main()