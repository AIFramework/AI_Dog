using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.DataPrep.Vector2Token
{
    /// <summary>
    /// Интерфейс преобразования вектора в токен
    /// </summary>
    public interface IVector2Token
    {
        /// <summary>
        /// Вектор образа
        /// </summary>
        Vector SemanticVector { get; }

        /// <summary>
        /// Добавление сигнала
        /// </summary>
        /// <param name="vect">Вектор сингнала</param>
        void Push(Vector vect);

        /// <summary>
        /// Обновление слов
        /// </summary>
        event Action<int> UpdateWord;

        /// <summary>
        /// Обновление контрастированных сигналов
        /// </summary>
        event Action<Vector> UpdateContrastSignal;
    }
}
