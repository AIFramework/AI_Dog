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
                new Rule("стемнело", "зажгли свет"){ CountActiv = 2},
                new Rule("зажгли свет", "увеличился расход электричества"),
                new Rule("стемнело", "стало темнее"),
                new Rule("стало темнее", "хуже видно дорогу"),
                new Rule("хуже видно дорогу", "опаснее на улице"),
                new Rule("рассвело", "выключили свет"),
                new Rule("рассвело", "стало светлее"),
                new Rule("выключили свет", "уменьшился расход электричества")
            };

            rules.EvalutionApriori();

            GRBase logic = new GRBase(rules);


            // Вывод
            while (true)
            {
                string inp = Console.ReadLine();
                try
                {
                    var dat = logic.MainGraph.GetVertexForKStep(inp);
                    var n = dat.Item1;
                    var v = dat.Item2;

                    for (int i = 0; i < n.Length; i++)
                    {
                        Console.WriteLine(n[i]+"\t\t"+v[i]);
                    }
                }

                    catch
                {
                    Console.WriteLine(inp);
                }
            Console.WriteLine('\n');
            }
        }
    }
}
