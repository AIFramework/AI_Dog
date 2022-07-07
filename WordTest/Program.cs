using AI.DataStructs.Algebraic;
using AIDog.DataPrep.WordGeneration;
using AIDog.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTest
{
    internal class Program
    {
         
        static void Main(string[] args)
        {
            Vector v = new Vector(-1, 1, -8);
            int a = 4;


            var cor = Simillary.CorrelationVectorInt(v, a);
            var p = Simillary.FuzzyMembership(v, a);


            

            string gr = a.DecimalToGrayStr();
            Console.WriteLine(gr);
            Console.WriteLine(gr.GrayDecoder());
            

        }
    }
}
