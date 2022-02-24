using AI.DataStructs.Algebraic;
using AI.HightLevelFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.DataPrep.Base
{
    /// <summary>
    /// Аналог латерального торможения в мозге
    /// </summary>
    public class Lateral
    {
        /// <summary>
        /// Выдает контраситрованный вектор
        /// </summary>
        /// <param name="inp">Вход</param>
        /// <param name="coef">Коэф. контраста</param>
        public static Vector GetContrast(Vector inp, double coef = 10) 
        {
            Vector centr = inp - inp.Mean();
            double denom = centr.Transform(Math.Abs).Sum() + AI.AISettings.GlobalEps;
            return ActivationFunctions.SigmoidBiplyar(centr / denom, coef);
        }
    }
}
