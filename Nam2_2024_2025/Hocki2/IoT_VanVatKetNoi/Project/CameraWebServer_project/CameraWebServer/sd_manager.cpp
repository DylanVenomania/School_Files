#include "sd_manager.h"
#include "esp_camera.h"

bool saveImageToSD(camera_fb_t * fb) {
  if (!sdCardInitialized || !fb || !fb->buf || fb->len == 0) {
    Serial.println("Cannot save image: Invalid parameters or SD card not initialized");
    return false;
  }
  
  // Tạo tên file với timestamp
  char filename[32];
  snprintf(filename, sizeof(filename), "%s/%lu.jpg", savePath.c_str(), millis());
  
  // Mở file để ghi
  File file = SD_MMC.open(filename, FILE_WRITE);
  if (!file) {
    Serial.println("Failed to open file for writing");
    return false;
  }
  
  // Ghi dữ liệu ảnh
  size_t written = file.write(fb->buf, fb->len);
  file.close();
  
  if (written != fb->len) {
    Serial.println("Failed to write complete file");
    return false;
  }
  
  Serial.printf("Saved image: %s\n", filename);
  return true;
}

void cleanupOldImages() {
  if (!sdCardInitialized) {
    Serial.println("Cannot cleanup: SD card not initialized");
    return;
  }
  
  File root = SD_MMC.open(savePath);
  if (!root) {
    Serial.println("Failed to open images directory");
    return;
  }
  
  File file = root.openNextFile();
  uint32_t totalSize = 0;
  uint32_t fileCount = 0;
  std::vector<String> filesToDelete;
  
  // Đếm tổng số file và kích thước
  while (file) {
    if (!file.isDirectory()) {
      totalSize += file.size();
      fileCount++;
      if (fileCount > maxImages || totalSize > (maxStorageMB * 1024 * 1024)) {
        filesToDelete.push_back(String(file.name()));
      }
    }
    file = root.openNextFile();
  }
  
  // Xóa các file cũ nhất
  for (const String& filename : filesToDelete) {
    if (SD_MMC.remove(filename.c_str())) {
      Serial.printf("Deleted old file: %s\n", filename.c_str());
    } else {
      Serial.printf("Failed to delete file: %s\n", filename.c_str());
    }
  }
  
  root.close();
} 