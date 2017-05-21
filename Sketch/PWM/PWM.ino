#include <LiquidCrystal.h>
LiquidCrystal lcd(13,12,8,7,4,2);

const int tempPin=A0;
int tMax=-100;
int tMin=100;

const int fanPWM=5;
const int fanTacho=5;
int rpmCount=0;
unsigned lastMillis=0;

float temp(int val, int val0, float temp0, int val1, float temp1)
{
  return (((temp1-temp0)*(val-val0))/(val1-val0))+temp0;
}

void setup()
{
  Serial.begin(9600);
  lcd.begin(16,2);
  pinMode(fanTacho,INPUT);
  lcd.clear();
  pinMode(fanPWM, OUTPUT);
  
  //attachInterrupt(1, addRPM, RISING);
}

void addRPM()
{
  ++rpmCount;
}

int rpms()
{
  //Serial.print("rpmCount: ");
  //Serial.println(rpmCount);
  //Serial.print("millis(): ");
  //Serial.println(millis());
  int rpmS=(rpmCount*30000.0)/(millis()-lastMillis);
  //Serial.println("millis()-lastMillis: ");
  //Serial.println(millis()-lastMillis);
  //Serial.println("rpmS: ");
  //Serial.println(rpmS);
  lastMillis=millis();
  rpmCount=0;
  
  return rpmS;
}

void loop()
{
  int sensorVal=analogRead(tempPin);
  
  //Serial.print("Valor del sensor Temperatura: ");
  //Serial.println(sensorVal);
  
  float volts=(sensorVal/1024.0)*5.0;
  float grados=temp(sensorVal,275,0,480,22.2);
  
  /*if (grados>tMax)
  {
   tMax=grados; 
  }
  
  if (grados<tMin)
  {
   tMin=grados; 
  }*/
  
  //Serial.print("RPM: ");

  //lcd.clear();//parpadea la pantalla
  lcd.setCursor(0,0);
  lcd.print("RPM: "); 
  Serial.print("1_");
  Serial.print(grados);
  Serial.print("_");
  
  if(rpmCount==0)
  {
    //Serial.println("Missing");
    lcd.print("Missing"); 
    Serial.print(-1);//rpm
    Serial.print("_");
    Serial.println(-1);//duty
  }
  else
  {
    int rpm=rpms();
    //Serial.print("RPM: ");
    //Serial.println(rpm);
    lcd.print(rpm); 
    Serial.print(rpm);//rpm
    Serial.print("_");
    Serial.println(100);//duty
  }
  
  //lcd.print(" Max: "); 
  //lcd.print(tMax); 
  lcd.print("                     "); //para que refresque toda la fila
  
  lcd.setCursor(0,1);
  lcd.print("Grados: "); 
  lcd.print(grados); 
  lcd.print("                     ");  //para que refresque toda la fila
  
  delay(1000);
  
  
}


