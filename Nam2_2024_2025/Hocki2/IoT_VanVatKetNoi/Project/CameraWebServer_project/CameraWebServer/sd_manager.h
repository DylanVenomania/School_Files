#ifndef SD_MANAGER_H
#define SD_MANAGER_H

#include <Arduino.h>
#include "SD_MMC.h"
#include "esp_camera.h"

// Các hằng số cho SD card
#define MAX_IMAGES 100
#define MAX_STORAGE_MB 100
#define CLEANUP_INTERVAL 60 // phút
#define CAPTURE_INTERVAL 5000 // 5 giây giữa các lần chụp

// Các biến toàn cục cho SD card
extern bool sdCardInitialized;
extern String savePath;
extern uint32_t maxImages;
extern uint32_t maxStorageMB;
extern uint32_t cleanupInterval;
extern uint32_t lastCleanupTime;
extern uint32_t lastCaptureTime;
extern uint32_t captureInterval;

// Các hàm cho SD card
bool saveImageToSD(camera_fb_t * fb);
void cleanupOldImages();

#endif // SD_MANAGER_H 