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
        public static int BinaryToDecimal(this bool[] binary)
        {
            int ret = 0;

            for (int i = 0; i < binary.Length; i++)
                if (binary[i])
                    ret += (int)(Math.Pow(2, binary.Length - i - 1));

            return ret;
        }

        /// <summary>
        /// Из двоичной в десятичную
        /// </summary>
        public static int BinaryToDecimal(this string binary)
        {
            var arr = binary.StringToBitArray();
            return arr.BinaryToDecimal();
        }

        /// <summary>
        /// Строка в массив бит
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public static bool[] StringToBitArray(this string binary)
        {
            bool[] ret = new bool[binary.Length];

            for (int i = 0; i < binary.Length; i++)
                ret[i] = binary[i] == '1';
            
            return ret; 
        }


        public static int GrayDecoder(this string binary)
        {
            var ret = binary.StringToBitArray();
            return ret.GrayDecoder();
        }

        public static int GrayDecoder(this bool[] binary)
        {
            long bin = 0;
            string code = "";

            for (int i = 0; i < binary.Length; i++)
            { 
                bin ^= binary[i]?1:0;
                code += bin;
            }
             
           

            return code.BinaryToDecimal();
        }

    }
}
