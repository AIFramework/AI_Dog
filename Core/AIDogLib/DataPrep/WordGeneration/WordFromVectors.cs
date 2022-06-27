using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.DataPrep.WordGeneration
{
    /// <summary>
    /// Формирование слов из векторов 
    /// </summary>
    [Serializable]
    public class WordFromVectors
    {
        /// <summary>
        /// Матрица для преобразования
        /// </summary>
        public Matrix TransformMatr { get; set; }
        /// <summary>
        /// Инициализация матрицей
        /// </summary>
        /// <param name="matrix">Матрица</param>
        public WordFromVectors(Matrix matrix) 
        {
            TransformMatr = matrix.Copy();
        }

        /// <summary>
        /// Инициализация векторами
        /// </summary>
        /// <param name="vectors">Векторы</param>
        public WordFromVectors(IEnumerable<Vector> vectors)
        {
            Vector[] data = vectors.ToArray(); 
            SetMatr(data); 
        }

        /// <summary>
        /// Инициализация векторами
        /// </summary>
        /// <param name="vectors">Векторы</param>
        public void SetMatr(Vector[] vectors) 
        {
            TransformMatr = new Matrix(vectors[0].Count, vectors.Length);

            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < vectors[i].Count; j++)
                {
                    TransformMatr[j, i] = vectors[i][j];
                }
            }
        }

        /// <summary>
        /// Получение вектора образа
        /// </summary>
        /// <param name="inp">Вход</param>
        public Vector SemanticVector(Vector inp) 
        {
            return inp * TransformMatr;
        }

        /// <summary>
        /// Получение слова из вектора
        /// </summary>
        public string GetWord(Vector vect) 
        {
            Vector trv = SemanticVector(vect);
            StringBuilder @string = new StringBuilder();
            foreach (var item in trv)
            {
                @string.Append(item>0?1:0);
            }
            return @string.ToString();
        }

        /// <summary>
        /// Получение слов из векторов
        /// </summary>
        public string[] GetBatchWords(Vector[] vects) 
        {
            string[] words = new string[vects.Length];
            Parallel.For(0, vects.Length, w => words[w] = GetWord(vects[w]));
            return words;
        }
    }
}
