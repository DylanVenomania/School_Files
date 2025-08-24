#include "motion_detection.h"
#include "fb_gfx.h"
#include "img_converters.h"

bool jpegToGrayscale(camera_fb_t* jpeg_fb, uint8_t** grayBuf, size_t* width, size_t* height) {
  if (!jpeg_fb || jpeg_fb->format != PIXFORMAT_JPEG) return false;

  *width = jpeg_fb->width;
  *height = jpeg_fb->height;

  size_t rgb_size = (*width) * (*height) * 3;
  uint8_t* rgb_buf = (uint8_t*)malloc(rgb_size);
  if (!rgb_buf) {
    Serial.println("[ERROR] Không cấp phát được bộ nhớ RGB");
    return false;
  }

  if (!fmt2rgb888(jpeg_fb->buf, jpeg_fb->len, jpeg_fb->format, rgb_buf)) {
    Serial.println("[ERROR] Giải mã JPEG sang RGB thất bại");
    free(rgb_buf);
    return false;
  }

  *grayBuf = (uint8_t*)malloc((*width) * (*height));
  if (!(*grayBuf)) {
    Serial.println("[ERROR] Không cấp phát được bộ nhớ GRAYSCALE");
    free(rgb_buf);
    return false;
  }

  for (int i = 0; i < (*width) * (*height); i++) {
    uint8_t r = rgb_buf[i * 3 + 0];
    uint8_t g = rgb_buf[i * 3 + 1];
    uint8_t b = rgb_buf[i * 3 + 2];
    (*grayBuf)[i] = (r * 30 + g * 59 + b * 11) / 100;
  }

  free(rgb_buf);
  return true;
}

Box detectMotion() {
  Box result = { false, 0, 0, 0, 0, 0 };

  camera_fb_t* jpeg1 = esp_camera_fb_get();
  if (!jpeg1 || jpeg1->format != PIXFORMAT_JPEG) {
    if (jpeg1) esp_camera_fb_return(jpeg1);
    Serial.println("[ERROR] Không lấy được frame JPEG 1");
    return result;
  }

  uint8_t* gray1 = NULL;
  size_t width1, height1;
  if (!jpegToGrayscale(jpeg1, &gray1, &width1, &height1)) {
    esp_camera_fb_return(jpeg1);
    Serial.println("[ERROR] Không chuyển frame 1 sang grayscale");
    return result;
  }
  esp_camera_fb_return(jpeg1);
  delay(300);

  camera_fb_t* jpeg2 = esp_camera_fb_get();
  if (!jpeg2 || jpeg2->format != PIXFORMAT_JPEG) {
    if (jpeg2) esp_camera_fb_return(jpeg2);
    free(gray1);
    Serial.println("[ERROR] Không lấy được frame JPEG 2");
    return result;
  }

  uint8_t* gray2 = NULL;
  size_t width2, height2;
  if (!jpegToGrayscale(jpeg2, &gray2, &width2, &height2)) {
    esp_camera_fb_return(jpeg2);
    free(gray1);
    Serial.println("[ERROR] Không chuyển frame 2 sang grayscale");
    return result;
  }
  esp_camera_fb_return(jpeg2);

  int blocksX = width1 / BLOCK_SIZE;
  int blocksY = height1 / BLOCK_SIZE;
  bool firstBlock = true;

  for (int by = 0; by < blocksY; by++) {
    for (int bx = 0; bx < blocksX; bx++) {
      int sum1 = 0, sum2 = 0;
      for (int y = 0; y < BLOCK_SIZE; y++) {
        for (int x = 0; x < BLOCK_SIZE; x++) {
          int px = bx * BLOCK_SIZE + x;
          int py = by * BLOCK_SIZE + y;
          int idx = py * width1 + px;
          sum1 += gray1[idx];
          sum2 += gray2[idx];
        }
      }

      int avg1 = sum1 / (BLOCK_SIZE * BLOCK_SIZE);
      int avg2 = sum2 / (BLOCK_SIZE * BLOCK_SIZE);
      if (abs(avg1 - avg2) > DIFF_THRESHOLD) {
        result.blockCount++;
        int px = bx * BLOCK_SIZE;
        int py = by * BLOCK_SIZE;

        if (firstBlock) {
          result.x_min = px;
          result.y_min = py;
          result.x_max = px + BLOCK_SIZE - 1;
          result.y_max = py + BLOCK_SIZE - 1;
          firstBlock = false;
        } else {
          if (px < result.x_min) result.x_min = px;
          if (py < result.y_min) result.y_min = py;
          if (px + BLOCK_SIZE - 1 > result.x_max) result.x_max = px + BLOCK_SIZE - 1;
          if (py + BLOCK_SIZE - 1 > result.y_max) result.y_max = py + BLOCK_SIZE - 1;
        }
      }
    }
  }

  free(gray1);
  free(gray2);

  if (result.blockCount >= MOTION_BLOCK_COUNT) {
    result.hasMotion = true;
    Serial.printf("[INFO] Có chuyển động (%d khối) tại (%d, %d) -> (%d, %d)\n",
                  result.blockCount, result.x_min, result.y_min, result.x_max, result.y_max);
  }

  return result;
}
