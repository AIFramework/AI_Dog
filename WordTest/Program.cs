using AI.DataStructs.Algebraic;
using AIDog.Algebra;
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

            int a = 15, b = 734;

            while (true)
            {
                Console.WriteLine("Введите число #1");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число #2");
                b = Convert.ToInt32(Console.ReadLine());


                var cor = Simillary.CosIntInt(b, a);
                Console.WriteLine($"Косинус между числами {cor}\n\n");
                var p = Simillary.FuzzyMembershipIntInt(b, a);
            }

            //int[] a = { 226, 120, 110, 110, 123 };
            //Console.WriteLine(VertexAlgebra.Sum(a, 10));

            //string gr = a.DecimalToGrayStr();
            //Console.WriteLine(gr);
            //Console.WriteLine(gr.GrayDecoder());


        }
    }
}
