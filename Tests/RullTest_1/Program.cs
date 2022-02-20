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
            Console.WriteLine(rules.ToStringRules());


            // Вывод
            while (true)
            {
                string inp = Console.ReadLine();
                Console.WriteLine(simpleCalc.NextNFerst(inp) + '\n');
                Console.WriteLine(rules.ToStringRules());
            }

        }
    }
}
