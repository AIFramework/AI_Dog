using AI.DataStructs.Data;
using AIDog.Blocks;
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
        public RingBuffer<int> States = new RingBuffer<int>(5, -1);
        /// <summary>
        /// Состояние системы (передается по ссылке)
        /// </summary>
        public SystemState SystemState { get; set; }

        /// <summary>
        /// Рассчет текущей эмоции
        /// </summary>
        /// <param name="reward">Подкрепление действия</param>
        public DataEmotions CalcEmotions(double reward = 0) 
        {
            if (reward > 0) SystemState.EmoState.Joy += SystemState.KReward*reward;
            if (reward < 0) SystemState.EmoState.Fear -= SystemState.KReward*reward;

            return SystemState.EmoState;
        }

        /// <summary>
        /// Добавление состояния и подкрепления в контекст
        /// </summary>
        /// <param name="state">Состояние</param>
        /// <param name="reward">Подкрепление</param>
        public FragmentMemory NewStateInContext(int state, double reward = 0) 
        {
            States.AddElement(state);

            FragmentMemory fragment = new FragmentMemory();

            fragment.States = States;
            fragment.Emotions = CalcEmotions(reward);
            return fragment;
        }
    }
}
