int buttonStatus; // Variable declare to store status of digitalWrite 
void setup() { 
pinMode(1, OUTPUT);  
pinMode(2, OUTPUT);  
pinMode(0, INPUT);  
} 
void loop() 
{ 
buttonStatus = digitalRead(0); 
if (buttonStatus == HIGH)  
{  
digitalWrite(1, HIGH); 
digitalWrite(2, HIGH);  
}  
else  
{ 
digitalWrite(1, LOW);  
digitalWrite(2, LOW);  
} 
} 