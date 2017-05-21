using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArduTemp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Coms PuertoCom = new Coms();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Panel FrmPanel = new Panel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.serialPort1.IsOpen)
            {
                //lee del serial port
                try
                {
                    while (this.serialPort1.BytesToRead > 0)
                    {
                        string Buffer = this.serialPort1.ReadLine();
                        this.TxtLeido.Text = Buffer;

                        string[] Datos = Buffer.Split('_');
                        if (Datos.Count() == 4)
                        {
                            this.TxtID.Text = Datos[0];
                            this.TxtTemp.Text = Datos[1];
                            if (Datos[2] == "-1")
                            {
                                this.TxtRPM.Text = "Missing";
                                this.TxtDuty.Text = "Missing";
                            }
                            else
                            {
                                this.TxtRPM.Text = Datos[2];
                                this.TxtDuty.Text = Datos[3];
                            }
                        }
                        else
                        {
                            //Datos no válidos
                        }
                    }
                }
                catch (System.Exception sysEx)
                {
                    this.TxtLeido.Text = sysEx.Message;
                    try
                    {
                        this.serialPort1.Dispose();
                    }
                    catch (System.Exception sysEx2)
                    {
                        sysEx2.Data.Clear();
                    }
                    sysEx.Data.Clear();
                }
            }
            else
            {
                this.TxtLeido.Text = "Reabriendo 'COM3@9600'";
                try
                {
                    this.serialPort1.Open();
                }
                catch (System.Exception sysEx)
                {
                    sysEx.Data.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel Pan = new Panel();
            Pan.ShowDialog();
        }
    }
}
