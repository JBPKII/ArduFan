const int fanTacho1=2;
const int fanTacho2=4;
const int fanPwm=10;
int del=300;
int RPMs=0;
float temp(int val, int val0, float temp0, int val1, float temp1)
{
  return (((temp1-temp0)*(val-val0))/(val1-val0))+temp0;
}

void setup()
{
  Serial.begin(9600);

  pinMode(fanTacho1,INPUT);
  pinMode(fanTacho2,INPUT);
  pinMode(fanPwm,OUTPUT);
  
    //Modificar frecuencia PWM
    //Setting Divisor Frequency
    //0x01 1 31250
    //0x02 8 3906.25
    //0x03 64 488.28125
    //0x04 256 122.0703125
    //0x05 1024 30.517578125
    //TCCR1B = TCCR1B & 0b11111000 | <setting>;
    //Configuro el PWM a 30 kHz.
    TCCR1B=TCCR1B & 0b11111000 | 0x01;
}

int TachoRead(int fan)
{
  int TestMs=300;
  RPMs=0;
  boolean LastH=true;
  unsigned long millisInic=millis();
  while (millis()-millisInic<TestMs)
  {
    if(digitalRead(fan)==HIGH)
    {
      if(!LastH)
      {
        RPMs++;
        LastH=true;
      }
    }
    else
    {
     LastH=false;
    }
  }
  /*Serial.print(RPMs);
  Serial.print(" ");
  Serial.print(millis()-millisInic);
  Serial.print(" ");*/
  return ((float)30000*(float)RPMs)/((float)TestMs);
}

void loop()
{
  Serial.print("F1: ");
  Serial.println(TachoRead(fanTacho1));
  
  Serial.print("F2: ");
  Serial.println(TachoRead(fanTacho2));
  
  int sensorValPot=analogRead(A1);
  analogWrite(fanPwm,sensorValPot/4);
}
