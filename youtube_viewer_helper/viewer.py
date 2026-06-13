import random
import time
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

class YouTubeViewer:
    def __init__(self, headless=True):
        self.options = Options()
        if headless:
            self.options.add_argument("--headless")
        self.options.add_argument("--disable-gpu")
        self.options.add_argument("--no-sandbox")
        self.driver = None

    def start(self):
        self.driver = webdriver.Chrome(options=self.options)

    def watch_video(self, video_url, watch_time=30):
        if not self.driver:
            self.start()

        self.driver.get(video_url)
        try:
            # Wait for video to load
            WebDriverWait(self.driver, 10).until(
                EC.presence_of_element_located((By.CSS_SELECTOR, "video"))
            )

            # Random mouse movements to simulate human behavior
            for _ in range(random.randint(2, 5)):
                self._random_mouse_movement()
                time.sleep(random.uniform(0.5, 2))

            # Watch for specified time
            time.sleep(watch_time)

        except Exception as e:
            print(f"Error watching video: {e}")
        finally:
            self.driver.quit()

    def _random_mouse_movement(self):
        if not self.driver:
            return

        width = self.driver.execute_script("return window.innerWidth")
        height = self.driver.execute_script("return window.innerHeight")

        x = random.randint(0, width)
        y = random.randint(0, height)

        action = webdriver.common.action_chains.ActionChains(self.driver)
        action.move_by_offset(x, y).perform()
        action.move_by_offset(-x, -y).perform()