using AI.DataStructs.Algebraic;
using AI.Extensions;
using AI.ML.Clustering;
using AIDog.DataPrep.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace OneDPrep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            aGC1 = new AGC("filter_mean_std");
            aGC2 = new AGC("filter_mean_std");
            aGC3 = new AGC("filter_mean_std");
        }
        AGC aGC1, aGC2, aGC3;
        private readonly List<Vector> Vectors = new List<Vector>();
        private double mX = 0, mY = 0;
        private int iter = 0;
        private readonly IClustering clustering = new KMeans(5);
        private readonly int modeler = 130;
        private readonly Vector c1y1 = new Vector(0);
        private readonly Vector c1y2 = new Vector(0);
        private readonly Vector c2y1 = new Vector(0);
        private readonly Vector c2y2 = new Vector(0);
        private readonly Vector c3y1 = new Vector(0);
        private readonly Vector c3y2 = new Vector(0);
        private readonly Vector c4y1 = new Vector(0);
        private readonly Vector c4y2 = new Vector(0);
        private readonly Vector c5y1 = new Vector(0);
        private readonly Vector c5y2 = new Vector(0);

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mX = e.X;
            mY = e.Y;
        }

        // Тики
        private void fps_Tick(object sender, EventArgs e)
        {
            Vector vector = new[] { 
                aGC1.Calculate(mX), 
                aGC2.Calculate(mY), 
                aGC3.Calculate(mX * mX) };
            
            vector = Lateral.GetContrast(vector);
            Vectors.Add(vector);
            Vector x = Vector.SeqBeginsWithZero(1, Vectors.Count);
            Classes.BarBlack(vector);

            Vector[] vArr = Vectors.ToArray();
            Vector y_1 = vArr.GetDimention(0);
            Vector y_2 = vArr.GetDimention(1);
            Vector y_3 = vArr.GetDimention(2);

            plotSignal.Clear();
            plotSignal.AddPlot(x, y_1, "x");
            plotSignal.AddPlot(x, y_2, "y");
            plotSignal.AddPlot(x, y_3, "z");

            scatter.Clear();
            //int cl = iter < modeler ? kohonen.Classify(vector) : kohonen.ClassifyAndTrain(vector);
            int cl = iter < modeler + 2 ? 3 : clustering.Classify(vector);

            // Условие обучения кластеризатора
            if (iter++ == modeler)
            {
                clustering.Train(vArr, 2);
            }

            ShowScatter(cl, vector); // Показать скаттерограмму

        }


        // ----------------------------------------------------------------------------//
        // Показать скаттерограмму
        private void ShowScatter(int cl, Vector vector)
        {
            if (iter > modeler)
            {
                if (cl == 0)
                {
                    c1y1.Add(vector[0]);
                    c1y2.Add(vector[1]);
                }
                if (cl == 1)
                {
                    c2y1.Add(vector[0]);
                    c2y2.Add(vector[1]);
                }
                if (cl == 2)
                {
                    c3y1.Add(vector[0]);
                    c3y2.Add(vector[1]);
                }
                if (cl == 3)
                {
                    c4y1.Add(vector[0]);
                    c4y2.Add(vector[1]);
                }
                if (cl == 4)
                {
                    c5y1.Add(vector[0]);
                    c5y2.Add(vector[1]);
                }

                scatter.Clear();
                scatter.AddScatter(c1y1, c1y2, "distr data_1", Color.Red);
                scatter.AddScatter(c2y1, c2y2, "distr data_2", Color.Green);
                scatter.AddScatter(c3y1, c3y2, "distr data_3", Color.Blue);
                scatter.AddScatter(c4y1, c4y2, "distr data_4", Color.Gray);
                scatter.AddScatter(c5y1, c5y2, "distr data_5", Color.Black);
            }
        }
    }
}
