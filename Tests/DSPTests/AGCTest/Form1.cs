using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI.DataStructs.Algebraic;
using AI.SignalLab.AGC;
using AI.SignalLab.AGC.CustomAGC;
using AI.SignalLab.Generators;
using AIDog.DataPrep.Base.Seq1D;

namespace AGCTest
{
    public partial class Form1 : Form
    {


        RectGenerator generator = new RectGenerator();
        Vector data = new Vector(220), agc_dat = new Vector(220);
        AGC aGC = new AGC();
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            aGC.Agc = new MinCombineAGC();
            aGC.Agc.TresholdAGC = 4;

            generator.PeriodMS = 70;
            generator.freq = 20;
            generator.A = 20;
            generator.AdditivNoiseKoef = 21;
            generator.MultiplTrend = 800;
            generator.AdditivTrend = 145000;
            generator.MultiplNoiseKoef = 0.23;

            generator.Start();
            generator.SignalSemple += Generator_SignalSemple;
        }

        private void Generator_SignalSemple(double obj)
        {
 
            data.AddCBE(obj);
            agc_dat.AddCBE(aGC.Calculate(obj));
            chartVisual1.PlotBlack(data);
            chartVisual2.PlotBlack(agc_dat);
            counter++;
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            generator.Dispose();
        }
    }
}
