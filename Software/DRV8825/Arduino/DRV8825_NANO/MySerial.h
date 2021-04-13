///////////////////////////////////////////////////
///////////// SERIAL //////////////////////////////
///////////////////////////////////////////////////

void P_INIT_SERIAL_PORT()
{
  Serial.begin(9600);
  // Read serial just incase there's crap there
  // loop handles serial comunication
  if(Serial.available() > 0) 
   {
    Serial.read();
   }

  // Set incoming serial string to empty
  V_SERIAL_TEXT ="";
}

// This is a list of general serial commands we expect to receive

// GENERAL
// SERIAL STRING "RESET_TO_DEFAULT" Sets dew and stepper motor values to defaults


///////////////////////////////////////////////////////////////
///  MAIN PROCEDURE TO PROCESS COMMANDS                    ////
///////////////////////////////////////////////////////////////

void P_PROCESS_COMMUNICATION() 
{
// First we will dig out the actual command
// This is the text up to the first pipe "|" or line feed which ever comes first
// A pipe means the command will come with data specific to the command
V_COMMAND = "";
V_PARAMS = "";
V_SERIAL_OUT ="";
V_HAS_PARAMS = false;
V_PARAMS_START_AT = 0;

// Get length of string so we can loop through it
V_INCOMING_STRING_LENGTH = V_SERIAL_TEXT.length();
// Find first char of incoming string for later
V_FIRST_CHAR = V_SERIAL_TEXT.charAt(0);



// Loop through it
for (int i = 0; i < V_INCOMING_STRING_LENGTH; i++) 
{
  // We are looking for one of two types of end command chars
  V_END_COMMAND_FOUND = false;

  // We found line feed
  if (V_SERIAL_TEXT.charAt(i) == '\n' )
  {
  V_END_COMMAND_FOUND = true;
  }

  // We found pipe 
  if (V_SERIAL_TEXT.charAt(i) == '|') 
  {
  V_HAS_PARAMS = true;
  V_END_COMMAND_FOUND = true;
  V_PARAMS_START_AT = i;
  }

  // If we didn't find the end of the command
  // we will add the character to our command string
  // and continue looping until we find it
  if (!V_END_COMMAND_FOUND)
  {
    V_COMMAND += V_SERIAL_TEXT.charAt(i);
  }

  // if we did find the end of command then we just exit
  // loop otherwise carry on finding rest of command text
  if (V_END_COMMAND_FOUND)
  {
     break;
  }
}

// Check to see if we got any parameters 
// And store them in param list if we did
if (V_HAS_PARAMS) 
{
   V_PARAMS = V_SERIAL_TEXT.substring(V_PARAMS_START_AT, V_INCOMING_STRING_LENGTH);
}


////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
///  PROCESS SERIAL COMMANDS HERE //////////////////////////////////
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////

// RESET TO DEFAULT ALSO USED AFTER FIRST LOAD TO SORT OUT EPROM
if(V_COMMAND == "RESET_TO_DEFAULT")
{
SET_EPROM_DEFAULTS();
// Code is in MyDew.h
P_OUTPUT_DEW_STATUS ();
// Code is in MyFocus.h
P_OUTPUT_FOCUSER_STATUS ();
}

if(V_COMMAND == "GET_DEVICE_NAME")
{
  Serial.println ("DEVICE_NAME|" + V_DEVICE_NAME );
}

////////////////////////////////////////////////////////////////////
///////////////////////////TEMP//////////////////////////////////
////////////////////////////////////////////////////////////////////

if(V_COMMAND == "GET_TEMP")
{
  P_READ_SENSOR ();
}

if(V_COMMAND == "GET_TEMP_OFFSET")
{
  P_OUTPUT_TEMP_OFFSET ();
}

if(V_COMMAND == "SET_TEMP_OFFSET")
{
 P_SAVE_TEMP_OFFSET ();
}

////////////////////////////////////////////////////////////////////
///////////////////////////DEW//////////////////////////////////////
////////////////////////////////////////////////////////////////////

// IF THE FIRST LETTER IS A "D" THEN THIS IS COMMAND IS FOR DEW CONTROLLERS

if(V_FIRST_CHAR=="D")
{
  // Code is in MyDew.h
  P_PROCESS_DEW_COMMUNICATION();
}


////////////////////////////////////////////////////////////////////
///////////////////////////FOCUSER//////////////////////////////////
////////////////////////////////////////////////////////////////////

if(V_FIRST_CHAR=="F")
{
  // Code is in MyFocus.h
  P_PROCESS_FOCUS_COMMUNICATION();
}

//////////////////////////////////////////////////////////////////
// IF WE GOT HERE THEN MESSAGE WAS GARBAGE ///////////////////////
//////////////////////////////////////////////////////////////////

}   

//////////////////////////////////////////////////////////////
////////// PROCESS SERIAL DATA ///////////////////////////////
//////////////////////////////////////////////////////////////
void P_PROCESS_SERIAL_PORT ()
{

  V_SERIAL_LINE_FEED_RECEIVED = false;

  V_SERIAL_CHAR = "";
  
  // CHECK IF DATA IN SERIAL
  if(Serial.available() > 0) 
  {
   // READ SERIAL DATA INTO CHAR
   V_SERIAL_CHAR = Serial.read();
   
   //ADD VAR ONTO END OF STRING OF ALREADY RECEIVED CHARS
   V_SERIAL_TEXT += V_SERIAL_CHAR;  

   //CHECK TO SEE IF WE GOT LINE FEED
   if (V_SERIAL_CHAR == '\n')
   {
     V_SERIAL_LINE_FEED_RECEIVED = true;
   }

  ///////////////////////////////////////
  //
  // If we have full command process it
  //
  //////////////////////////////////////

 // WE ONLY PROCESS SERIAL DATA IF WE HAVE RECEIVED A LINE FEED
 if (V_SERIAL_LINE_FEED_RECEIVED) 
 {
   // DO PROCESSING
   // Code in MySerial.h
   // Special case for when focuser is moving.
   if (V_IS_MOVING)
   {
     // if the focuser is moving we will ignore every command except for halt //
     if (V_SERIAL_TEXT.charAt(0) == 'H')
     {
       V_IS_MOVING = false;
       V_STEPS_TO_MAKE = 0;
       SAVE_EPROM_FOCUSER();
       P_OUTPUT_FOCUSER_STATUS ();
     }
   }
   else
   {
   P_PROCESS_COMMUNICATION();
   }
   // CLEAR SERIAL TEXT AS WE HAVE PROCESSED COMMAND
   V_SERIAL_TEXT = "";
 }  
}
}
