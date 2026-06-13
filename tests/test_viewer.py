import unittest
from unittest.mock import MagicMock, patch
from youtube_viewer_helper.viewer import YouTubeViewer

class TestYouTubeViewer(unittest.TestCase):
    @patch('youtube_viewer_helper.viewer.webdriver.Chrome')
    def test_watch_video(self, mock_chrome):
        mock_driver = MagicMock()
        mock_chrome.return_value = mock_driver

        viewer = YouTubeViewer(headless=True)
        viewer.watch_video("https://youtube.com/watch?v=dQw4w9WgXcQ", watch_time=1)

        mock_driver.get.assert_called_once_with("https://youtube.com/watch?v=dQw4w9WgXcQ")
        mock_driver.quit.assert_called_once()

if __name__ == "__main__":
    unittest.main()