// Interfacing Arduino with SD card example (get SD card info)
// include the SD library:
#include <SPI.h>
#include <SD.h>
// set up variables using the SD utility library functions:
Sd2Card card;
SdVolume volume;
SdFile root;
void setup() {
// Open serial communications and wait for port to open:
Serial.begin(9600);
while (!Serial) {
; // wait for serial port to connect. Needed for native USBport only
}
Serial.print("\nInitializing SD card...");
// we'll use the initialization code from the utilitylibraries
// since we're just testing if the card is working!
if (!card.init()) {
Serial.println("initialization failed. Things to check:");
Serial.println("* is a card inserted?");
Serial.println("* is your wiring correct?");
Serial.println("* did you change the chipSelect pin to matchyour shield or module?");
while (1);
} else {
Serial.println("Wiring is correct and a card is present.");
}
// print the type of card
Serial.println();
Serial.print("Card type: ");
switch (card.type()) {
case SD_CARD_TYPE_SD1:
Serial.println("SD1");
break;
case SD_CARD_TYPE_SD2:
Serial.println("SD2");
break;
case SD_CARD_TYPE_SDHC:
Serial.println("SDHC");
break;
default:
Serial.println("Unknown");
}
// Now we will try to open the 'volume'/'partition' - it should be FAT16 or FAT32
if (!volume.init(card)) {
Serial.println("Could not find FAT16/FAT32 partition.\nMake sure you've formatted the card");
while (1);
}
Serial.print("Clusters: ");
Serial.println(volume.clusterCount());
Serial.print("Blocks x Cluster: ");
Serial.println(volume.blocksPerCluster());
Serial.print("Total Blocks: ");
Serial.println(volume.blocksPerCluster() *
volume.clusterCount());
Serial.println();
// print the type and size of the first FAT-type volume
uint32_t volumesize;
Serial.print("Volume type is: FAT");
Serial.println(volume.fatType(), DEC);
volumesize = volume.blocksPerCluster(); // clusters arecollections of blocks
volumesize *= volume.clusterCount(); // we'll have a loof clusters
volumesize /= 2; // SD card blocksare always 512 bytes (2 blocks are 1KB)
Serial.print("Volume size (Kb): ");
Serial.println(volumesize);
Serial.print("Volume size (Mb): ");
volumesize /= 1024;
Serial.println(volumesize);
Serial.print("Volume size (Gb): ");
Serial.println((float)volumesize / 1024.0);
Serial.println("\nFiles found on the card (name, date and size in bytes): ");
root.openRoot(volume);
// list all files in the card with date and size
root.ls(LS_R | LS_DATE | LS_SIZE);
}
void loop(void) {
}