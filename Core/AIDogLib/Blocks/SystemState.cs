using AIDog.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Blocks
{
    /// <summary>
    /// Состояние системы
    /// </summary>
    [Serializable]
    public class SystemState
    {
        /// <summary>
        /// Эмоциональное состояние системы
        /// </summary>
        public DataEmotions EmoState { get; set; }
        /// <summary>
        /// Коэффициент действия реварда
        /// </summary>
        public double KReward { get; set; }
    }
}
