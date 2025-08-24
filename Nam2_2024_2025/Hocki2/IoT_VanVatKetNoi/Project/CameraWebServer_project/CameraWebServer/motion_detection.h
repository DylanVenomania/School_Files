#ifndef MOTION_DETECTION_H
#define MOTION_DETECTION_H

#include "esp_camera.h"
#include "Arduino.h"

#define BLOCK_SIZE 16
#define DIFF_THRESHOLD 30
#define MOTION_BLOCK_COUNT 10

typedef struct {
  bool hasMotion;
  int x_min;
  int y_min;
  int x_max;
  int y_max;
  int blockCount;
} Box;

Box detectMotion();

#endif
