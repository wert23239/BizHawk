using System.Drawing;

namespace RealTimeCharts
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
            this.fitnessChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fitnessChart)).BeginInit();
            this.SuspendLayout();
            // 
            // fitnessChart
            // 
            chartArea1.Name = "ChartArea1";
            this.fitnessChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.fitnessChart.Legends.Add(legend1);
            this.fitnessChart.Location = new System.Drawing.Point(10, 10);
            this.fitnessChart.Name = "fitnessChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Fitness";
            this.fitnessChart.Series.Add(series1);
            this.fitnessChart.Series["Fitness"].Color = Color.Blue;
            this.fitnessChart.Series["Fitness"].BorderWidth = 3;
            this.fitnessChart.BorderSkin.BorderColor = Color.Gray;
            this.fitnessChart.Size = new System.Drawing.Size(432, 178);
            this.fitnessChart.TabIndex = 0;
            this.fitnessChart.Text = "chart1";
            this.fitnessChart.Click += new System.EventHandler(this.cpuChart_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(346, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 200);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fitnessChart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fitnessChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart fitnessChart;
        private System.Windows.Forms.Button button1;
    }
}

