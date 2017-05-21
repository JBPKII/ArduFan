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
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {

            //Busca los puertos COM existentes y rellena CBPuerto.
            this.CBPuerto.Items.Clear();

            foreach (string SPort in System.IO.Ports.SerialPort.GetPortNames())
            {
                this.CBPuerto.Items.Add(SPort);
            }

            if (this.CBPuerto.Items.Count > 0)
            {
                this.CBPuerto.SelectedIndex = 0;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No se han encontrado puertos COM");
                this.CmBTestConn.Enabled = false;
            }

            this.CBBaudios.SelectedIndex = 1;
        }

        private void CmBTestConn_Click(object sender, EventArgs e)
        {
            Form1 FormDatos = (Form1)Application.OpenForms["Form1"];
            FormDatos.timer1.Stop();

            string Port = FormDatos.serialPort1.PortName;
            int Baud = FormDatos.serialPort1.BaudRate;
            int TimeOut = FormDatos.serialPort1.ReadTimeout;

            try
            {
                FormDatos.serialPort1.Close();
                FormDatos.serialPort1.Dispose();
            }
            catch (System.Exception sysEx)
            {
                sysEx.Data.Clear();
            }

            FormDatos.serialPort1.PortName = (string)this.CBPuerto.SelectedItem;
            FormDatos.serialPort1.BaudRate = Convert.ToInt32(this.CBBaudios.SelectedItem);
            FormDatos.serialPort1.ReadTimeout = Convert.ToInt32(this.TxtTimeOut.Text);

            try
            {
                FormDatos.serialPort1.Open();
                if (FormDatos.serialPort1.IsOpen)
                {
                    System.Windows.Forms.MessageBox.Show("Datos leidos:\n" + FormDatos.serialPort1.ReadLine(),"Configuración correcta.");
                    FormDatos.serialPort1.Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No ha sido posible abrir el puerto:\n" 
                                                        + (string)this.CBPuerto.SelectedItem + "@" + (string)this.CBBaudios.SelectedItem, "Configuración erronea.");
                }
            }
            catch (System.Exception sysEx)
            {
                System.Windows.Forms.MessageBox.Show(sysEx.Message, "Configuración erronea.");
                try
                {
                    FormDatos.serialPort1.Dispose();
                }
                catch (System.Exception sysEx2)
                {
                    sysEx2.Data.Clear();
                }
                sysEx.Data.Clear();
            }

            FormDatos.serialPort1.PortName = Port;
            FormDatos.serialPort1.BaudRate = Baud;
            FormDatos.serialPort1.ReadTimeout = TimeOut;

            try
            {
                FormDatos.serialPort1.Open();
            }
            catch (System.Exception sysEx)
            {
                sysEx.Data.Clear();
            }

            FormDatos.timer1.Start();
        }

        private void CmBCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmBGuardar_Click(object sender, EventArgs e)
        {
            //Guarda los cambios

            this.Close();
        }

        
    }
}
