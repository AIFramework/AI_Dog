using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Rules
{
    public static class ExtensionsRules
    {
        /// <summary>
        /// Перерасчет априорных вероятностей
        /// </summary>
        /// <param name="rules">Правила</param>
        public static void EvalutionApriori(this Rule[] rules) 
        {
            double sum = 0;
            HashSet<Rule> set = new HashSet<Rule>();

            for (int i = 0; i < rules.Length; i++)
            {
                if (!set.Contains(rules[i]))
                {
                    sum += rules[i].CountActiv;
                    set.Add(rules[i]);
                }
            }

            for (int i = 0; i < rules.Length; i++)
            {
                rules[i].Apriori = rules[i].CountActiv / sum;
            }
        }

        public static string ToStringRules(this IEnumerable<Rule> rulesIEn) 
        {
            Rule[] rules = rulesIEn.ToArray();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Rule item in rules)
            {
                stringBuilder.Append(item);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}
