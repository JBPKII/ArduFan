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
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config FrmConf = new Config();
            FrmConf.ShowDialog();
        }

        private void Panel_Load(object sender, EventArgs e)
        {
            //Lee la configuración desde fichero
            
            //Carga los seis controles
            for (int i = 0; i < 6; i++)
            {

                string TempDescripcion = System.Configuration.ConfigurationManager.AppSettings["Descripcion" + (i + 1).ToString()];

                //envía e inicializa
                CuadroMonitor CuadroM = new CuadroMonitor(i, TempDescripcion);
                FLPanel.Controls.Add(CuadroM);
            }

            FLPanel.Refresh();
        }
    }
}
