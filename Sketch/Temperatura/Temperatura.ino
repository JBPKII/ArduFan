#include <LiquidCrystal.h>
LiquidCrystal lcd(13,12,8,7,4,2);
const int switchPin=6;

const int tempPin=A0;
int tMax=-100;
int tMin=100;

const int fanPWM=5;
const int fanTacho=6;

float temp(int val, int val0, float temp0, int val1, float temp1)
{
  return (((temp1-temp0)*(val-val0))/(val1-val0))+temp0;
}

void setup()
{
  Serial.begin(9600);
  lcd.begin(16,2);
  //pinMode(switchPin,INPUT);
  lcd.clear();
  pinMode(fanPWM, OUTPUT);
  pinMode(fanTacho, INPUT);
}

void loop()
{
  int sensorVal=analogRead(tempPin);
  
  Serial.print("Valor del sensor: ");
  Serial.println(sensorVal);
  
  float volts=(sensorVal/1024.0)*5.0;
  float grados=temp(sensorVal,275,0,480,22.2);
  
  if (grados>tMax)
  {
   tMax=grados; 
  }
  
  if (grados<tMin)
  {
   tMin=grados; 
  }
  
  //lcd.clear();//parpadea la pantalla
  lcd.setCursor(0,0);
  lcd.print("Min: "); 
  lcd.print(tMin); 
  lcd.print(" Max: "); 
  lcd.print(tMax); 
  lcd.print("      "); //para que refresque toda la fila
  
  lcd.setCursor(0,1);
  lcd.print("Grados: "); 
  lcd.print(grados); 
  lcd.print("      ");  //para que refresque toda la fila
  
  delay(500);
  
  int rpm=rpms(fantacho,100);
  Serial.print("RPM: ");
  Serial.println(rpm);
}

