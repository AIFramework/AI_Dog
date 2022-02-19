using AIDog.Rules;
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

                new Rule("рассвело", "выключили свет"),
                new Rule("выключили свет", "уменьшился расход электричества")
            };

            // Простейший механизм вывода
            SimpleCalc simpleCalc = new SimpleCalc(rules);

            foreach (Rule item in rules)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n\n");


            // Вывод
            while (true)
            {
                string inp = Console.ReadLine();
                Console.WriteLine(simpleCalc.NextNFerst(inp) + '\n');
            }

        }
    }
}
