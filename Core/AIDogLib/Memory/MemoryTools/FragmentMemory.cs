using AIDog.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Memory.MemoryTools
{
    /// <summary>
    /// небольшой участок памяти
    /// </summary>
    public class FragmentMemory
    {
        /// <summary>
        /// Состояния
        /// </summary>
        public int[] States { get; set; }

        /// <summary>
        /// Эмоции
        /// </summary>
        public DataEmotions Emotions { get; set; }

        /// <summary>
        /// Число активаций данного участка памяти
        /// </summary>
        public long CountActivate = 0;

        /// <summary>
        /// Вероятность активации данного участка
        /// </summary>
        public double Prob = 0;
    }
}
