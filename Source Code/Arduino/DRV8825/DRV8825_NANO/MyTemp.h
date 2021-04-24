


void P_CHECK_SENSOR_EXISTS()
{

V_SENSOR_CONNECTED = true;
  
if (! aht.begin()) 
  {
     V_SENSOR_CONNECTED = false;
  }  
}

void P_READ_SENSOR ()
{

  // If we have a sensor then read it //
  if (V_SENSOR_CONNECTED)
  {
  // Tell sensor to measure somefink
  sensors_event_t humidity, temp;
  aht.getEvent(&humidity, &temp);
  // Stuff result into serial output
  Serial.print("AHT20|");Serial.print(temp.temperature + V_TEMP_OFFSET);Serial.print(",");Serial.println(humidity.relative_humidity);
  }

  // If not just do dummy
  if (!V_SENSOR_CONNECTED)
  {
  // Stuff result into serial output
  Serial.print("AHT20|");Serial.print("21");Serial.print(",");Serial.println("40");
  }

}

void P_OUTPUT_TEMP_OFFSET ()
{
   READ_EPROM_TEMP_OFFSET();
   V_SERIAL_OUT = "TEMP_OFFSET";
   // ADD TEMP OFFSET
   V_SERIAL_OUT = V_SERIAL_OUT +"|" + V_TEMP_OFFSET;
   Serial.println(V_SERIAL_OUT);
}

void P_SAVE_TEMP_OFFSET  ()
{
   //We expect this request to have paramaters
   if(!V_HAS_PARAMS) 
   {
   Serial.println ("ERROR|NO PARAMATERS");
   }

     // if it does have some we will dig em out
     if(V_HAS_PARAMS)
     {
     //is comma delimited
     V_TEMP_OFFSET = V_PARAMS.substring(1).toInt();
     SAVE_EPROM_TEMP_OFFSET();
     P_OUTPUT_TEMP_OFFSET();
     }
}
  
