using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Tools
{
    /// <summary>
    /// Преобразование между системами счисления
    /// </summary>
    public static class NumConverter
    {
        /// <summary>
        /// Из двоичной в десятичную
        /// </summary>
        public static int BinaryToDecimal(this string binary) 
        {
            int ret = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                ret += (int)(Math.Pow(2, binary.Length - i - 1)) * (binary[i] == '0' ? 0 : 1);
            }

            return ret;
        }
    }
}
