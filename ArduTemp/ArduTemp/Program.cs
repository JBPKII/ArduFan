using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Configuration;

namespace ArduTemp
{
    public struct afConf
    {
        public byte NumFan;//0-5
        public byte TempMin;//ºC
        public byte TempMed;//ºC
        public byte TempMax;//ºC
        public byte DutyMin;//%
        public byte DutyMed;//%
        public byte DutyMax;//%
    }

    public struct afEstado
    {
        public int NumFan;//0-5
        public double Temperatura;//ºC
        public double RPM;//RPMs
        public double Duty;//%
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
