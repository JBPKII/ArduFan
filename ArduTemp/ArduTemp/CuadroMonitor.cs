using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArduTemp
{
    public partial class CuadroMonitor : UserControl
    {
        private struct afRegistro
        {
            public DateTime Hora;//now()
            public double Temperatura;//ºC
            public double RPMs;
            public double Potencia;//%
        }

        private IList<afRegistro> afRegistros = new List<afRegistro>();

        private int _IndxControl;

        private Grafico _Graf = new Grafico();

        public CuadroMonitor()
        {
            _IndxControl = -1;
            this.GB.Text = "Grupo ...:";
            this.TxtId.Text = "Sin asignar.";
            this.GB.Controls.Add(_Graf);

            _Graf.Top = this.label4.Top + 23;
            _Graf.Left = this.label4.Left;
            _Graf.Width = this.TxtDuty.Left+this.TxtDuty.Width ;
            _Graf.Height = GB.Height - _Graf.Top;

            _Graf.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

            InitializeComponent();
        }

        public CuadroMonitor(int IndexControl, string Descripcion = "")
        {
            _IndxControl = IndexControl;

            this.GB.Text = "Grupo " + (_IndxControl+1).ToString() + ":";
            this.TxtId.Text = Descripcion;

            InitializeComponent();
        }

        public bool afSeleccionado
        {
            get
            {
                return this.RbSelec.Checked;
            }
        }

        public void afUpdate(string BufferArduino)
        {
            this.SuspendLayout();

            string[] Valores = BufferArduino.Split(new char[] { '_' }, 10);

            if (Valores.Length == 4 && Convert.ToInt32(Valores[0]) == _IndxControl)
            {
                //Corresponde a este control
                afRegistro TempReg;
                TempReg.Hora = DateTime.Now;
                TempReg.Temperatura = Convert.ToDouble(Valores[1]);//ºC
                TempReg.RPMs = Convert.ToDouble(Valores[2]);
                TempReg.Potencia = Convert.ToDouble(Valores[3]);//%

                //Actualiza los valores en los marcadores
                this.TxtTemp.Text = TempReg.Temperatura.ToString();
                this.TxtRPM.Text = TempReg.RPMs.ToString();
                this.TxtDuty.Text = TempReg.Potencia.ToString();

                //Añade el TempReg en la última posición
                if (afRegistros.Count == 25)//caso más habitual
                {
                    //Añado al final y elimino el primero
                    afRegistros.RemoveAt(0);
                    /*for (int i = 1; i < afRegistros.Count; i++)
                    {
                        afRegistros[i - 1] = afRegistros[i];
                    }*/
                    afRegistros.Add(TempReg);
                    System.Windows.Forms.MessageBox.Show("¿25 = " + afRegistros.Count + "?");
                }
                else
                {
                    afRegistros.Add(TempReg);
                }

                //Actualiza las estadísticas
                double MTemp= -100, mTemp= 100;
                double MRPM = -100, mRPM = 100;
                double MDuty = -100, mDuty = 100;
                foreach (afRegistro Reg in afRegistros)
                {
                    if (Reg.Temperatura > MTemp)
                    {
                        MTemp = Reg.Temperatura;
                    }
                    if (Reg.Temperatura < mTemp)
                    {
                        mTemp = Reg.Temperatura;
                    }

                    if (Reg.RPMs > MRPM)
                    {
                        MRPM = Reg.RPMs;
                    }
                    if (Reg.RPMs < mRPM)
                    {
                        mRPM = Reg.RPMs;
                    }

                    if (Reg.Potencia > MDuty)
                    {
                        MDuty = Reg.Potencia;
                    }
                    if (Reg.Potencia < mDuty)
                    {
                        mDuty = Reg.Potencia;
                    }
                }

                this.TxtTempMax.Text = MTemp.ToString();
                this.TxtTempMin.Text = mTemp.ToString();

                this.TxtRpmMax.Text = MRPM.ToString();
                this.TxtRpmMin.Text = mRPM.ToString();

                this.TxtDutyMax.Text = MDuty.ToString();
                this.TxtDutyMin.Text = mDuty.ToString();

                //Actualiza la gráfica
                _Graf.Value = (int)Math.Truncate(afRegistros.Last<afRegistro>().RPMs);


            }

            this.ResumeLayout(false);
        }
    }
}
