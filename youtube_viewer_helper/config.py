import os
from dataclasses import dataclass

@dataclass
class Config:
    headless: bool = True
    watch_time_min: int = 30
    watch_time_max: int = 120
    chrome_driver_path: str = os.getenv("CHROME_DRIVER_PATH", "/usr/local/bin/chromedriver")