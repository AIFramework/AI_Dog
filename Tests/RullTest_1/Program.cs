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
                new Rule("стало темнее", "хуже видно дорогу"),
                new Rule("хуже видно дорогу", "опаснее на улице"),
                new Rule("рассвело", "выключили свет"),
                new Rule("рассвело", "стало светлее"),
                new Rule("выключили свет", "уменьшился расход электричества"),
                new Rule("насморк", "простуда"){ CountActiv = 2},
                new Rule("насморк", "грипп"),
                new Rule("кашель", "простуда"){ CountActiv = 2},
                new Rule("кашель", "грипп"),
                new Rule("повышенная температура", "простуда"){ CountActiv = 2},
                new Rule("повышенная температура", "грипп"),
                new Rule("повышенная температура", "травма"),
                new Rule("головная боль", "простуда"){ CountActiv = 2},
                new Rule("головная боль", "травма"),
                new Rule("головная боль", "мигрень"){ CountActiv = 3},
                new Rule("головная боль", "грипп"),
                new Rule("сломана рука", "травма"){ CountActiv = 3},
                new Rule("простуда", "сидеть дома"),
                new Rule("мигрень", "сидеть дома"),
                new Rule("грипп", "пойти к врачу"),
                new Rule("травма", "ехать в травму")
            };

            rules.EvalutionApriori();

            GRBase logic = new GRBase(rules);

            //головная боль,кашель,насморк,повышенная температура
            // Вывод
            while (true)
            {
                string[] inp = Console.ReadLine().Split(',');
                Console.WriteLine();
                try
                {
                    Tuple<string[], AI.DataStructs.Algebraic.Vector> dat = logic.MainGraph.GetVertexForKStep(inp,2);
                    string[] n = dat.Item1;
                    AI.DataStructs.Algebraic.Vector v = dat.Item2;

                    for (int i = 0; i < n.Length; i++)
                    {
                        Console.WriteLine(n[i] + "\t\t" + Math.Round(v[i] * 100, 2) + "%");
                    }
                }

                catch
                {
                    Console.WriteLine(inp[0]);
                }
                Console.WriteLine('\n');
            }
        }
    }
}
