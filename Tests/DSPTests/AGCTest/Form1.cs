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
using AI.SignalLab.Generators;
using AIDog.DataPrep.Base.Seq1D;

namespace AGCTest
{
    public partial class Form1 : Form
    {


        RectGenerator generator = new RectGenerator();
        Vector data = new Vector(0), agc_dat = new Vector(0);
        AGC aGC = new AGC();

        public Form1()
        {
            InitializeComponent();
            aGC.Treshold = 4;
            aGC.Treshold2 = 4;

            generator.PeriodMS = 120;
            generator.freq = 70;
            generator.A = 10000;
            generator.Start();
            generator.SignalSemple += Generator_SignalSemple;
        }

        private void Generator_SignalSemple(double obj)
        {
            data.Add(obj);
            agc_dat.Add(aGC.Calculate(obj));
            chartVisual1.PlotBlack(data);
            chartVisual2.PlotBlack(agc_dat);
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            generator.Dispose();
        }
    }
}
