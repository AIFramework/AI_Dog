using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Memory
{
    /// <summary>
    /// Реализует элемент оперативной символьной памяти без эмоций
    /// </summary>
    [Serializable]
    public class OperativSymbolMemoryElement 
    { 
        /// <summary>
        /// Состояния
        /// </summary>
        public List<int> States { get; set; } = new List<int>();

        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < States.Count; i++)
            {
                stringBuilder.Append('!'+States[i].ToString()+"# ");
            }

            return stringBuilder.ToString();
        }
    }


    /// <summary>
    /// Реализует оперативную символьную память без эмоций
    /// </summary>
    [Serializable]
    public class OperativSymbolMemory
    {
        public List<OperativSymbolMemoryElement> OperativSymbolMemoryElements = new List<OperativSymbolMemoryElement>();
        int index = 0;


        /// <summary>
        /// Запомнить событие
        /// </summary>
        /// <param name="state">Состояние</param>
        /// <param name="newElement">Новая ли последовательность</param>
        public void Add(int state, bool newElement = false) 
        {
            if (OperativSymbolMemoryElements.Count == 0)
            {
                OperativSymbolMemoryElements.Add(new OperativSymbolMemoryElement());
            }
            else if (newElement)
            {
                OperativSymbolMemoryElements.Add(new OperativSymbolMemoryElement());
                index++;
            }

            OperativSymbolMemoryElements[index].States.Add(state);
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in OperativSymbolMemoryElements)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }

    }
}
