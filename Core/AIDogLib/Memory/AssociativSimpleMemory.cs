using AI.DataStructs.Algebraic;
using AI.ML.Regression;
using AIDog.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Memory
{
    /// <summary>
    /// Сенсорная и поведенческая память
    /// </summary>
    public class AssociativSimpleMemory
    {
        /// <summary>
        /// Образ стимула
        /// </summary>
        public List<Vector> InpImg { get; private set; } = new List<Vector>();


        /// <summary>
        /// Образ реакции
        /// </summary>
        public List<Vector> TargetImg { get; private set; } = new List<Vector>();

        /// <summary>
        /// Эмоции
        /// </summary>
        public List<DataEmotions> Emotions { get; private set; } = new List<DataEmotions>();

        /// <summary>
        /// Добавить ассоциацию
        /// </summary>
        public void Add(Vector inpImg, Vector targetImg)
        {
            InpImg.Add(inpImg);
            TargetImg.Add(targetImg);
            Emotions.Add(new DataEmotions());
        }

        /// <summary>
        /// Добавить ассоциацию окрашенную эмоцией
        /// </summary>
        public void Add(Vector sensorImg, Vector bp, DataEmotions emotion)
        {
            Emotions.Add(emotion);
            InpImg.Add(sensorImg);
            TargetImg.Add(bp);
        }

        /// <summary>
        /// Извлечь следующую реакцию
        /// </summary>
        /// <param name="img">Образ стимула</param>
        /// <returns></returns>
        public Vector GetAssociativNextReactionKNN(Vector img)
        {
            KnnMultyRegr bpAss = new KnnMultyRegr();
            bpAss.IsNadrMethod = true;
            bpAss.K = 4;

            for (int i = 0; i < TargetImg.Count - 1; i++)
                bpAss.Train(InpImg[i], TargetImg[i + 1]);

            return bpAss.Predict(img);
        }

        /// <summary>
        /// Извлечь следующую эмоцию
        /// </summary>
        /// <param name="img">Образ стимула</param>
        /// <returns></returns>
        public Vector GetAssociativNextEmotionKNN(Vector img)
        {
            KnnMultyRegr bpAss = new KnnMultyRegr();
            bpAss.IsNadrMethod = true;
            bpAss.K = 4;

            for (int i = 0; i < TargetImg.Count - 1; i++)
                bpAss.Train(InpImg[i], Emotions[i + 1].ToVector());

            return bpAss.Predict(img);
        }

        /// <summary>
        /// Извлечь текущую реакцию
        /// </summary>
        /// <param name="img">Образ стимула</param>
        /// <returns></returns>
        public Vector GetAssociativReactionKNN(Vector img)
        {
            KnnMultyRegr bpAss = new KnnMultyRegr();
            bpAss.IsNadrMethod = true;
            bpAss.K = 4;

            for (int i = 0; i < TargetImg.Count; i++)
                bpAss.Train(InpImg[i], TargetImg[i]);

            return bpAss.Predict(img);
        }

        /// <summary>
        /// Извлечь текущую эмоцию
        /// </summary>
        /// <param name="img">Образ стимула</param>
        /// <returns></returns>
        public Vector GetAssociativEmotionKNN(Vector img)
        {
            KnnMultyRegr bpAss = new KnnMultyRegr();
            bpAss.IsNadrMethod = true;
            bpAss.K = 4;

            for (int i = 0; i < TargetImg.Count; i++)
                bpAss.Train(InpImg[i], Emotions[i].ToVector());

            return bpAss.Predict(img);
        }
    }

}
