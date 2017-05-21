namespace ArduTemp
{
    partial class Form1
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
            try
            {
                this.serialPort1.Close();
            }
            catch (System.Exception sysEx)
            {
                sysEx.Data.Clear();
            }
            finally
            {
                this.serialPort1.Dispose();
            }

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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.TxtDuty = new System.Windows.Forms.TextBox();
            this.TxtRPM = new System.Windows.Forms.TextBox();
            this.TxtTemp = new System.Windows.Forms.TextBox();
            this.TxtLeido = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "ArduTemp";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "RPM:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Duty:";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(55, 38);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(54, 20);
            this.TxtID.TabIndex = 5;
            // 
            // TxtDuty
            // 
            this.TxtDuty.Location = new System.Drawing.Point(55, 116);
            this.TxtDuty.Name = "TxtDuty";
            this.TxtDuty.Size = new System.Drawing.Size(54, 20);
            this.TxtDuty.TabIndex = 7;
            // 
            // TxtRPM
            // 
            this.TxtRPM.Location = new System.Drawing.Point(55, 90);
            this.TxtRPM.Name = "TxtRPM";
            this.TxtRPM.Size = new System.Drawing.Size(54, 20);
            this.TxtRPM.TabIndex = 8;
            // 
            // TxtTemp
            // 
            this.TxtTemp.Location = new System.Drawing.Point(55, 64);
            this.TxtTemp.Name = "TxtTemp";
            this.TxtTemp.Size = new System.Drawing.Size(54, 20);
            this.TxtTemp.TabIndex = 9;
            // 
            // TxtLeido
            // 
            this.TxtLeido.Location = new System.Drawing.Point(12, 12);
            this.TxtLeido.Name = "TxtLeido";
            this.TxtLeido.Size = new System.Drawing.Size(394, 20);
            this.TxtLeido.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Panel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtLeido);
            this.Controls.Add(this.TxtTemp);
            this.Controls.Add(this.TxtRPM);
            this.Controls.Add(this.TxtDuty);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ArduTemp:";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.TextBox TxtDuty;
        private System.Windows.Forms.TextBox TxtRPM;
        private System.Windows.Forms.TextBox TxtTemp;
        private System.Windows.Forms.TextBox TxtLeido;
        public System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

