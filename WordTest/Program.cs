using AI.DataStructs.Algebraic;
using AIDog.DataPrep.WordGeneration;
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
            Vector[] vectors = new Vector[2];
            vectors[0] = new Vector(-1, 1, -8);
            vectors[1] = new Vector(1, -1, 2);

            WordFromVectors wfv = new WordFromVectors(vectors);

            Console.WriteLine(wfv.GetWord(new Vector(2, -4, 2)));
        }
    }
}
