using AI.DataStructs.Algebraic;
using AI.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Tools
{
    public static class Simillary
    {
        /// <summary>
        /// Коэффициент корреляции Пирсона между вектором семантического образа и индексом
        /// </summary>
        /// <param name="semantic">Семантический образ</param>
        /// <param name="index">Индекс</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns></returns>
        public static double CorrelationVectorInt(Vector semantic, int index, double min = -1, double max = 1)
        {
            bool[] bools = index.DecimalToGrayBits(semantic.Count);
            Vector index_vector = new Vector(bools.Length)+min;

            for (int i = 0; i < bools.Length; i++)
                if (bools[i]) index_vector[i] = max;

            return Statistic.CorrelationCoefficient(semantic, index_vector);
        }

        /// <summary>
        /// Нечеткая принадлежность вектора индексу (множеству)
        /// </summary>
        /// <param name="semantic">Семантический образ</param>
        /// <param name="index">Индекс</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public static double FuzzyMembership(Vector semantic, int index, double min = -1, double max = 1)
        {
            double cor = 6*CorrelationVectorInt(semantic, index, min, max);
            return 1.0 / (1.0 + Math.Exp(-cor));
        }
    }
}
