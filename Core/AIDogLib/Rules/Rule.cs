using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Rules
{
    /// <summary>
    /// Правила
    /// </summary>
    [Serializable]
    public class Rule
    {
        public string IF { get; set; }
        public string THEN { get; set; }
        public double Apriori { get; set; } = 1;
        public int CountActiv { get; set; } = 1;

        public Rule(string _if, string _then, int countActiv = 1) 
        {
            IF = _if;
            THEN = _then;
            CountActiv = countActiv;
        }

        public Rule(params string[] rule) 
        {
            IF = rule[0];
            THEN = rule[1];
            CountActiv = 1;
        }

        public override string ToString()
        {
            return $"IF {IF}\t\tTHEN {THEN} \t\t Apriori prob: {Apriori}";
        }
    }
}
