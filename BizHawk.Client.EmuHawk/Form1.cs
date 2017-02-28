using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RealTimeCharts
{
    public partial class Form1 : Form
    {
        private Thread fitnessThread;
        private List<Double> listA = new List<Double>();
        private List<Double> listB = new List<Double>();
        private Boolean startingOver = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void getPerformanceCounters()
        {

            using (TextFieldParser parser = new TextFieldParser(@".\\Fitness.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] values = parser.ReadFields();
                    listA.Add(Double.Parse(values[0]));
                    listB.Add(Double.Parse(values[1]));

                    if (fitnessChart.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                    }
                    Thread.Sleep(500);
                }
            }
        }

        private void UpdateCpuChart()
        {
            fitnessChart.Series["Fitness"].Points.Clear();

            for (int i = 0; i < listB.Count - 1; ++i)
            {
                fitnessChart.Series["Fitness"].Points.AddXY(listA[i], listB[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startingOver){
                listA.Clear();
                listB.Clear();
                fitnessChart.Series["Fitness"].Points.Clear();
                fitnessThread = new Thread(new ThreadStart(this.getPerformanceCounters));
                fitnessThread.Start();
            }
            else
            {
                if (new FileInfo(@".\\Fitness.csv").Length != 0)
                {
                    fitnessThread = new Thread(new ThreadStart(this.getPerformanceCounters));
                    fitnessThread.IsBackground = true;
                    startingOver = true;
                    fitnessThread.Start();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cpuChart_Click(object sender, EventArgs e)
        {

        }
    }
}