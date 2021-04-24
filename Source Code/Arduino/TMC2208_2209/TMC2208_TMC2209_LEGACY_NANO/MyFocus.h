/*
byte DEW_0_PIN = 9;       //PWM PULSES
byte DEW_1_PIN = 10;      //PWM PULSES
byte DEW_2_PIN = 11;      //PWM PULSES
byte STEP_DIR_PIN = 3;    //SETS DIRECTION
byte STEP_STEP_PIN = 4;   //TELLS MOTOR TO MOVE
byte STEP_ENABLE_PIN = 8; //ENABLES POWER TO MOTOR
byte STEP_M3_PIN = 7;     //FOR SETTING STEP SIZE
byte STEP_M2_PIN = 6;     //FOR SETTING STEP SIZE
byte STEP_M1_PIN = 5;     //FOR SETTING STEP SIZE

struct FOCUSER_STATUS {
  int  V_CURRENT_POSITION;
  byte V_STEP_MODE;
  int  V_MAX_STEPS;
  byte V_POWER_HOLD;
  byte V_DIRECTTION;
  byte V_STEPPER_SPEED;
};

*/

// STEPPER CONTROL

void P_UPDATE_STEPPER_PINS()
{
digitalWrite(STEP_DIR_PIN, S_MY_FOCUSER_STATUS.V_DIRECTTION);
digitalWrite(STEP_ENABLE_PIN, S_MY_FOCUSER_STATUS.V_POWER_HOLD);
digitalWrite(STEP_M1_PIN, STEPPING_MODE[S_MY_FOCUSER_STATUS.V_STEP_MODE].M1_STATE );
digitalWrite(STEP_M2_PIN, STEPPING_MODE[S_MY_FOCUSER_STATUS.V_STEP_MODE].M2_STATE );
}

// SERIAL LETTER 'FOCUSER_GET_STATUS': GET_FOCUSER_STATUS
//  returns
//  V_CURRENT_POSITION, V_STEP_MODE, V_MAX_STEPS, V_POWER_HOLD, V_DIRECTTION, V_STEPPER_SPEED;
//  return should look like GET_STEPPER_STATUS|5000, 1, 10000, 0, 0, 1

// SERIAL LETTER 'D': SET_STEPPER_STATUS
// sends new V_CURRENT_POSITION, V_STEP_MODE, V_MAX_STEPS, V_POWER_HOLD, V_DIRECTTION, V_STEPPER_SPEED;

// SERIAL 'FOCUSER_MOVE': MOVE_NUMBER_OF_STEPS
void P_OUTPUT_FOCUSER_STATUS ()
{
  V_SERIAL_OUT ="";

   V_SERIAL_OUT = "FOCUSER_STATUS";
   V_SERIAL_OUT = V_SERIAL_OUT + "|";
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_CURRENT_POSITION + "," ; 
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_STEP_MODE + ","; 
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_MAX_STEPS + "," ;
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_POWER_HOLD + "," ;
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_DIRECTTION + "," ;
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_STEPPER_SPEED + ",";
   V_SERIAL_OUT = V_SERIAL_OUT + S_MY_FOCUSER_STATUS.V_STEPPER_WAIT;
   Serial.println(V_SERIAL_OUT);
   
};  

void P_STEP ()
{
    if(V_STEPS_TO_MAKE != 0)
    {
    // We will update stepper pins to users last settings
    P_UPDATE_STEPPER_PINS();

    // We will ignore enable flag because we do actually want to move
    digitalWrite(STEP_ENABLE_PIN, LOW);

   // Reverse direction if negative steps
    if (V_STEPS_TO_MAKE < 0)
    {
    if(S_MY_FOCUSER_STATUS.V_DIRECTTION == 1)
      {
        digitalWrite(STEP_DIR_PIN, 0);
      }
      else
      {
        digitalWrite(STEP_DIR_PIN, 1);
      }
    }
    
    delay(S_MY_FOCUSER_STATUS.V_STEPPER_SPEED); // Wait per user speed delay
    // Focuser moves only when stop pin changes from high to low
    digitalWrite(STEP_STEP_PIN, LOW);
    digitalWrite(STEP_STEP_PIN, HIGH) ;
      
    // Wait for it   
    delay(S_MY_FOCUSER_STATUS.V_STEPPER_WAIT);  

    if (V_STEPS_TO_MAKE < 0)
    {
    S_MY_FOCUSER_STATUS.V_CURRENT_POSITION = S_MY_FOCUSER_STATUS.V_CURRENT_POSITION - 1;
    V_STEPS_TO_MAKE =  V_STEPS_TO_MAKE + 1;
    }
    else
    {
    S_MY_FOCUSER_STATUS.V_CURRENT_POSITION = S_MY_FOCUSER_STATUS.V_CURRENT_POSITION + 1;
    V_STEPS_TO_MAKE =  V_STEPS_TO_MAKE - 1;   
    }
    }

    // Output progress
    if (V_STEPS_TO_MAKE % 100 == 0)
    {
    Serial.print("MOVING|"); Serial.println(V_STEPS_TO_MAKE);
    }


    if (V_STEPS_TO_MAKE==0)
    {
    V_IS_MOVING = false;
    SAVE_EPROM_FOCUSER();
    P_OUTPUT_FOCUSER_STATUS ();
    }
    
    // We will update stepper pins back to user settings 
    P_UPDATE_STEPPER_PINS();
    
}


void P_MOVE_FOCUSER ()
{
   // We expect parameter containing number of steps
   // throw error back if we don't have any
   if(!V_HAS_PARAMS) 
   {
      Serial.println ("ERROR|NO PARAMATERS");
   } 
   if(V_HAS_PARAMS) 
   {
    // Dig out number of steps to make from parameter list, should only be one entry
    V_CHAR_STEPS_TO_MAKE = V_PARAMS.substring(1);
    V_STEPS_TO_MAKE_TEMP = V_CHAR_STEPS_TO_MAKE.toInt();


    // Added check to make sure don't move past 0 and S_MY_FOCUSER_STATUS.V_MAX_STEPS
    V_NEW_CURRENT_POSITION = S_MY_FOCUSER_STATUS.V_CURRENT_POSITION + V_STEPS_TO_MAKE_TEMP;

    V_CORRECTED_POSITION =  max(min(V_NEW_CURRENT_POSITION, S_MY_FOCUSER_STATUS.V_MAX_STEPS),0);
     
    V_STEPS_TO_MAKE   = V_CORRECTED_POSITION - S_MY_FOCUSER_STATUS.V_CURRENT_POSITION;
    
    if (V_STEPS_TO_MAKE != 0)
    {
     V_IS_MOVING = true;
    }

    if (V_STEPS_TO_MAKE == 0)
    {
     V_IS_MOVING = false;
     P_OUTPUT_FOCUSER_STATUS ();
    }
  } 
}

void P_FOCUSER_SET_PARAM ()
{
   // Expecting a ton of values
   if(!V_HAS_PARAMS) 
   {
   Serial.println ("ERROR|NO PARAMATERS");
   }

   // if it does have some we will dig em out
   if(V_HAS_PARAMS)
   {
    
    S_TEMP_FOCUSER_STATUS.V_CURRENT_POSITION = F_GET_VALUE(V_PARAMS.substring(1),',',0).toInt(); 
    S_TEMP_FOCUSER_STATUS.V_STEP_MODE        = F_GET_VALUE(V_PARAMS.substring(1),',',1).toInt(); 
    S_TEMP_FOCUSER_STATUS.V_MAX_STEPS        = F_GET_VALUE(V_PARAMS.substring(1),',',2).toInt();
    S_TEMP_FOCUSER_STATUS.V_POWER_HOLD       = F_GET_VALUE(V_PARAMS.substring(1),',',3).toInt();
    S_TEMP_FOCUSER_STATUS.V_DIRECTTION       = F_GET_VALUE(V_PARAMS.substring(1),',',4).toInt();
    S_TEMP_FOCUSER_STATUS.V_STEPPER_SPEED    = F_GET_VALUE(V_PARAMS.substring(1),',',5).toInt();
    S_TEMP_FOCUSER_STATUS.V_STEPPER_WAIT     = F_GET_VALUE(V_PARAMS.substring(1),',',6).toInt();




    // Check each value is in range.
    // Don't rely on front end
    V_PARAM_ERROR_TEXT = "";
    V_PARAM_ERROR = false;
    
    if (S_TEMP_FOCUSER_STATUS.V_CURRENT_POSITION < 0) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|CURRENT_POSTION_LESS_THAN_ZERO";
        V_PARAM_ERROR = true;
    }

    if (S_TEMP_FOCUSER_STATUS.V_CURRENT_POSITION > S_TEMP_FOCUSER_STATUS.V_MAX_STEPS) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|CURRENT_POSTION_GREATER_THAN_MAX";
        V_PARAM_ERROR = true;
    }

    if (S_TEMP_FOCUSER_STATUS.V_STEP_MODE < 0 || S_TEMP_FOCUSER_STATUS.V_STEP_MODE > 5 ) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|STEP_MODE_OUT_OF_RANGE";
        V_PARAM_ERROR = true;
    }
    
    if (S_TEMP_FOCUSER_STATUS.V_MAX_STEPS < 0) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|MAX_STEPS_LESS_THAN_ZERO";
        V_PARAM_ERROR = true;
    }

    if (S_TEMP_FOCUSER_STATUS.V_POWER_HOLD < 0 || S_TEMP_FOCUSER_STATUS.V_POWER_HOLD > 1 ) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|POWER_HOLD_OUT_OF_RANGE";
        V_PARAM_ERROR = true;
    }

    if (S_TEMP_FOCUSER_STATUS.V_DIRECTTION < 0 || S_TEMP_FOCUSER_STATUS.V_DIRECTTION > 1) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|DIRECTION_OUT_OF_RANGE";
        V_PARAM_ERROR = true;
    }
    
    if (S_TEMP_FOCUSER_STATUS.V_STEPPER_SPEED < 0) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|STEPPER_SPEED_LESS_THAN_ZERO";
        V_PARAM_ERROR = true;
    }

    if (S_TEMP_FOCUSER_STATUS.V_STEPPER_WAIT < 0) {
        V_PARAM_ERROR_TEXT = V_PARAM_ERROR_TEXT + "|STEPPER_WAIT_LESS_THAN_ZERO";
        V_PARAM_ERROR = true;
    }

    if(V_PARAM_ERROR)
    {
      Serial.println ("ERROR" + V_PARAM_ERROR_TEXT);
    }
    
    if(!V_PARAM_ERROR)
    {
    S_MY_FOCUSER_STATUS = S_TEMP_FOCUSER_STATUS;
    P_OUTPUT_FOCUSER_STATUS;
    }
    
   }
  
}


void P_OUTPUT_SAVED_FOCUSER_STATUS ()
{

   // READ EPROM DATA INTO TEMP AREA //
   READ_EPROM_FOCUSER_TEMP ();
   V_SERIAL_OUT = "FOCUSER_SAVED_STATUS";
   V_SERIAL_OUT = V_SERIAL_OUT + "|";
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_CURRENT_POSITION + "," ; 
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_STEP_MODE + ","; 
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_MAX_STEPS + "," ;
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_POWER_HOLD + "," ;
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_DIRECTTION + "," ;
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_STEPPER_SPEED + ",";
   V_SERIAL_OUT = V_SERIAL_OUT + S_TEMP_FOCUSER_STATUS.V_STEPPER_WAIT;
   Serial.println(V_SERIAL_OUT);
}

void P_PROCESS_FOCUS_COMMUNICATION()
{

  V_SERIAL_OUT ="";

  if(V_COMMAND == "FOCUSER_GET_STATUS")
  {
   P_OUTPUT_FOCUSER_STATUS ();
  }

  if(V_COMMAND == "FOCUSER_MOVE")
  {
    P_MOVE_FOCUSER ();
    //P_OUTPUT_FOCUSER_STATUS ();
   }

  if(V_COMMAND == "FOCUSER_SET_PARAM")
  {
    P_FOCUSER_SET_PARAM ();
    P_OUTPUT_FOCUSER_STATUS ();
  }

  if(V_COMMAND == "FOCUSER_SAVE_STATE")
  {
    SAVE_EPROM_FOCUSER();
    P_OUTPUT_FOCUSER_STATUS ();
  }

  // Asked to get focuser saved statuses
  if(V_COMMAND == "FOCUSER_GET_SAVED_STATUS")
  {
   P_OUTPUT_SAVED_FOCUSER_STATUS ();
  }


}
