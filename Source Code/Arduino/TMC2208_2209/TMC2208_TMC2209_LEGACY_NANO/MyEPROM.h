//////////////////////////////////////////////////////////////////////////
/////////////////////// EPROM UTILS FROM ARDUINO WEBSITE /////////////////
//////////////////////////////////////////////////////////////////////////

template <class T> int EEPROM_writeAnything(int ee, const T& value)
{
    const byte* p = (const byte*)(const void*)&value;
    unsigned int i;
    for (i = 0; i < sizeof(value); i++)
          EEPROM.write(ee++, *p++);
    return i;
}

template <class T> int EEPROM_readAnything(int ee, T& value)
{
    byte* p = (byte*)(void*)&value;
    unsigned int i;
    for (i = 0; i < sizeof(value); i++)
          *p++ = EEPROM.read(ee++);
    return i;
}

/////////////////////////////////////////////////////////
/////////////////// EPROM UTILS  ////////////////////////
/////////////////////////////////////////////////////////

void SET_EPROM_DEFAULTS ()
{
byte V_DONE_IT = 0;
// Do dew status first
byte V_POWER = 0; //Off
// We have 3 DEW controllers 
A_MY_DEW_POWER[0] = V_POWER;
A_MY_DEW_POWER[1] = V_POWER;
A_MY_DEW_POWER[2] = V_POWER;
V_TEMP_OFFSET = 0;


EEPROM_writeAnything(255, A_MY_DEW_POWER);

EEPROM_writeAnything(144, V_TEMP_OFFSET);

// Do focuser status second
S_MY_FOCUSER_STATUS.V_CURRENT_POSITION = 5000;
S_MY_FOCUSER_STATUS.V_STEP_MODE        = 0;
S_MY_FOCUSER_STATUS.V_MAX_STEPS        = 10000;
S_MY_FOCUSER_STATUS.V_POWER_HOLD       = 1;
S_MY_FOCUSER_STATUS.V_DIRECTTION       = 1;
S_MY_FOCUSER_STATUS.V_STEPPER_SPEED    = 1;
S_MY_FOCUSER_STATUS.V_STEPPER_WAIT     = 2;
EEPROM_writeAnything(1, S_MY_FOCUSER_STATUS);
V_DONE_IT = 66;
EEPROM_writeAnything(0, V_DONE_IT);
}

void READ_EPROM_DEW ()
{
 EEPROM_readAnything(255, A_MY_DEW_POWER);
}

void READ_EPROM_DEW_TEMP ()
{
 EEPROM_readAnything(255, A_MY_DEW_POWER_TEMP);
}

void SAVE_EPROM_DEW()
{
  EEPROM_writeAnything(255, A_MY_DEW_POWER);  
}

void READ_EPROM_FOCUSER ()
{
 EEPROM_readAnything(1, S_MY_FOCUSER_STATUS); 
}

void READ_EPROM_FOCUSER_TEMP ()
{
 EEPROM_readAnything(1, S_TEMP_FOCUSER_STATUS); 
}


void SAVE_EPROM_FOCUSER()
{
  EEPROM_writeAnything(1, S_MY_FOCUSER_STATUS);  
}

void READ_EPROM_TEMP_OFFSET()
{
 EEPROM_readAnything(144, V_TEMP_OFFSET); 
}

void SAVE_EPROM_TEMP_OFFSET()
{
 EEPROM_writeAnything(144, V_TEMP_OFFSET);
}
