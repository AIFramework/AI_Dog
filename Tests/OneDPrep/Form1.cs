using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI.Extensions;


namespace OneDPrep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Vector> Vectors = new List<Vector>();
        double mX = 0, mY = 0;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mX = e.X;
            mY = e.Y;
        }

        private void fps_Tick(object sender, EventArgs e)
        {
            Vector vector = new[] { mX, mY, Math.Sqrt(mY * mX) };
            vector = AIDog.DataPrep.Base.Lateral.GetContrast(vector);
            Vectors.Add(vector);
            Vector x = Vector.SeqBeginsWithZero(1, Vectors.Count);
            Classes.BarBlack(vector);
            
            var vArr = Vectors.ToArray();
            var y_1 = vArr.GetDimention(0);
            var y_2 = vArr.GetDimention(1);
            var y_3 = vArr.GetDimention(2);

            plotSignal.Clear();
            plotSignal.AddPlot(x, y_1, "x");
            plotSignal.AddPlot(x, y_2, "y");
            plotSignal.AddPlot(x, y_3, "z");

            scatter.Clear();
            scatter.AddScatter(y_3, y_2, "distr data_1", Color.Gray);
            scatter.AddScatter(y_1, y_2, "distr data_2", Color.Black);
            scatter.AddScatter(y_2, y_3, "distr data_3", Color.DarkGray);

        }
    }
}
