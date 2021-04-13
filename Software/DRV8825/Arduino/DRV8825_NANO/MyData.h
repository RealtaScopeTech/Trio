/////////////////////////////////////////////////////////////
///////// VARS FOR TEMP SENSOR                         //////
/////////////////////////////////////////////////////////////

bool V_SENSOR_CONNECTED;

Adafruit_AHTX0 aht;
sensors_event_t humidity, temp;
int V_TEMP_OFFSET;


// DATA 
String V_DEVICE_NAME = "Realta: Focuser Three";
String V_VERSION_NUMBER = "1.0";

// PIN DEF
byte DEW_0_PIN = 9;       //PWM PULSES
byte DEW_1_PIN = 10;      //PWM PULSES
byte DEW_2_PIN = 11;      //PWM PULSES
byte STEP_DIR_PIN = 15;    //SETS DIRECTION
byte STEP_STEP_PIN = 8;   //TELLS MOTOR TO MOVE
byte STEP_ENABLE_PIN = 6; //ENABLES POWER TO MOTOR
byte STEP_M3_PIN = 3;     //FOR SETTING STEP SIZE
byte STEP_M2_PIN = 4;     //FOR SETTING STEP SIZE
byte STEP_M1_PIN = 5;     //FOR SETTING STEP SIZE

/////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////
//////////// SET OUTPUTS ////////////////////////////////////

void P_SET_OUTPUT_PINS()
{
  pinMode(DEW_0_PIN, OUTPUT);       //PWM PULSES
  pinMode(DEW_1_PIN, OUTPUT);       //PWM PULSES
  pinMode(DEW_2_PIN, OUTPUT);       //PWM PULSES
  pinMode(STEP_DIR_PIN, OUTPUT);    //SETS DIRECTION
  pinMode(STEP_STEP_PIN, OUTPUT);   //TELLS MOTOR TO MOVE
  pinMode(STEP_ENABLE_PIN, OUTPUT); //ENABLES POWER TO MOTOR
  pinMode(STEP_M3_PIN, OUTPUT);     //FOR SETTING STEP SIZE
  pinMode(STEP_M2_PIN, OUTPUT);     //FOR SETTING STEP SIZE
  pinMode(STEP_M1_PIN, OUTPUT);     //FOR SETTING STEP SIZE
}


// FOCUSER STUFF //
bool V_IS_MOVING;


//holds focuser status
struct FOCUSER_STATUS {
  int  V_CURRENT_POSITION;
  byte V_STEP_MODE;
  int  V_MAX_STEPS;
  byte V_POWER_HOLD;
  byte V_DIRECTTION;
  byte V_STEPPER_SPEED;
  byte V_STEPPER_WAIT;
};

FOCUSER_STATUS S_MY_FOCUSER_STATUS;

FOCUSER_STATUS S_TEMP_FOCUSER_STATUS;

// STEPPING MODES
typedef struct STEPPER_PIN_STATES {
  byte M1_STATE;
  byte M2_STATE;
  byte M3_STATE;
} PIN_STATES;

PIN_STATES STEPPING_MODE [6];


void P_SET_STEPPING_MODES()
{
/////////////////////////////////////////////////////////////////////////////////////////////// M1   M2   M3  Microstep resolution
STEPPING_MODE[0].M1_STATE = 0; STEPPING_MODE[0].M2_STATE = 0; STEPPING_MODE[0].M3_STATE = 0; // Low  Low  Low Full step
STEPPING_MODE[1].M1_STATE = 1; STEPPING_MODE[1].M2_STATE = 0; STEPPING_MODE[1].M3_STATE = 0; // High Low  Low 1/2 step
STEPPING_MODE[2].M1_STATE = 0; STEPPING_MODE[2].M2_STATE = 1; STEPPING_MODE[2].M3_STATE = 0; // Low  High Low 1/4 step
STEPPING_MODE[3].M1_STATE = 1; STEPPING_MODE[3].M2_STATE = 1; STEPPING_MODE[3].M3_STATE = 0; // High High Low 1/8 step
STEPPING_MODE[4].M1_STATE = 0; STEPPING_MODE[4].M2_STATE = 0; STEPPING_MODE[4].M3_STATE = 1; // Low  Low  High  1/16 step
STEPPING_MODE[5].M1_STATE = 1; STEPPING_MODE[5].M2_STATE = 0; STEPPING_MODE[5].M3_STATE = 1; // High Low  High  1/32 step
}

bool   V_PARAM_ERROR;
String V_PARAM_ERROR_TEXT;

String V_CHAR_STEPS_TO_MAKE;
int    V_STEPS_TO_MAKE_TEMP;
int    V_NEW_CURRENT_POSITION;
int    V_CORRECTED_POSITION;
int    V_STEPS_TO_MAKE;

/////////////////////////////////////////////
/////////// DEW CONTROL /////////////////////
/////////////////////////////////////////////

bool V_DEW_LOCKED;

byte A_MY_DEW_POWER[3];

byte A_MY_DEW_POWER_TEMP[3];

String V_DEW_C;
String V_DEW_P;
int V_DEW_CONTROLLER;
int V_DEW_POWER;

   
//SERIAL COMMUNICATION
String V_SERIAL_TEXT;

String V_SERIAL_OUT;

bool V_SERIAL_LINE_FEED_RECEIVED;

char V_SERIAL_CHAR;

bool V_END_COMMAND_FOUND;

String V_COMMAND;
String V_PARAMS;
bool   V_HAS_PARAMS;
int    V_PARAMS_START_AT;
int    V_INCOMING_STRING_LENGTH;
String V_FIRST_CHAR;


/////////////////////////////////////////////////////////////
///////// GETVALUE SPLITS A STRING UP BY A SINGLE CHAR //////
/////////////////////////////////////////////////////////////


String F_GET_VALUE(String V_DATA, char V_SEPARATOR, int V_INDEX)
{
    int V_FOUND = 0;
    int V_STRING_INDEX[] = { 0, -1 };
    int V_MAX_INDEX = V_DATA.length() - 1;

    for (int i = 0; i <= V_MAX_INDEX && V_FOUND <= V_INDEX; i++) {
        if (V_DATA.charAt(i) == V_SEPARATOR || i == V_MAX_INDEX) {
            V_FOUND++;
            V_STRING_INDEX[0] = V_STRING_INDEX[1] + 1;
            V_STRING_INDEX[1] = (i == V_MAX_INDEX) ? i+1 : i;
        }
    }
    return V_FOUND > V_INDEX ? V_DATA.substring(V_STRING_INDEX[0], V_STRING_INDEX[1]) : "";
}
