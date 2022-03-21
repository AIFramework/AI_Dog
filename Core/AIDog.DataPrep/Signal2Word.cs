using AI.DataStructs.Algebraic;
using AI.ML.Clustering;
using AIDog.DataPrep.Base;
using AIDog.DataPrep.Base.Seq1D;
using AIDog.DataPrep.WordGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.DataPrep
{
    /// <summary>
    /// Перевод сигналов в слова
    /// </summary>
    public class Signal2Word
    {
        public KMeans Clustering = new KMeans(5);
        /// <summary>
        /// Векторы
        /// </summary>
        public List<Vector> Vectors { get; private set; } = new List<Vector>();

        /// <summary>
        /// Число векторов для первоначального моделирования
        /// </summary>
        public int NModeler { get; set; } = 130;
        /// <summary>
        /// Текущий кластер
        /// </summary>
        public int NumCluster { get; protected set; } = -1;


        AGCVectorAction ava;
        WordFromVectors wfv;
        bool _isInitW = false;
        int _iter = 0; // номер итерации
        string _oldWord;

        /// <summary>
        /// Перевод сигналов в слова
        /// </summary>
        public Signal2Word(int dimInp, int pow2NWord) 
        {
            ava = new AGCVectorAction(dimInp);
            Clustering = new KMeans(pow2NWord);

            ava.Update += Ava_Update;
            UpdateSignal += Signal2Word_UpdateSignal;
            UpdateWord += Signal2Word_UpdateWord;
            IsMatrixInit += Signal2Word_IsMatrixInit;
            UpdateContrastSignal += Signal2Word_UpdateContrastSignal;
            GetCluster += Signal2Word_GetCluster;
        }

        
        /// <summary>
        /// Добавление сигнала
        /// </summary>
        /// <param name="vect">Вектор сингнала</param>
        public void Push(Vector vect) 
        {
            ava.PushSignal(vect);
        }

        // Новый сигнал
        private void Ava_Update(Vector vector)
        {
            UpdateSignal(vector);// Обновление сигнала

            vector = Lateral.GetContrast(vector);
            UpdateContrastSignal(vector);
            int cl = _iter < NModeler + 2 ? 3 : Clustering.Classify(vector);

            // Условие обучения кластеризатора
            if (_iter++ == NModeler) Clustering.Train(Vectors.ToArray());
            else Vectors.Add(vector);
            
            if (_iter > NModeler)
            {
                // Обучение
                Teach(); 
                string newWord = wfv.GetWord(vector);
                if (newWord != _oldWord) UpdateWord(newWord); // Обновление слов
                _oldWord = newWord;
                // Выдача кластера
                NumCluster = Clustering.Classify(vector);
                GetCluster(NumCluster);
            }

        }

        // Обучение
        private void Teach() 
        {
            if (!_isInitW)
            {
                wfv = new WordFromVectors(Clustering.Сentroids);
                _isInitW = true;
            }

            IsMatrixInit(_isInitW);
        }

        


        /// <summary>
        /// Обновление сигналов
        /// </summary>
        public event Action<Vector> UpdateSignal;
        /// <summary>
        /// Обучен ли формирователь слов
        /// </summary>
        public event Action<bool> IsMatrixInit;
        /// <summary>
        /// Обновление слов
        /// </summary>
        public event Action<string> UpdateWord;
        /// <summary>
        /// Обновление контрастированных сигналов
        /// </summary>
        public event Action<Vector> UpdateContrastSignal;
        /// <summary>
        /// Выдает кластер
        /// </summary>
        public event Action<int> GetCluster;

        // -------------------------------------------------------------------------------//
        // ---------------------------- Заглушки ----------------------------------------//
        // ------------------------------------------------------------------------------//
        private void Signal2Word_IsMatrixInit(bool obj) { }
        private void Signal2Word_UpdateWord(string obj) { }
        private void Signal2Word_UpdateSignal(Vector obj) { }
        private void Signal2Word_UpdateContrastSignal(Vector obj) { }
        private void Signal2Word_GetCluster(int obj){}
    }
}
