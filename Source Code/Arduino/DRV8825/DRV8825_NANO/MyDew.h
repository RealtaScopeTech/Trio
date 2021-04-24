///////////////////////////////////////////////////////
////////////////////// DEW PIN CONTROL ////////////////
///////////////////////////////////////////////////////

void P_SET_PWM_PINS()
{
  if(!V_DEW_LOCKED)
  {
    analogWrite(DEW_0_PIN, A_MY_DEW_POWER[0]);
    analogWrite(DEW_1_PIN, A_MY_DEW_POWER[1]); 
    analogWrite(DEW_2_PIN, A_MY_DEW_POWER[2]);  
  }
}  

void P_SET_DEW_ZERO ()
{
A_MY_DEW_POWER[0] = 0;
A_MY_DEW_POWER[1] = 0; 
A_MY_DEW_POWER[2] = 0;
}

void P_LOCK_DEW ()
{  
V_DEW_LOCKED = true;
analogWrite(DEW_0_PIN, 0);
analogWrite(DEW_1_PIN, 0); 
analogWrite(DEW_2_PIN, 0);  
}

void P_UNLOCK_DEW ()
{  
V_DEW_LOCKED = false;
}

void P_OUTPUT_DEW_STATUS ()
{
  
   V_SERIAL_OUT ="";

   V_SERIAL_OUT = "DEW_STATUSES";
   // ADD LOCKED STATUS
   V_SERIAL_OUT = V_SERIAL_OUT +"|" + V_DEW_LOCKED;
   // ADD EACH DEW CONTROLLERS POWER
   for (int i = 0; i < 3; i++) 
   {
     V_SERIAL_OUT = V_SERIAL_OUT + "|" + i + "," + A_MY_DEW_POWER[i];
   }
   
   Serial.println(V_SERIAL_OUT);

}


void P_OUTPUT_SAVED_DEW_STATUS ()
{

   // READ EPROM DATA INTO TEMP AREA //
   READ_EPROM_DEW_TEMP ();
   V_SERIAL_OUT = "DEW_SAVED_STATUSES";
   // ADD LOCKED STATUS
   V_SERIAL_OUT = V_SERIAL_OUT +"|" + V_DEW_LOCKED;
   // ADD EACH DEW CONTROLLERS POWER FROM TEMP AREA
   for (int i = 0; i < 3; i++) 
   {
     V_SERIAL_OUT = V_SERIAL_OUT + "|" + i + "," + A_MY_DEW_POWER_TEMP[i];
   }
   Serial.println(V_SERIAL_OUT);
}

void P_DEW_POWER_SET ()
{
   // We expect this request to have paramaters
   if(!V_HAS_PARAMS) 
   {
   Serial.println ("ERROR|NO PARAMATERS");
   }

   // if it does have some we will dig em out
   if(V_HAS_PARAMS)
   {
   //is comma delimited
   V_DEW_C      = F_GET_VALUE(V_PARAMS.substring(1),',',0);
   V_DEW_P      = F_GET_VALUE(V_PARAMS.substring(1),',',1);
   V_DEW_CONTROLLER   = V_DEW_C.toInt();
   V_DEW_POWER        = V_DEW_P.toInt();
   //SET THE ACTUAL POWER
   A_MY_DEW_POWER[V_DEW_CONTROLLER] = V_DEW_POWER;
   //SET THE PINS
   P_SET_PWM_PINS;
   }

}



/////////////////////////////////////////////////////////////////////
////////////////////// PROCESS INCOMING DEW COMMANDS ////////////////
/////////////////////////////////////////////////////////////////////

// DEW CONTROL

// SERIAL STRING "DEW_GET_STATUSES": GET_ALL_DEW_STATES returns dew id, dew power for all dew controllers
// RETURN SHOULD LOOK LIKE "GET_DEW_STATUSES|0,200|1,0|2,100"
// DEW CONTROLLER 0 is at power 200

// SERIAL STRING 'DEW_SET_POWER': SET_DEW_STATE pass DEW id(0 to 2) and dew state (0 or 1) and dew power (0 to 255), returns dew state, dew power for specific dew controller
// INCOMING DATA DATA SHOULD LOOK LIKE SET_DEW_STATE|0,1,200|

// SERIAL STRING 'DEW_GET_SAVED_STATUS' Get saved status of Dew controllers from EPROM

// SERIAL STRING 'DEW_SAVE_STATUS' Save current values to EPROM

// SERIAL STRING 'DEW_LOCK_CONTROLLERS' sets DEW controllers to zero and stops them being turned on

// SERIAL STRING 'DEW_UNLOCK_CONTROLLERS' allows DEW contollers to be turned on

void P_PROCESS_DEW_COMMUNICATION()
{
  
String V_SERIAL_OUT ="";

if(V_COMMAND == "DEW_GET_STATUSES")
{
   P_OUTPUT_DEW_STATUS ();
}

if(V_COMMAND == "DEW_SET_POWER")
{
   P_DEW_POWER_SET ();
   P_OUTPUT_DEW_STATUS ();
}

if(V_COMMAND == "DEW_SAVE_STATUS")
{
  SAVE_EPROM_DEW();
  P_OUTPUT_DEW_STATUS;
}

if(V_COMMAND == "DEW_LOCK_CONTROLLERS")
{
  P_LOCK_DEW ();
  P_OUTPUT_DEW_STATUS ();
}

if(V_COMMAND == "DEW_UNLOCK_CONTROLLERS")
{
  P_UNLOCK_DEW ();
  P_OUTPUT_DEW_STATUS ();
}

// Asked to get dew controller saved statuses
if(V_COMMAND == "DEW_GET_SAVED_STATUS")
{
   P_OUTPUT_SAVED_DEW_STATUS ();
}

}
