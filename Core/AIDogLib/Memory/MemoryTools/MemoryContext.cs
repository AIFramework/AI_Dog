using AIDog.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Memory.MemoryTools
{
    /// <summary>
    /// Контекст памяти (активные действия пользователя)
    /// </summary>
    public class MemoryContext
    {
        // ToDo: сделать на базе циклического буфера и общего контекста


        /// <summary>
        /// Рассчет текущей эмоции
        /// </summary>
        public DataEmotions CalcEmotions(double reward = 0) 
        {
            throw new Exception("Не реализовано");
        }

        /// <summary>
        /// Добавление состояния и подкрепления в контекст
        /// </summary>
        /// <param name="state">Состояние</param>
        /// <param name="reward">Подкрепление</param>
        public FragmentMemory NewStateInContext(int state, double reward = 0) 
        {
            throw new Exception("Не реализовано"); 
        }
    }
}
