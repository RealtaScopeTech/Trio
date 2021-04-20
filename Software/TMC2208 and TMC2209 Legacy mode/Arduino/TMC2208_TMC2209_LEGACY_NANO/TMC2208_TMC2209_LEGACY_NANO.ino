// Realta: Súil a Trí
#include <EEPROM.h>
#include <Arduino.h>
#include <Adafruit_AHTX0.h>
#include "MyData.h"
#include "MyEPROM.h"
#include "MyDew.h"
#include "MyFocus.h"
#include "MyTemp.h"
#include "MySerial.h"

void setup() {
  // turn the serial port on
  // code in MySerial.h
  P_INIT_SERIAL_PORT();
  
  // Set output pins
  // See DataStructure for pin mapping
  // Code in MyData.h
  P_SET_OUTPUT_PINS();
  
  //Read last saved dew status
  // Code in MyEPROM.h
  READ_EPROM_DEW();
  
  //Read last saved dew status
  // Code in MyEPROM.h
  READ_EPROM_FOCUSER();
  //Set PWM values to zero
  //We do not want these to come on unless user asks for it
  V_DEW_LOCKED = true;
  V_IS_MOVING = false;
  V_STEPS_TO_MAKE = 0;

  // SET DEFAULT STEPPING MODE REFERENCES
  P_SET_STEPPING_MODES();

  // SET SLEEP AND RESET HIGH
  pinMode(2, OUTPUT);
  pinMode(7, OUTPUT);
  digitalWrite(2, HIGH );
  digitalWrite(7, HIGH );

  // 2208 probably has a clk or some other pin where the 8825 has M3
   digitalWrite(STEP_M3_PIN , LOW);

  // UPDATE STEPPING PINS TO SAVED VALUES
  P_UPDATE_STEPPER_PINS();

  // Try to start AHT20
  P_CHECK_SENSOR_EXISTS();

  // Read temp offset
  READ_EPROM_TEMP_OFFSET();

  digitalWrite(STEP_M2_PIN, STEPPING_MODE[S_MY_FOCUSER_STATUS.V_STEP_MODE].M2_STATE );
  
}


//////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////


void loop() {
  
  ////////////////////////////////
  //
  // Check and read serial port
  //
  ///////////////////////////////

  // This procedure reads latest serial port 
  // value and decides what to do with it
  // it will keep adding chars to V_SERIAL_TEXT until it gets to a line feed
  // then send the command on to processing
  // Code in MySerial.h
  P_PROCESS_SERIAL_PORT ();

  if (V_IS_MOVING)
  {
    P_STEP ();
  }

  // Not sure if I need to keep setting the PWM pins every loop.
  // Code in MyDew.h
  P_SET_PWM_PINS();

}
