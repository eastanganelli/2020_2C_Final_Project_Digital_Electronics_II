namespace mainForm
{
    partial class ftemp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.charttbpm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.charttbpm)).BeginInit();
            this.SuspendLayout();
            // 
            // charttbpm
            // 
            this.charttbpm.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.Maximum = 50D;
            chartArea2.AxisY.MaximumAutoSize = 100F;
            chartArea2.AxisY.Minimum = 28D;
            chartArea2.AxisY2.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY2.IsStartedFromZero = false;
            chartArea2.AxisY2.MaximumAutoSize = 100F;
            chartArea2.AxisY2.Minimum = 30D;
            chartArea2.Name = "ChartArea1";
            this.charttbpm.ChartAreas.Add(chartArea2);
            this.charttbpm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.charttbpm.Location = new System.Drawing.Point(0, 0);
            this.charttbpm.Margin = new System.Windows.Forms.Padding(1);
            this.charttbpm.Name = "charttbpm";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "temp";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.charttbpm.Series.Add(series2);
            this.charttbpm.Size = new System.Drawing.Size(878, 534);
            this.charttbpm.TabIndex = 6;
            this.charttbpm.Text = "Graficos";
            // 
            // ftemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 534);
            this.Controls.Add(this.charttbpm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ftemp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ftemp";
            this.Load += new System.EventHandler(this.ftemp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.charttbpm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart charttbpm;
    }
}