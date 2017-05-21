//Decraracion de variables para los 6 ventiladores PWM
int Fans[6];
//Declaracion de las variables para las 6 sondas de temperatura
int Temps[6];
//Declaracion de las variables para los 6 tacometros
int Tachos[6];

//DeclaraciÃ³n de las variables para inicializar la configuraciÃ³n
byte Configuracion[6+(5*7)+1];

void setup()
{
  //Frecuencia para los puertos PWM
  //Modificar frecuencia PWM
  //Setting Divisor Frequency
  //0x01 1 31250 Hz
  //0x02 8 3906.25 Hz
  //0x03 64 488.28125 Hz
  //0x04 256 122.0703125 Hz
  //0x05 1024 30.517578125 Hz
  //TCCR1B = TCCR1B & 0b11111000 | <setting>;
  //Configuro el PWM a 30 kHz.
  //TCCR0B = TCCR0B & 0b11111000 | 0x01; //Pin 5 y 6
  //TCCR1B = TCCR1B & 0b11111000 | 0x01; //Pin 9 y 10
  //TCCR2B = TCCR2B & 0b11111000 | 0x01; //Pin 3 y 11

  //Puertos PWM
  Fans[0] = 3;
  Fans[1] = 5;
  Fans[2] = 6;
  Fans[3] = 9;
  Fans[4] = 10;
  Fans[5] = 11;

  //Puertos Analogicos
  Temps[0] = A0;
  Temps[1] = A1;
  Temps[2] = A2;
  Temps[3] = A3;
  Temps[4] = A4;
  Temps[5] = A5;

  //Puertos Digitales
  Tachos[0] = 2;
  Tachos[1] = 4;
  Tachos[2] = 7;
  Tachos[3] = 8;
  Tachos[4] = 12;
  Tachos[5] = 13;

  Serial.begin(9600);
  Serial.flush();

  //Configuro cada uno de los pines
  for(int i = 0; i<6; i++)
  {
    pinMode(Fans[i],OUTPUT);
    pinMode(Temps[i],INPUT);
    pinMode(Tachos[i],INPUT);

    analogWrite(Fans[i], 50);

    //Inicializo la configuracion por defecto
    Configuracion[0+(i*7)] = 30;//TempMin ºC
    Configuracion[1+(i*7)] = 10;//PotMin %
    Configuracion[2+(i*7)] = 40;//TempMed ºC
    Configuracion[3+(i*7)] = 50;//PotMed %
    Configuracion[4+(i*7)] = 45;//TempMax ºC
    Configuracion[5+(i*7)] = 90;//PotMax %
    Configuracion[6+(i*7)] = i;//Sensor de Temperatura
  }
}

void loop()
{
  //Bucle por cada uno de los conjuntos Fan Temp Tacho
  for(byte i = 0; i<6; i++)
  {
    //delay (500);
    //Lee la temperatura
    float Temperatura = LeerTemp(i); //Grados centigrados

    //Aplica el valor de PWM
    int Potencia = SetPWM(i, Temperatura); //Porcentaje

    //Lee las RPM
    int RPM = TachoRead(i); //RPMs

    //EnvÃ­a la informaciÃ³n
    Serial.print(i);
    Serial.print('_');
    Serial.print(Temperatura);
    Serial.print('_');
    Serial.print(RPM);
    Serial.print('_');
    Serial.print(Potencia);
    Serial.println(' ');

    //Recopila Congiguracion del Serial
    byte TempConf[7];
    while (Serial.available() > 7)//por lo menos hay 8 (una conf completa)
    {
      byte indxFan = Serial.read();

      if(indxFan > (byte)5)
      {
        //Configuracion no valida
        Serial.println("Serial_Reset");
        Serial.flush();
      }
      else
      {
        TempConf[0] = indxFan;
        //Leo solo 7 posiciones;
        for (byte i = 1; i < 8; i++)
        {
          TempConf[i] = Serial.read();
        }

        //Proceso la configuracion
        Configuracion[0+(indxFan*7)] = TempConf[1];//TempMin ºC
        Configuracion[1+(indxFan*7)] = TempConf[2];//PotMin %
        Configuracion[2+(indxFan*7)] = TempConf[3];//TempMed ºC
        Configuracion[3+(indxFan*7)] = TempConf[4];//PotMed %
        Configuracion[4+(indxFan*7)] = TempConf[5];//TempMax ºC
        Configuracion[5+(indxFan*7)] = TempConf[6];//PotMax %
        Configuracion[6+(indxFan*7)] = TempConf[7];//Sensor de Temperatura
      }
    }
  }
}

//Leer temperatura
float LeerTemp(int Pin)
{
  float Res = 0; 
  int rawValue=-21;
  while (rawValue < 2)
  {
    rawValue = analogRead(Temps[Configuracion[6+(Pin*7)]]); //0-1024

    if(rawValue < 2)
    {
      if(Pin > 0)
      {
        Pin--; 
      }
      else
      {
        rawValue = 2;
      }
    }
  }

  //int rawValue = analogRead(Temps[Configuracion[6+(Pin*7)]]); //0-1024

  Res = Map2(rawValue,275,0,480,22.2);//Incluye los valores de calibracion

  return Res;
}

float Map2(int val, int val0, float temp0, int val1, float temp1)
{
  return (((temp1-temp0)*(float)(val-val0))/(float)(val1-val0))+temp0;
}

//Leer Tacometro
int TachoRead(int Pin)
{
  int TestMs = 500;
  unsigned int RPMs = 0;
  boolean LastH = true;
  unsigned long millisInic = millis();
  while (millis() - millisInic < TestMs)
  {
    if(digitalRead(Tachos[Pin]) == HIGH)
    {
      if(!LastH)
      {
        RPMs++;
        LastH = true;
      }
    }
    else
    {
      LastH = false;
    }
  }

  return ((float)30000*(float)RPMs)/(float)TestMs;
}

//Establecer PWM
int SetPWM(int Pin, float Temperatura)
{
  float Potencia = 0;

  if(Temperatura < -18)
  {
    Potencia = 75;
  }
  else
  {
    if(Temperatura < Configuracion[0+(Pin*7)])
    {
      Potencia = 0;
    }
    else
    {
      if(Temperatura >= Configuracion[0+(Pin*7)]
        && Temperatura < Configuracion[2+(Pin*7)])
      {
        Potencia = map(Temperatura,
        Configuracion[0+(Pin*7)], Configuracion[2+(Pin*7)],
        Configuracion[1+(Pin*7)], Configuracion[3+(Pin*7)]);
      }
      else
      {
        if(Temperatura >= Configuracion[2+(Pin*7)]
          && Temperatura < Configuracion[4+(Pin*7)])
        {
          Potencia = map(Temperatura,
          Configuracion[2+(Pin*7)], Configuracion[4+(Pin*7)],
          Configuracion[3+(Pin*7)], Configuracion[5+(Pin*7)]);
        }
        else
        {
          Potencia = 100;
        }
      }
    }
  }

  byte Res = (byte)map(Potencia, 0, 100, 0, 255);

  analogWrite(Fans[Pin], Res); 

  return Potencia;
}
