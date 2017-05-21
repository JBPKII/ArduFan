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
    public partial class Grafico : UserControl
    {
        private int _pxAnchoTick = 100;
        private int _pxMargen = 20;

        private System.Drawing.Drawing2D.GraphicsPath _ejes = new System.Drawing.Drawing2D.GraphicsPath();
        private System.Drawing.Drawing2D.GraphicsPath _valores = new System.Drawing.Drawing2D.GraphicsPath();

        private System.Drawing.Drawing2D.GraphicsPath _Barras = new System.Drawing.Drawing2D.GraphicsPath();

        private Timer _Timer = new Timer();

        private int _LastValueY = 0;
        private int _MaxValueY = 0;
        private int _MinValueY = 0;

        public int Value
        {
            set
            {
                _LastValueY = value;
            }
        }

        public Grafico()
        {
            InitializeComponent();

            this._Timer.Tick += new System.EventHandler(this._Timer_TickRefresh);

            _Timer.Interval = 1000;//ms
        }

        private void Grafico_Load(object sender, EventArgs e)
        {
            Grafico_Reload(sender, e);

            _Timer.Enabled = true;
            _Timer.Start();
        }

        private void Grafico_Resize(object sender, EventArgs e)
        {
            Grafico_Reload(sender, e);
        }

        private void Grafico_Reload(object sender, EventArgs e)
        {
            _Timer.Stop();

            //Dibuja los ejes
            _ejes.Reset();
            _ejes.AddLine(_pxMargen, _pxMargen, _pxMargen, this.Height - _pxMargen);
            _ejes.AddLine(_pxMargen, this.Height - _pxMargen, this.Width - _pxMargen, this.Height - _pxMargen);

            _valores.Reset();
            _valores.AddString(_MaxValueY.ToString(), System.Drawing.FontFamily.GenericSansSerif, (int)System.Drawing.FontStyle.Regular, (float)5, new System.Drawing.Point(0, _pxMargen), System.Drawing.StringFormat.GenericDefault);
            _valores.AddString(_MinValueY.ToString(), System.Drawing.FontFamily.GenericSansSerif, (int)System.Drawing.FontStyle.Regular, (float)5, new System.Drawing.Point(0, this.Height-_pxMargen), System.Drawing.StringFormat.GenericDefault);

            //Pepara la línea gráfica
            _Barras.Reset();
            Point[] _vertices=new Point[((this.Width - _pxMargen) / _pxAnchoTick) +3];
            _vertices[0] = new Point(_pxMargen, this.Height - _pxMargen);
            _vertices[1] = _vertices[0];

            int lastX = _pxMargen;
            for (int i = 2; i < _vertices.Length - 2; i++)
            {
                lastX = +_pxAnchoTick;
                _vertices[i] = new Point(lastX, this.Height - _pxMargen);
            }

            _vertices[_vertices.Length - 2] = new Point(this.Width, this.Height - _pxMargen);
            _vertices[_vertices.Length - 1] = _vertices[_vertices.Length - 2];

            _Timer.Start();
        }

        private void _Timer_TickRefresh(object sender, EventArgs e)
        {
            this.SuspendLayout();

            //Refresca los valores del gráfico
            for (int i=1;i<_Barras.PathPoints.Length -2;i++)
            {
                _Barras.PathPoints[i].Y = _Barras.PathPoints[i + 1].Y;
            }

            if(_MinValueY > _LastValueY)
            {
                _MinValueY = _LastValueY;
            }
            if(_MaxValueY < _LastValueY)
            {
                _MaxValueY = _LastValueY;
            }

            _Barras.PathPoints[_Barras.PathPoints.Length - 2].Y = (float)((this.Handle - _pxMargen) - (((this.Width - (2 * _pxMargen)) * (_LastValueY - _MinValueY)) / (_MaxValueY - _MinValueY)));

            //Refresca los valores de los ejes
            _valores.Reset();
            _valores.AddString(_MaxValueY.ToString(), System.Drawing.FontFamily.GenericSansSerif, (int)System.Drawing.FontStyle.Regular, (float)5, new System.Drawing.Point(0, _pxMargen), System.Drawing.StringFormat.GenericDefault);
            _valores.AddString(_MinValueY.ToString(), System.Drawing.FontFamily.GenericSansSerif, (int)System.Drawing.FontStyle.Regular, (float)5, new System.Drawing.Point(0, this.Height - _pxMargen), System.Drawing.StringFormat.GenericDefault);

            this.ResumeLayout(false);
        }


    }
}
