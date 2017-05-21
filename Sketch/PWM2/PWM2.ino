const int pinTemp=A0;
const int fanTacho=4;
const int fanPwm=10;
int del=300;

float temp(int val, int val0, float temp0, int val1, float temp1)
{
  return (((temp1-temp0)*(val-val0))/(val1-val0))+temp0;
}

void setup()
{
  Serial.begin(9600);

  pinMode(fanTacho,INPUT);
  pinMode(fanPwm,OUTPUT);
  pinMode(pinTemp,INPUT);
  pinMode(4,INPUT);

  
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

float TachoRead()
{
  long Tk=0;
  boolean LastHIGH=true;
  unsigned long LastMillis=millis();
  while((millis()-LastMillis)<1000)//300 milisegundos
  {
    //if(pulseIn(fanTacho,HIGH,50)>0)
    if(digitalRead(fanTacho)==HIGH)
    {
      if(LastHIGH==false)
      {
        LastHIGH=true;
        Tk++;
      }
    }
    else
    {
      LastHIGH=false;
    }
  }
  int DeltaMillis=(millis()-LastMillis);
  //Serial.print(Tk);
  //Serial.print(";");
  //Serial.println(DeltaMillis);
  return (30000.0*Tk)/(DeltaMillis);
}

void loop()
{
  int sensorValTemp=analogRead(pinTemp);
  int sensorValPot=analogRead(A1);
  analogWrite(fanPwm,sensorValPot/4);
  
  //Serial.print("Potenciometro = ");
  //Serial.println(sensorValPot);
  
  //Serial.print("PWM analogWrite = ");
  //Serial.println(sensorValPot/4);
  
  //Serial.print("Temperatura = ");
  float grados=temp(sensorValTemp,275,0,480,22.2);
  //Serial.println(grados);
  
  Serial.print("1_");
  Serial.print(grados);
  Serial.print("_");
  Serial.print(TachoRead());
  Serial.print("_");
  Serial.println(((sensorValPot/4)/255.0)*100);
  /*Serial.print(millis());
  Serial.print(";");
  Serial.println(digitalRead(fanTacho));*/
  delay(del);
}
