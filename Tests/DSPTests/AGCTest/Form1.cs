﻿using System;
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


        SineGenerator generator = new SineGenerator();
        Vector data = new Vector(0), agc_dat = new Vector(0);
        AGC aGC = new AGC();
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            aGC.Agc = new LogAGC();
            aGC.Agc.TresholdAGC = 4;

            generator.PeriodMS = 50;
            generator.freq = 20;
            generator.A = 200;
            generator.AdditivNoiseKoef = 20;
            generator.MultiplTrend = 100;
            generator.AdditivTrend = 60000;
            generator.MultiplNoiseKoef = 0.21;

            generator.Start();
            generator.SignalSemple += Generator_SignalSemple;
        }

        private void Generator_SignalSemple(double obj)
        {
 
            data.Add(obj);
            agc_dat.Add(aGC.Calculate(obj));
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
