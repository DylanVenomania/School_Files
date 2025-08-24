#define LED_RED    2  // Đèn đỏ
#define LED_YELLOW 3  // Đèn vàng
#define LED_GREEN  4  // Đèn xanh

void setup() {
  pinMode(LED_RED, OUTPUT);
  pinMode(LED_YELLOW, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
}

void loop() {
  // Bật đèn xanh, tắt các đèn còn lại
  digitalWrite(LED_GREEN, HIGH);
  digitalWrite(LED_YELLOW, LOW);
  digitalWrite(LED_RED, LOW);
  delay(5000); // Đèn xanh sáng 5 giây

  // Bật đèn vàng, tắt đèn xanh
  digitalWrite(LED_GREEN, LOW);
  digitalWrite(LED_YELLOW, HIGH);
  digitalWrite(LED_RED, LOW);
  delay(2000); // Đèn vàng sáng 2 giây

  // Bật đèn đỏ, tắt đèn vàng
  digitalWrite(LED_GREEN, LOW);
  digitalWrite(LED_YELLOW, LOW);
  digitalWrite(LED_RED, HIGH);
  delay(5000); // Đèn đỏ sáng 5 giây
}
