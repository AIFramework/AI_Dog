using AI.DataStructs.Algebraic;
using AIDog.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Memory
{
    /// <summary>
    /// Структура для хранения сенсорно-семантической информации
    /// </summary>
    [Serializable]
    public class SensorAndSemanticMemory
    {
        /// <summary>
        /// Сенсорные образы
        /// </summary>
        public List<Vector> SensorImg { get; private set; } = new List<Vector>();

        /// <summary>
        /// Семантические образы
        /// </summary>
        public List<Vector> SemanticImg { get; private set; } = new List<Vector>();

        public void Add(Vector sensorImg, Vector semanticImg)
        {
            SensorImg.Add(sensorImg);
            SemanticImg.Add(semanticImg);
        }

    }
}
