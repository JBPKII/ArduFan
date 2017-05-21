namespace ArduTemp
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBConexion = new System.Windows.Forms.GroupBox();
            this.CmBTestConn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBPuerto = new System.Windows.Forms.ComboBox();
            this.CBBaudios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTimeOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmBGuardar = new System.Windows.Forms.Button();
            this.CmBCancelar = new System.Windows.Forms.Button();
            this.GBConexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBConexion
            // 
            this.GBConexion.Controls.Add(this.label5);
            this.GBConexion.Controls.Add(this.TxtTimeOut);
            this.GBConexion.Controls.Add(this.label4);
            this.GBConexion.Controls.Add(this.CmBTestConn);
            this.GBConexion.Controls.Add(this.label3);
            this.GBConexion.Controls.Add(this.label2);
            this.GBConexion.Controls.Add(this.label1);
            this.GBConexion.Controls.Add(this.CBPuerto);
            this.GBConexion.Controls.Add(this.CBBaudios);
            this.GBConexion.Location = new System.Drawing.Point(12, 12);
            this.GBConexion.Name = "GBConexion";
            this.GBConexion.Size = new System.Drawing.Size(271, 74);
            this.GBConexion.TabIndex = 0;
            this.GBConexion.TabStop = false;
            this.GBConexion.Text = "Conexión:";
            // 
            // CmBTestConn
            // 
            this.CmBTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmBTestConn.Location = new System.Drawing.Point(190, 45);
            this.CmBTestConn.Name = "CmBTestConn";
            this.CmBTestConn.Size = new System.Drawing.Size(75, 23);
            this.CmBTestConn.TabIndex = 5;
            this.CmBTestConn.Text = "Test";
            this.CmBTestConn.UseVisualStyleBackColor = true;
            this.CmBTestConn.Click += new System.EventHandler(this.CmBTestConn_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "baud.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "@";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Puerto:";
            // 
            // CBPuerto
            // 
            this.CBPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPuerto.FormattingEnabled = true;
            this.CBPuerto.Items.AddRange(new object[] {
            "COM3"});
            this.CBPuerto.Location = new System.Drawing.Point(62, 19);
            this.CBPuerto.Name = "CBPuerto";
            this.CBPuerto.Size = new System.Drawing.Size(65, 21);
            this.CBPuerto.TabIndex = 1;
            // 
            // CBBaudios
            // 
            this.CBBaudios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBBaudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBaudios.FormattingEnabled = true;
            this.CBBaudios.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.CBBaudios.Location = new System.Drawing.Point(157, 19);
            this.CBBaudios.Name = "CBBaudios";
            this.CBBaudios.Size = new System.Drawing.Size(68, 21);
            this.CBBaudios.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "TimeOut:";
            // 
            // TxtTimeOut
            // 
            this.TxtTimeOut.Location = new System.Drawing.Point(62, 46);
            this.TxtTimeOut.Name = "TxtTimeOut";
            this.TxtTimeOut.Size = new System.Drawing.Size(65, 20);
            this.TxtTimeOut.TabIndex = 7;
            this.TxtTimeOut.Text = "1000";
            this.TxtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ms";
            // 
            // CmBGuardar
            // 
            this.CmBGuardar.Location = new System.Drawing.Point(374, 225);
            this.CmBGuardar.Name = "CmBGuardar";
            this.CmBGuardar.Size = new System.Drawing.Size(75, 23);
            this.CmBGuardar.TabIndex = 1;
            this.CmBGuardar.Text = "Guardar";
            this.CmBGuardar.UseVisualStyleBackColor = true;
            this.CmBGuardar.Click += new System.EventHandler(this.CmBGuardar_Click);
            // 
            // CmBCancelar
            // 
            this.CmBCancelar.Location = new System.Drawing.Point(293, 225);
            this.CmBCancelar.Name = "CmBCancelar";
            this.CmBCancelar.Size = new System.Drawing.Size(75, 23);
            this.CmBCancelar.TabIndex = 2;
            this.CmBCancelar.Text = "Cancelar";
            this.CmBCancelar.UseVisualStyleBackColor = true;
            this.CmBCancelar.Click += new System.EventHandler(this.CmBCancelar_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 260);
            this.Controls.Add(this.CmBCancelar);
            this.Controls.Add(this.CmBGuardar);
            this.Controls.Add(this.GBConexion);
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.GBConexion.ResumeLayout(false);
            this.GBConexion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBConexion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBPuerto;
        private System.Windows.Forms.ComboBox CBBaudios;
        private System.Windows.Forms.Button CmBTestConn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTimeOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CmBGuardar;
        private System.Windows.Forms.Button CmBCancelar;
    }
}