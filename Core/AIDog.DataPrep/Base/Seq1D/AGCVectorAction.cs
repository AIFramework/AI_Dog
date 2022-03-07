using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.DataPrep.Base.Seq1D
{
    public class AGCVectorAction
    {
        public AGC[] Agc { get; set; }
        private Vector _vect = new Vector(0);
        public double TresholdDif = 0.1;
        public double TresholdAgc = 0.1;

        public AGCVectorAction(int dim) 
        {
            Agc = new AGC[dim];
            for (int i = 0; i < dim; i++)
            {
                Agc[i] = new AGC();
            }

            Update += AGCVectorAction_Update;
        }

        
        /// <summary>
        /// Добавить сигнал в обработчик(прореживатель образов #1)
        /// </summary>
        /// <param name="vector">Многоканальный сигнал</param>
        public void PushSignal(Vector vector) 
        {
            if(_vect.Count == 0) 
            {
                _vect = vector.Clone();
                Update(PushSig(vector));
            }
            else
            {
                Vector new_sig = PushSig(vector);
                double maxDiff = (vector - _vect).MaxAbs();
                double max = new_sig.MaxAbs();
                _vect = vector.Clone();

                if(max > TresholdAgc && maxDiff > TresholdDif) Update(new_sig);
            }
        }

        private Vector PushSig(Vector vector) 
        {
            Vector ret = new Vector(vector.Count);

            for (int i = 0; i < ret.Count; i++)
            {
                ret[i] = Agc[i].Calculate(vector[i]);
            }

            return ret;
        }

        //Заглушка
        private void AGCVectorAction_Update(Vector obj)
        {
        }

        public event Action<Vector> Update;
    }
}
