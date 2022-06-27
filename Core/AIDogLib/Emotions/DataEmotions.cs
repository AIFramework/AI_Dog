using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Emotions
{
    /// <summary>
    /// Данные эмоций (структура данных)
    /// </summary>
    [Serializable]
    public class DataEmotions
    {
        /// <summary>
        /// Страх
        /// </summary>
        public double Fear { get; set; } = 0;

        /// <summary>
        /// Радость
        /// </summary>
        public double Joy { get; set; } = 0;

        /// <summary>
        /// Любопытство
        /// </summary>
        public double Curiosity { get; set; } = 0;

        /// <summary>
        /// Возбуждение нервной системы
        /// </summary>
        public double Excitation => Math.Sqrt(Fear * Fear + Joy * Joy + Curiosity * Curiosity);

        /// <summary>
        /// Преобразование эмоций в вектор {Страх, Радость, Любопытство, Возбуждение}
        /// </summary>
        /// <returns></returns>
        public Vector ToVector() 
        {
            return new Vector(Fear, Joy, Curiosity, Excitation);
        }
         
    }
}
