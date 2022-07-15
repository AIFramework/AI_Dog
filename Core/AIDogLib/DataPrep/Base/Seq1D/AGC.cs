using AI.DataStructs.Algebraic;
using AI.DSP.IIR;
using AI.SignalLab.AGC;
using System;

namespace AIDog.DataPrep.Base.Seq1D
{
    [Serializable]
    public class AGC
    {
        public IAGC Agc { get; set; } = new DirectAGC();

        public double Calculate(double value)
        {
            return Agc.Calculate(value);
        }
    }
}
