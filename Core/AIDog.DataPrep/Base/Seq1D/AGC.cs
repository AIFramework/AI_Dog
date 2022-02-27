using AI.DataStructs.Algebraic;
using AI.DSP.IIR;
using System;

namespace AIDog.DataPrep.Base
{
    public class AGC
    {
        public IIRFilter IIRFilter1 { get; private set; }
        public IIRFilter IIRFilter2 { get; private set; }

        public AGC(Vector kefA, Vector kefB)
        {
            IIRFilter1 = new IIRFilter(kefA, kefB);
            IIRFilter2 = new IIRFilter(kefA, kefB);
        }

        public double Calculate(double value)
        {
            var filterValue1 = IIRFilter1.Outp(value);
            var dif = (value - filterValue1);
            var s = dif * dif;
            var filterValue2 = IIRFilter2.Outp(s);

            return dif / Math.Sqrt(filterValue2);
        }
    }
}
