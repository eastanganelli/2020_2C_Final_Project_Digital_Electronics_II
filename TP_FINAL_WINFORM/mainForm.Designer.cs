namespace mainForm
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnCOM = new System.Windows.Forms.Button();
            this.spCOM = new System.IO.Ports.SerialPort(this.components);
            this.charttbpm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbTemp = new System.Windows.Forms.GroupBox();
            this.lbltmin = new System.Windows.Forms.Label();
            this.lbltavg = new System.Windows.Forms.Label();
            this.lblthigh = new System.Windows.Forms.Label();
            this.gbBPM = new System.Windows.Forms.GroupBox();
            this.lblhmin = new System.Windows.Forms.Label();
            this.lblhmax = new System.Windows.Forms.Label();
            this.lblhavg = new System.Windows.Forms.Label();
            this.delayreader = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.charttbpm)).BeginInit();
            this.gbTemp.SuspendLayout();
            this.gbBPM.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCOM
            // 
            this.btnCOM.Location = new System.Drawing.Point(12, 12);
            this.btnCOM.Name = "btnCOM";
            this.btnCOM.Size = new System.Drawing.Size(107, 70);
            this.btnCOM.TabIndex = 0;
            this.btnCOM.Text = "COM - OFF";
            this.btnCOM.UseVisualStyleBackColor = true;
            this.btnCOM.Click += new System.EventHandler(this.btnCOM_Click);
            // 
            // spCOM
            // 
            this.spCOM.PortName = "COM2";
            this.spCOM.ReadBufferSize = 4;
            this.spCOM.ReceivedBytesThreshold = 4;
            // 
            // charttbpm
            // 
            this.charttbpm.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.Minimum = 30D;
            chartArea1.AxisY2.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY2.IsStartedFromZero = false;
            chartArea1.AxisY2.MaximumAutoSize = 100F;
            chartArea1.AxisY2.Minimum = 30D;
            chartArea1.Name = "ChartArea1";
            this.charttbpm.ChartAreas.Add(chartArea1);
            this.charttbpm.Location = new System.Drawing.Point(125, 12);
            this.charttbpm.Name = "charttbpm";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsXValueIndexed = true;
            series1.Name = "temp";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.charttbpm.Series.Add(series1);
            this.charttbpm.Size = new System.Drawing.Size(851, 567);
            this.charttbpm.TabIndex = 5;
            this.charttbpm.Text = "Graficos";
            // 
            // gbTemp
            // 
            this.gbTemp.Controls.Add(this.lbltmin);
            this.gbTemp.Controls.Add(this.lbltavg);
            this.gbTemp.Controls.Add(this.lblthigh);
            this.gbTemp.Location = new System.Drawing.Point(12, 125);
            this.gbTemp.Name = "gbTemp";
            this.gbTemp.Size = new System.Drawing.Size(107, 140);
            this.gbTemp.TabIndex = 6;
            this.gbTemp.TabStop = false;
            this.gbTemp.Text = "Temperatura [ºC]";
            // 
            // lbltmin
            // 
            this.lbltmin.AutoSize = true;
            this.lbltmin.Location = new System.Drawing.Point(16, 101);
            this.lbltmin.Name = "lbltmin";
            this.lbltmin.Size = new System.Drawing.Size(55, 13);
            this.lbltmin.TabIndex = 2;
            this.lbltmin.Text = "T_MIN: ...";
            // 
            // lbltavg
            // 
            this.lbltavg.AutoSize = true;
            this.lbltavg.Location = new System.Drawing.Point(16, 70);
            this.lbltavg.Name = "lbltavg";
            this.lbltavg.Size = new System.Drawing.Size(57, 13);
            this.lbltavg.TabIndex = 1;
            this.lbltavg.Text = "T_AVG: ...";
            // 
            // lblthigh
            // 
            this.lblthigh.AutoSize = true;
            this.lblthigh.Location = new System.Drawing.Point(16, 36);
            this.lblthigh.Name = "lblthigh";
            this.lblthigh.Size = new System.Drawing.Size(58, 13);
            this.lblthigh.TabIndex = 0;
            this.lblthigh.Text = "T_MAX: ...";
            // 
            // gbBPM
            // 
            this.gbBPM.Controls.Add(this.lblhmin);
            this.gbBPM.Controls.Add(this.lblhmax);
            this.gbBPM.Controls.Add(this.lblhavg);
            this.gbBPM.Location = new System.Drawing.Point(12, 290);
            this.gbBPM.Name = "gbBPM";
            this.gbBPM.Size = new System.Drawing.Size(107, 140);
            this.gbBPM.TabIndex = 7;
            this.gbBPM.TabStop = false;
            this.gbBPM.Text = "Latidos [BPM]";
            // 
            // lblhmin
            // 
            this.lblhmin.AutoSize = true;
            this.lblhmin.Location = new System.Drawing.Point(16, 105);
            this.lblhmin.Name = "lblhmin";
            this.lblhmin.Size = new System.Drawing.Size(55, 13);
            this.lblhmin.TabIndex = 5;
            this.lblhmin.Text = "T_MIN: ...";
            // 
            // lblhmax
            // 
            this.lblhmax.AutoSize = true;
            this.lblhmax.Location = new System.Drawing.Point(16, 40);
            this.lblhmax.Name = "lblhmax";
            this.lblhmax.Size = new System.Drawing.Size(58, 13);
            this.lblhmax.TabIndex = 3;
            this.lblhmax.Text = "T_MAX: ...";
            // 
            // lblhavg
            // 
            this.lblhavg.AutoSize = true;
            this.lblhavg.Location = new System.Drawing.Point(16, 74);
            this.lblhavg.Name = "lblhavg";
            this.lblhavg.Size = new System.Drawing.Size(57, 13);
            this.lblhavg.TabIndex = 4;
            this.lblhavg.Text = "T_AVG: ...";
            // 
            // delayreader
            // 
            this.delayreader.Interval = 500;
            this.delayreader.Tick += new System.EventHandler(this.delayRead_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 591);
            this.Controls.Add(this.gbBPM);
            this.Controls.Add(this.gbTemp);
            this.Controls.Add(this.charttbpm);
            this.Controls.Add(this.btnCOM);
            this.Name = "mainForm";
            this.Text = "TP_FINAL_EDI2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_onFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.charttbpm)).EndInit();
            this.gbTemp.ResumeLayout(false);
            this.gbTemp.PerformLayout();
            this.gbBPM.ResumeLayout(false);
            this.gbBPM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCOM;
        private System.IO.Ports.SerialPort spCOM;
        private System.Windows.Forms.DataVisualization.Charting.Chart charttbpm;
        private System.Windows.Forms.GroupBox gbTemp;
        private System.Windows.Forms.Label lbltmin;
        private System.Windows.Forms.Label lbltavg;
        private System.Windows.Forms.Label lblthigh;
        private System.Windows.Forms.GroupBox gbBPM;
        private System.Windows.Forms.Label lblhmin;
        private System.Windows.Forms.Label lblhmax;
        private System.Windows.Forms.Label lblhavg;
        private System.Windows.Forms.Timer delayreader;
    }
}

