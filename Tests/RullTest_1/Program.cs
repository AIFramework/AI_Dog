using AIDog.Rules;
using AIDog.Rules.GraphRules;
using System;

namespace RullTest_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Набор правил
            Rule[] rules = {
                new Rule("стемнело", "зажгли свет"),
                new Rule("зажгли свет", "увеличился расход электричества"),
                new Rule("стемнело", "стало темнее"),
                new Rule("рассвело", "выключили свет"),
                new Rule("рассвело", "стало светлее"),
                new Rule("выключили свет", "уменьшился расход электричества")
            };


            GRBase logic = new GRBase(rules);


            //// Простейший механизм вывода
            //SimpleCalc simpleCalc = new SimpleCalc(rules);
            //Console.WriteLine(rules.ToStringRules());


            //// Вывод
            //while (true)
            //{
            //    string inp = Console.ReadLine();
            //    Console.WriteLine(simpleCalc.NextNFerst(inp) + '\n');
            //    Console.WriteLine(rules.ToStringRules());
            //}

            // Вывод
            while (true)
            {
                string inp = Console.ReadLine();
                try
                {
                    var dat = logic.MainGraph.Adj(inp);

                    for (int i = 0; i < dat.Length; i++)
                    {
                        Console.WriteLine(dat[i]);
                    }
                }

                catch { Console.WriteLine(inp); }
                Console.WriteLine('\n');
            }
        }
    }
}
