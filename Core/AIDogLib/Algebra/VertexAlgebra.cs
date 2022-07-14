using AI.DataStructs.Algebraic;
using AIDog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Algebra
{
    /// <summary>
    /// Алгебра вершин
    /// </summary>
    public class VertexAlgebra
    {
        Vector data = new Vector();

        public VertexAlgebra(int n) 
        {
            data = new Vector(n);
        }

        public VertexAlgebra(int a, int n)
        {
            Init(a, n);
        }

        private void Init(int a, int n) 
        {
            data = Simillary.Bools2Vect(a.DecimalToGrayBits(n));
        }

        public static int operator +(VertexAlgebra a, VertexAlgebra b) 
        {
            var res = a.data + b.data;
            return Decoder(res);
        }

        /// <summary>
        /// Декодирование вектора
        /// </summary>
        /// <param name="a">Вектор</param>
        public static int Decoder(VertexAlgebra a)
        {
            return Decoder(a.data);
        }

        /// <summary>
        /// Декодирование вектора
        /// </summary>
        /// <param name="a">Вектор</param>
        public static int Decoder(Vector a)
        {
            char[] str = new char[a.Count];

            for (int i = 0; i < a.Count; i++)
                str[i] = a[i] < 0 ? '0' : '1';

            return (new string(str)).GrayDecoder();
        }

        /// <summary>
        /// Сумма 2х чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="n">Число разрядов</param>
        public static int Sum(int a, int b, int n = 5)
        {
            return new VertexAlgebra(a, n) + new VertexAlgebra(b, n);
        }

        /// <summary>
        /// Сумма 2х чисел
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="n">Число разрядов</param>
        public static int Sum(int[] a, int n = 5)
        {
            Vector sum = new Vector(n);
            for (int i = 0; i < a.Length; i++)
               sum += Simillary.Bools2Vect(a[i].DecimalToGrayBits(n));
            return Decoder(sum);
        }

    }
}
