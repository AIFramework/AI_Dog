using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Rules
{
    public class SimpleCalc
    {
        public Rule[] Rules { get; set; }
        
        public SimpleCalc(Rule[] rules) 
        {
            Rules = rules;
        }

         /// <summary>
         /// Следующий шаг
         /// </summary>
         /// <param name="start">Начало</param>
        public string NextFerst(string start) 
        {
            for (int i = 0; i < Rules.Length; i++)
            {
                if (start == Rules[i].IF)
                    return Rules[i].THEN;
            }

            return string.Empty;
        }

        /// <summary>
        /// Прогноз на n шагов
        /// </summary>
        /// <param name="start">Начало</param>
        public string NextNFerst(string start, int n = 3)
        {
            string inp = start;
            for (int i = 0; i < n; i++)
            {
                if (NextFerst(inp) == string.Empty)
                    break;

                inp = NextFerst(inp);
            }

            return inp;
        }
    }
}
