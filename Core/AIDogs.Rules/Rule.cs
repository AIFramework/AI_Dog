using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Rules
{
    public class Rule
    {
        public string IF { get; set; }
        public string THEN { get; set; }

        public Rule(string _if, string _then) 
        {
            IF = _if;
            THEN = _then;
        }

        public Rule(params string[] rule) 
        {
            IF = rule[0];
            THEN = rule[1];
        }

        public override string ToString()
        {
            return $"IF {IF}\t\tTHEN {THEN}";
        }
    }
}
