namespace ET_ChitiSat_v1._3
{
    partial class ClaseCorrVolt
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtVoltaje = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtCorriente = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chtVoltaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCorriente)).BeginInit();
            this.SuspendLayout();
            // 
            // chtVoltaje
            // 
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.Title = "Tiempo [mm:ss]";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Title = "Voltaje Bateria [V]";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chtVoltaje.ChartAreas.Add(chartArea1);
            this.chtVoltaje.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chtVoltaje.Legends.Add(legend1);
            this.chtVoltaje.Location = new System.Drawing.Point(0, 0);
            this.chtVoltaje.Margin = new System.Windows.Forms.Padding(2);
            this.chtVoltaje.Name = "chtVoltaje";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Voltaje";
            this.chtVoltaje.Series.Add(series1);
            this.chtVoltaje.Size = new System.Drawing.Size(701, 286);
            this.chtVoltaje.TabIndex = 14;
            this.chtVoltaje.Text = "chart1";
            // 
            // chtCorriente
            // 
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.Title = "Tiempo [mm:ss]";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.Title = "Corriente Bateria [mA]";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chtCorriente.ChartAreas.Add(chartArea2);
            this.chtCorriente.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.Name = "Legend1";
            this.chtCorriente.Legends.Add(legend2);
            this.chtCorriente.Location = new System.Drawing.Point(0, 295);
            this.chtCorriente.Margin = new System.Windows.Forms.Padding(2);
            this.chtCorriente.Name = "chtCorriente";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Corriente";
            this.chtCorriente.Series.Add(series2);
            this.chtCorriente.Size = new System.Drawing.Size(701, 286);
            this.chtCorriente.TabIndex = 17;
            this.chtCorriente.Text = "chart1";
            // 
            // ClaseCorrVolt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(701, 581);
            this.Controls.Add(this.chtCorriente);
            this.Controls.Add(this.chtVoltaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClaseCorrVolt";
            this.Text = "ClaseCorrVolt";
            ((System.ComponentModel.ISupportInitialize)(this.chtVoltaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCorriente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chtVoltaje;
        public System.Windows.Forms.DataVisualization.Charting.Chart chtCorriente;
    }
}