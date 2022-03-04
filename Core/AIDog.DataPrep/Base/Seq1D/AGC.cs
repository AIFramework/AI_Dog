using AI.DataStructs.Algebraic;
using AI.DSP.IIR;
using System;

namespace AIDog.DataPrep.Base
{
    public class AGC
    {
        public IIRFilter IIRFilterMean { get; private set; }
        public IIRFilter IIRFilterSTD { get; private set; }

        public double Treshold {
            get
            {
                return IIRFilterMean.Treshold;
            }
            set
            {
                IIRFilterMean.Treshold = Treshold;
                IIRFilterSTD.Treshold = Treshold;
            }
        }

        public double Treshold2 { get; set; } = 4;

        public AGC(string path)
        {
            IIRFilterMean = IIRFilter.Load(path);
            IIRFilterSTD = IIRFilter.Load(path);
            //Treshold = 100;
        }
        // Зделать
        //public AGC()
        //{
        //    IIRFilterMean = IIRFilter.Load(filters.ResourceManager.GetString("filter_mean_std"));
        //    IIRFilterSTD = IIRFilter.Load(filters.ResourceManager.GetString("filter_mean_std"));
        //}

        public AGC(Vector kefA, Vector kefB)
        {
            IIRFilterMean = new IIRFilter(kefA, kefB);
            IIRFilterSTD = new IIRFilter(kefA, kefB);
        }

        public double Calculate(double value)
        {
            var filterValue1 = IIRFilterMean.FilterOutp(value);
            var dif = (value - filterValue1);
            var s = dif * dif;
            var filterValue2 = Math.Abs(IIRFilterSTD.FilterOutp(s));
            var outp = dif / (Math.Sqrt(filterValue2) + AI.AISettings.GlobalEps);

            //Ограничение сигнала
            if (outp > Treshold2) outp = Treshold2;
            else if (outp < -Treshold2) outp = -Treshold2;


            //Console.WriteLine(outp);

            return outp;
        }
    }
}
