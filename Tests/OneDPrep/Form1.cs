using AI.DataStructs.Algebraic;
using AI.ML.DataEncoding.PositionalEncoding;
using AIDog.Blocks;
using AIDog.Tools;
using System;
using System.Windows.Forms;


namespace OneDPrep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            logic.Signal2Word.UpdateContrastSignal += Ava_Update;
            logic.Signal2Word.UpdateWord += Signal2Word_UpdateWord;
        }

        LogicBlock logic = new LogicBlock(50+256, 5);

        private double mX = 0, mY = 0;
        IPositionEncoding timeEnc = new MultiscaleEncoder(256);
        int t = 0, ct= 0; // Восприятие времени

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

            logic.Push(Vector.Concat(new[] { inpY, inpX, timeEnc.GetCode(t)} ));
            if(ct%1==0) t++;
            ct++;
        }

        // Сигнал после прореживания
        private void Ava_Update(Vector vector)
        {
            Classes.BarBlack(vector);
            scatter.BarBlack(logic.Signal2Word.SemanticVector);
        }


        /// <summary>
        ///  Появление новых состояний (слов)
        /// </summary>
        private void Signal2Word_UpdateWord(int obj)
        {

            label3.Text = $"Точность: {logic.Acc}\t Ошибка {logic.Eror}";
            label4.Text = $"Слово: {obj}";
            try
            {
                heatMapControl1.CalculateHeatMap(logic.LogicGraph.MainGraph.MainGraph.AdjMatrix);
            }
            catch { }
        }

    }
}
