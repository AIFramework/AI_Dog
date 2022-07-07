using AI.DataStructs.Algebraic;
using AI.Extensions;
using AIDog.DataPrep;
using AIDog.Rules;
using AIDog.Rules.GraphRules;
using AIDog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Blocks
{
    /// <summary>
    /// Логический блок
    /// </summary>
    public class LogicBlock
    {
        ///// <summary>
        ///// Автоматически извлеченные правила
        ///// </summary>
        //public List<Rule> Rules { get; private set;  } = new List<Rule>();
        /// <summary>
        /// Граф логического вывода
        /// </summary>
        public GRBase LogicGraph { get; private set; }
        /// <summary>
        /// Текущее слово (бинарный код)
        /// </summary>
        public string CurrentWord => oldState.ToString();
        /// <summary>
        /// Текущая вершина
        /// </summary>
        public int CurrentVertexNum { get; private set; } = -1;       
        /// <summary>
        /// Средняя ошибка
        /// </summary>
        public double Eror { get; set; } = 0;
        /// <summary>
        /// Точность
        /// </summary>
        public double Acc { get; set; } = 0;
        /// <summary>
        /// Преобразователь сигнала в текст
        /// </summary>
        public Signal2Word Signal2Word { get; set; }


        private double[] _err = new double[100];
        private double True = 0, All = 0; // Для оценки качества языковой модели
        private int oldState = -1;
        private long activCount = 0;
       // public double alpha = 0.03;

        /// <summary>
        /// Логический блок
        /// </summary>
        /// <param name="dimSensor">Размерность сенсора</param>
        /// <param name="log2DictSize">Логарифм по основанию 2 от размерности словаря, размерность словаря 2^log2DictSize</param>
        public LogicBlock(int dimSensor, int log2DictSize = 5) 
        {
            int vertCount = (int)Math.Pow(2, log2DictSize);
            LogicGraph = new GRBase(vertCount);

            Signal2Word = new Signal2Word(dimSensor, log2DictSize);
            Signal2Word.UpdateWord += Signal2Word_UpdateWord;
        }

        /// <summary>
        /// Обновление образа
        /// </summary>
        /// <param name="signal">Сигнал входа</param>
        public void Push(Vector signal) 
        {
            Signal2Word.Push(signal);
        }

        /// <summary>
        ///  Появление новых состояний (слов)
        /// </summary>
        private void Signal2Word_UpdateWord(int obj)
        {
            if (oldState != -1)
            {
                Activate(oldState, obj);

                var dat = LogicGraph.MainGraph.GetVertexForKStep(oldState.ToString(), 1);
                var indexVert = dat.Item2.MaxElementIndex();

                _err[(int)All] = 1.0 - dat.Item2[indexVert];

                if (dat.Item1[indexVert] == obj.ToString()) True++;
                All++;


                if (All == 100)
                {
                    Eror = Math.Round(_err.Mean(), 3);
                    Acc = Math.Round(True / All, 3);
                    All = 0;
                    True = 0;
                }
            }
            oldState = obj;
            CurrentVertexNum = obj;
        }


        /// <summary>
        /// Корректировка
        /// </summary>
        /// <param name="ifBin"></param>
        /// <param name="elseBin"></param>
        private void Activate(int ifBin, int elseBin) 
        {
            LogicGraph.MainGraph.MainGraph.AdjMatrix *= activCount;
            double upd = LogicGraph.GetW(ifBin, elseBin) + 1;
            LogicGraph.Update(ifBin, elseBin, ifBin.ToString(), elseBin.ToString(), upd);
            activCount++;
            LogicGraph.MainGraph.MainGraph.AdjMatrix /= activCount;

        }

    }
}
