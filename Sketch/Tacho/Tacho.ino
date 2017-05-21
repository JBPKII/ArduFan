int fanTacho=7;// o 4
const int fanPwm=10;
int del=300;
int RPMs=0;
float temp(int val, int val0, float temp0, int val1, float temp1)
{
  return (((temp1-temp0)*(val-val0))/(val1-val0))+temp0;
}

void addRpm()
{
  RPMs++;
}

void setup()
{
  Serial.begin(9600);

  pinMode(4,OUTPUT);
  pinMode(7,OUTPUT);
  pinMode(fanPwm,OUTPUT);
  
  digitalWrite(4,LOW);
  digitalWrite(7,LOW);
  
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

int TachoRead()
{
  RPMs=0;
  int msTest=500;
  attachInterrupt(0,addRpm,LOW);
  delay(msTest);
  detachInterrupt(0);
  return ((float)30000*(float)RPMs)/((float)msTest);
}

void loop()
{
  digitalWrite(fanTacho,LOW);
  if(fanTacho==4)
  {
    fanTacho=7;
  }
  else
  {
    fanTacho=4;
  }
  digitalWrite(fanTacho,HIGH);
  
  int sensorValPot=analogRead(A1);
  analogWrite(fanPwm,sensorValPot/4);
  
  //Serial.print("Potenciometro = ");
  //Serial.println(sensorValPot);
  
  //Serial.print("PWM analogWrite = ");
  //Serial.println(sensorValPot/4);
  
  //Serial.print("Temperatura = ");

  //Serial.println(grados);
  
  Serial.print(fanTacho);
  Serial.print("_");
  Serial.print(-1);
  Serial.print("_");
  Serial.print(TachoRead());
  Serial.print("_");
  Serial.println(((sensorValPot/4)/255.0)*100);
  /*Serial.print(millis());
  Serial.print(";");
  Serial.println(digitalRead(fanTacho));*/
  delay(del);
}
