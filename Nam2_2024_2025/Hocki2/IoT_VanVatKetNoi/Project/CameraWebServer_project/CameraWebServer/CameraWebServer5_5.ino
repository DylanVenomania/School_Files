#include "esp_camera.h"
#include <WiFi.h>
#include <WiFiClientSecure.h>
#include "motion_detection.h"
#include <UniversalTelegramBot.h>
#include <ArduinoJson.h>
#include <HTTPClient.h>
#include "FS.h"
#include "SD_MMC.h"
#include "fb_gfx.h"
#include "esp_http_server.h"
#include "esp_timer.h"
#include "img_converters.h"
#include "camera_index.h"
#include "sd_manager.h"
#include "Arduino.h"
//
// WARNING!!! PSRAM IC required for UXGA resolution and high JPEG quality
//            Ensure ESP32 Wrover Module or other board with PSRAM is selected
//            Partial images will be transmitted if image exceeds buffer size
//
//            You must select partition scheme from the board menu that has at least 3MB APP space.
//            Face Recognition is DISABLED for ESP32 and ESP32-S2, because it takes up from 15
//            seconds to process single frame. Face Detection is ENABLED if PSRAM is enabled as well

// ===================
// Select camera model
// ===================
//#define CAMERA_MODEL_WROVER_KIT // Has PSRAM
///define CAMERA_MODEL_ESP_EYE  // Has PSRAM
//#define CAMERA_MODEL_ESP32S3_EYE // Has PSRAM
//#define CAMERA_MODEL_M5STACK_PSRAM // Has PSRAM
//#define CAMERA_MODEL_M5STACK_V2_PSRAM // M5Camera version B Has PSRAM
//#define CAMERA_MODEL_M5STACK_WIDE // Has PSRAM
//#define CAMERA_MODEL_M5STACK_ESP32CAM // No PSRAM
//#define CAMERA_MODEL_M5STACK_UNITCAM // No PSRAM
//#define CAMERA_MODEL_M5STACK_CAMS3_UNIT  // Has PSRAM
#define CAMERA_MODEL_AI_THINKER // Has PSRAM
//#define CAMERA_MODEL_TTGO_T_JOURNAL // No PSRAM
//#define CAMERA_MODEL_XIAO_ESP32S3 // Has PSRAM
// ** Espressif Internal Boards **
//#define CAMERA_MODEL_ESP32_CAM_BOARD
//#define CAMERA_MODEL_ESP32S2_CAM_BOARD
//#define CAMERA_MODEL_ESP32S3_CAM_LCD
//#define CAMERA_MODEL_DFRobot_FireBeetle2_ESP32S3 // Has PSRAM
//#define CAMERA_MODEL_DFRobot_Romeo_ESP32S3 // Has PSRAM
#include "camera_pins.h"
#define LED_FLASH 4
// ===========================
// Enter your WiFi credentials
// ===========================
const char *ssid = "Lovepeace";//"BeKind Home";//"**********";
const char *password = "lovevietnam";//"moitruongtute";//"**********";


//////////////////////////////////////////////
// Thay bằng Bot Token và Chat ID của bạn
String BOT_TOKEN ="7951709003:AAGwI8fTdHnXutkf1nxud4r-yCNyoRslWlo";
String CHAT_ID ="7506824478";

// Telegram bot client
#ifdef ESP8266
  X509List cert(TELEGRAM_CERTIFICATE_ROOT);
#endif

WiFiClientSecure client;
UniversalTelegramBot bot(BOT_TOKEN, client);

// Notification control
unsigned long lastSentTime = 0;
const unsigned long delayBetweenSends = 3 * 60 * 1000UL;
int motionCount = 0;
bool firstMotion = true;

// Các hằng số cho SD card
#define MAX_IMAGES 100
#define MAX_STORAGE_MB 100
#define CLEANUP_INTERVAL 60 // phút
#define CAPTURE_INTERVAL 5000 // 5 giây giữa các lần chụp

// Các biến toàn cục cho SD card
bool sdCardInitialized = false;
String savePath = "/images";
uint32_t maxImages = MAX_IMAGES;
uint32_t maxStorageMB = MAX_STORAGE_MB;
uint32_t cleanupInterval = CLEANUP_INTERVAL * 60000; // Chuyển phút thành mili giây
uint32_t lastCleanupTime = 0;
uint32_t lastCaptureTime = 0;
uint32_t captureInterval = CAPTURE_INTERVAL;

void startCameraServer();
void setupLedFlash(int pin);
void setup() {
  Serial.begin(115200);
  Serial.setDebugOutput(true);
  Serial.println();

  pinMode(LED_FLASH, OUTPUT);
  digitalWrite(LED_FLASH, LOW); // Tắt đèn lúc khởi động
  Serial.begin(115200);

  // Khởi tạo SD Card
  if(!SD_MMC.begin()){
    Serial.println("SD Card Mount Failed");
    sdCardInitialized = false;
  } else {
    uint8_t cardType = SD_MMC.cardType();
    if(cardType == CARD_NONE){
      Serial.println("No SD card attached");
      sdCardInitialized = false;
    } else {
      Serial.print("SD Card Type: ");
      if(cardType == CARD_MMC){
        Serial.println("MMC");
      } else if(cardType == CARD_SD){
        Serial.println("SDSC");
      } else if(cardType == CARD_SDHC){
        Serial.println("SDHC");
      } else {
        Serial.println("UNKNOWN");
      }
      
      uint64_t cardSize = SD_MMC.cardSize() / (1024 * 1024);
      Serial.printf("SD Card Size: %lluMB\n", cardSize);
      
      sdCardInitialized = true;
      Serial.println("SD Card Mount Success");
      
      // Tạo thư mục images nếu chưa tồn tại
      if(!SD_MMC.exists(savePath.c_str())){
        if(SD_MMC.mkdir(savePath.c_str())){
          Serial.println("Created images directory");
        } else {
          Serial.println("Failed to create images directory");
        }
      }
    }
  }

  camera_config_t config;
  config.ledc_channel = LEDC_CHANNEL_0;
  config.ledc_timer = LEDC_TIMER_0;
  config.pin_d0 = Y2_GPIO_NUM;
  config.pin_d1 = Y3_GPIO_NUM;
  config.pin_d2 = Y4_GPIO_NUM;
  config.pin_d3 = Y5_GPIO_NUM;
  config.pin_d4 = Y6_GPIO_NUM;
  config.pin_d5 = Y7_GPIO_NUM;
  config.pin_d6 = Y8_GPIO_NUM;
  config.pin_d7 = Y9_GPIO_NUM;
  config.pin_xclk = XCLK_GPIO_NUM;
  config.pin_pclk = PCLK_GPIO_NUM;
  config.pin_vsync = VSYNC_GPIO_NUM;
  config.pin_href = HREF_GPIO_NUM;
  config.pin_sccb_sda = SIOD_GPIO_NUM;
  config.pin_sccb_scl = SIOC_GPIO_NUM;
  config.pin_pwdn = PWDN_GPIO_NUM;
  config.pin_reset = RESET_GPIO_NUM;
  config.xclk_freq_hz = 20000000;
  config.frame_size = FRAMESIZE_UXGA;
  config.pixel_format = PIXFORMAT_JPEG;  // for streaming
  //config.pixel_format = PIXFORMAT_RGB565; // for face detection/recognition
  config.grab_mode = CAMERA_GRAB_WHEN_EMPTY;
  config.fb_location = CAMERA_FB_IN_PSRAM;
  config.jpeg_quality = 12;
  config.fb_count = 1;

  // if PSRAM IC present, init with UXGA resolution and higher JPEG quality
  //                      for larger pre-allocated frame buffer.
  if (config.pixel_format == PIXFORMAT_JPEG) {
    if (psramFound()) {
      config.jpeg_quality = 10;
      config.fb_count = 2;
      config.grab_mode = CAMERA_GRAB_LATEST;
    } else {
      // Limit the frame size when PSRAM is not available
      config.frame_size = FRAMESIZE_SVGA;
      config.fb_location = CAMERA_FB_IN_DRAM;
    }
  } else {
    // Best option for face detection/recognition
    config.frame_size = FRAMESIZE_240X240;
#if CONFIG_IDF_TARGET_ESP32S3
    config.fb_count = 2;
#endif
  }

#if defined(CAMERA_MODEL_ESP_EYE)
  pinMode(13, INPUT_PULLUP);
  pinMode(14, INPUT_PULLUP);
#endif

  // camera init
  esp_err_t err = esp_camera_init(&config);
  if (err != ESP_OK) {
    Serial.printf("Camera init failed with error 0x%x", err);
    return;
  }

  sensor_t *s = esp_camera_sensor_get();
  // initial sensors are flipped vertically and colors are a bit saturated
  if (s->id.PID == OV3660_PID) {
    s->set_vflip(s, 1);        // flip it back
    s->set_brightness(s, 1);   // up the brightness just a bit
    s->set_saturation(s, -2);  // lower the saturation
  }
  // drop down frame size for higher initial frame rate
  if (config.pixel_format == PIXFORMAT_JPEG) {
    s->set_framesize(s, FRAMESIZE_QVGA);
  }

#if defined(CAMERA_MODEL_M5STACK_WIDE) || defined(CAMERA_MODEL_M5STACK_ESP32CAM)
  s->set_vflip(s, 1);
  s->set_hmirror(s, 1);
#endif

#if defined(CAMERA_MODEL_ESP32S3_EYE)
  s->set_vflip(s, 1);
#endif

// Setup LED FLash if LED pin is defined in camera_pins.h
#if defined(LED_GPIO_NUM)
  setupLedFlash(LED_GPIO_NUM);
#endif

  WiFi.begin(ssid, password);
  WiFi.setSleep(false);

  Serial.print("WiFi connecting");
  client.setCACert(TELEGRAM_CERTIFICATE_ROOT);//thêm vào để gửi ảnh
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected");

  startCameraServer();

  Serial.print("Camera Ready! Use 'http://");
  Serial.print(WiFi.localIP());
  Serial.println("' to connect");

  // Gửi tin nhắn khởi động để kiểm tra
  //sendTelegramMessage("Hello from ESP32!");
}

void sendTelegramMessage(String message) {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    String url = "https://api.telegram.org/bot" + BOT_TOKEN + "/sendMessage?chat_id=" + CHAT_ID + "&text=" + message;
    
    http.begin(url);
    int httpResponseCode = http.GET();
    
    if (httpResponseCode > 0) {
      Serial.println("Message sent to Telegram");
    } else {
      Serial.print("Error sending message: ");
      Serial.println(http.errorToString(httpResponseCode));
    }
    http.end();
  }
}
String sendPhotoTelegram() {
  const char* myDomain = "api.telegram.org";
  String getAll = "";
  String getBody = "";

  camera_fb_t * fb = NULL;
  fb = esp_camera_fb_get();  
  if(!fb) {
    Serial.println("Camera capture failed");
    delay(1000);
    ESP.restart();
    return "Camera capture failed";
  }  
  
  Serial.println("Connect to " + String(myDomain));


  if (client.connect(myDomain, 443)) {
    Serial.println("Connection successful");
    
    String head = "--Electro\r\nContent-Disposition: form-data; name=\"chat_id\"; \r\n\r\n" + CHAT_ID + "\r\n--Electro\r\nContent-Disposition: form-data; name=\"photo\"; filename=\"esp32-cam.jpg\"\r\nContent-Type: image/jpeg\r\n\r\n";
    String tail = "\r\n--Electro--\r\n";

    uint16_t imageLen = fb->len;
    uint16_t extraLen = head.length() + tail.length();
    uint16_t totalLen = imageLen + extraLen;
  
    client.println("POST /bot"+BOT_TOKEN+"/sendPhoto HTTP/1.1");
    client.println("Host: " + String(myDomain));
    client.println("Content-Length: " + String(totalLen));
    client.println("Content-Type: multipart/form-data; boundary=Electro");
    client.println();
    client.print(head);
  
    uint8_t *fbBuf = fb->buf;
    size_t fbLen = fb->len;
    for (size_t n=0;n<fbLen;n=n+1024) {
      if (n+1024<fbLen) {
        client.write(fbBuf, 1024);
        fbBuf += 1024;
      }
      else if (fbLen%1024>0) {
        size_t remainder = fbLen%1024;
        client.write(fbBuf, remainder);
      }
    }  
    
    client.print(tail);
    
    esp_camera_fb_return(fb);
    
    int waitTime = 10000;   // timeout 10 seconds
    long startTimer = millis();
    boolean state = false;
    
    while ((startTimer + waitTime) > millis()){
      Serial.print(".");
      delay(100);      
      while (client.available()) {
        char c = client.read();
        if (state==true) getBody += String(c);        
        if (c == '\n') {
          if (getAll.length()==0) state=true; 
          getAll = "";
        } 
        else if (c != '\r')
          getAll += String(c);
        startTimer = millis();
      }
      if (getBody.length()>0) break;
    }
    client.stop();
    Serial.println(getBody);
  }
  else {
    getBody="Connected to api.telegram.org failed.";
    Serial.println("Connected to api.telegram.org failed.");
  }
  return getBody;
}

void loop() {
  Box motion= detectMotion();
  // Do nothing. Everything is done in another task by the web server
  if (motion.hasMotion) {
    motionCount++;
    Serial.println("[" + String(motionCount) + "] 🚨 Phát hiện chuyển động!");
    unsigned long now = millis();
    if (firstMotion || (now - lastSentTime >= delayBetweenSends)) {
    sendTelegramMessage("Motion detected!");
    sendPhotoTelegram();
    lastSentTime = now;
    firstMotion = false;
    }
  }
  delay(400);
}
