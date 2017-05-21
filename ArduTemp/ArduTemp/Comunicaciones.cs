using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArduTemp
{
    public class Coms
    {
        private System.IO.Ports.SerialPort _Puerto = new System.IO.Ports.SerialPort();
        private System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();

        public Coms()
        {

            SetComs(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("BaudRate")),
                 System.Configuration.ConfigurationManager.AppSettings.Get("PortName"),
                 Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("ReadTimeout")),
                 Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("TimerInterval")));
        }

        public void SetComs(int BaudRate, string PortName, int ReadTimeout, int TimerInterval)
        {
            this._Puerto.BaudRate = BaudRate;
            this._Puerto.PortName = PortName;
            this._Puerto.ReadTimeout = ReadTimeout;
            this._Timer.Interval = TimerInterval;

            this.Open();
        }

        public bool Open()
        {
            this._Puerto.Open();

            if (this._Puerto.IsOpen)
            {
                this._Puerto.DiscardInBuffer();

                this._Timer.Enabled = true;
                this._Timer.Start();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOpen
        {
            get
            {
                return this._Puerto.IsOpen;
            }
        }

        public bool Enviar(afConf Configuracion)
        {
            bool Res = false;

            if (!this._Puerto.IsOpen)
            {
                this._Puerto.Open();
            }

            if (!this._Puerto.IsOpen)
            {
                try
                {
                    byte[] EnvBuffer = new byte[7] { Configuracion.NumFan,
                                                    Configuracion.TempMin, Configuracion.DutyMin, 
                                                    Configuracion.TempMed, Configuracion.DutyMed, 
                                                    Configuracion.TempMax, Configuracion.DutyMax };
                    this._Puerto.Write(EnvBuffer, 0, 7);

                    Res = true;
                }
                catch (System.Exception sysEx)
                {
                    sysEx.Data.Clear();
                }
            }

            return Res;
        }

        public string RecibirStr()
        {
            string Res = "";

            if (!this._Puerto.IsOpen)
            {
                //Res = "-Reabriendo '"+this._Puerto.PortName + "@" +this._Puerto.BaudRate +"'";
                try
                {
                    this._Puerto.Open();
                }
                catch (System.Exception sysEx)
                {
                    sysEx.Data.Clear();
                }
            }
                
            //lee del serial port
            try
            {
                while (this._Puerto.BytesToRead > 0)
                {
                    Res = this._Puerto.ReadLine();
                }
            }
            catch (System.Exception sysEx)
            {
                //Res = sysEx.Message;
                try
                {
                    this._Puerto.Dispose();
                }
                catch (System.Exception sysEx2)
                {
                    sysEx2.Data.Clear();
                }
                sysEx.Data.Clear();
            }
            
            return Res;
        }

        public afEstado RecibirEstado()
        {
            afEstado Res = new afEstado();
            Res.NumFan = -1;
            Res.Temperatura = double.NaN;
            Res.RPM = double.NaN;
            Res.Duty = double.NaN;

            string ReadBuffer = RecibirStr();
            
            string[] Datos = ReadBuffer.Split('_');

            if (Datos.Count() == 4)
            {
                Res.NumFan = Convert.ToInt32(Datos[0]);
                Res.Temperatura = Convert.ToDouble(Datos[1]);
                if (Datos[2] != "")
                {
                    Res.RPM = Convert.ToDouble(Datos[2]);
                    Res.Duty = Convert.ToDouble(Datos[3]);
                }
            }
                
            return Res;
        }
    }
}
