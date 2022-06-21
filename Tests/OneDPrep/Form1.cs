using AI.DataStructs.Algebraic;
using AI.Extensions;
using AI.ML.Clustering;
using AIDog.DataPrep;
using AIDog.DataPrep.Base;
using AIDog.DataPrep.Base.Seq1D;
using AIDog.DataPrep.WordGeneration;
using AIDog.Rules;
using AIDog.Rules.GraphRules;
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
            signal2Word.UpdateContrastSignal += Ava_Update;
            signal2Word.UpdateWord += Signal2Word_UpdateWord;
        }

        string oldState = "";
        List<Rule> rules = new List<Rule>();
        GRBase logic;

        Signal2Word signal2Word = new Signal2Word(50, 5);
        private readonly List<Vector> Vectors = new List<Vector>();
        private double mX = 0, mY = 0;
    

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mX = e.X;
            mY = e.Y;
        }

        // Тики
        private void fps_Tick(object sender, EventArgs e)
        {
            int regions = 25;
            int X = (int)(regions * mX / pictureBox1.Width);
            int Y = (int)(regions * mY / pictureBox1.Height);

            Vector inpX = Vector.OneHotPol(X, regions-1);
            Vector inpY = Vector.OneHotPol(Y, regions-1);

            signal2Word.Push(Vector.Concat(new[] { inpY, inpX} ));
        }

        // Сигнал после прореживания
        private void Ava_Update(Vector vector)
        {
            Vectors.Add(vector);
            Vector x = Vector.SeqBeginsWithZero(1, Vectors.Count);
            Classes.BarBlack(vector);

            scatter.BarBlack(signal2Word.SemanticVector);
        }

 


        /// <summary>
        ///  Появление новых состояний (слов)
        /// </summary>
        private void Signal2Word_UpdateWord(string obj)
        {
            if (oldState != "")
            {
                rules.Add(new Rule(oldState, obj));
                logic = new GRBase(rules);
                heatMapControl1.CalculateHeatMap(logic.MainGraph.MainGraph.AdjMatrix);
            }
            oldState = obj;
        }

    }
}
