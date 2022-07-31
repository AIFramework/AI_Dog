using AIDog.Graphs.BaseGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Rules.GraphRules
{
    /// <summary>
    /// Простая логика на графах
    /// </summary>
    [Serializable]
    public class GRBase
    {
        public GraphWithVertex MainGraph { get; protected set; }

        public GRBase(int numVert)
        {
            MainGraph = new GraphWithVertex(numVert);
        }

        /// <summary>
        /// Обновление информации в графе
        /// </summary>
        /// <param name="i">Индекс вершины истока</param>
        /// <param name="j">Индекс вершины стока</param>
        /// <param name="name_i">Новое имя вершины истока</param>
        /// <param name="name_j">Новое имя вершины стока</param>
        /// <param name="value_upd">Новый вес связи</param>
        public void Update(int i, int j, string name_i, string name_j, double value_upd) 
        {
            MainGraph.Update(i, j, name_i, name_j, value_upd);
        }

        /// <summary>
        /// Получение связи
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public double GetW(int i, int j)
        {
            return MainGraph.GetW(i, j);
        }

        /// <summary>
        /// Простая логика на графах
        /// </summary>
        public GRBase(IEnumerable<Rule> rules)
        {
            var rulArray = ReCulcRules(rules.ToArray());
            rulArray.EvalutionApriori();

            HashSet<string> names = new HashSet<string>();

            // Создание набора переменных
            for (int i = 0; i < rulArray.Length; i++)
            {
                if(!names.Contains(rulArray[i].IF)) names.Add(rulArray[i].IF);
                if (!names.Contains(rulArray[i].THEN)) names.Add(rulArray[i].THEN);
            }

            List<Vertex> vertices = new List<Vertex>(names.Count);

            foreach (var item in names) vertices.Add(new Vertex(item));

            MainGraph = new GraphWithVertex(vertices); // Создание пустого графа
            Vertex[] verticesArray = vertices.ToArray();

            // Заполнение графа
            foreach (var item in rulArray)
            {
                Vertex vertex1 = Vertex.FromName(verticesArray, item.IF);
                Vertex vertex2 = Vertex.FromName(verticesArray, item.THEN);
                double w = item.Apriori;
                MainGraph.SetArc(vertex1, vertex2, w);
            }
            
        }

        public Vertex GetVertex(string name) 
        {
            var data = MainGraph.Vertices;
            return Vertex.FromName(data, name);
        }

        public Rule[] ReCulcRules(Rule[] rules) 
        {
            List<Rule> result = new List<Rule>();

            for (int i = 0; i < rules.Length; i++)
            {
                int j = Find(result, rules[i]);
                if (j != -1) result[j].CountActiv++;
                else result.Add(rules[i]);
            }

            return result.ToArray();
        }

        private int Find(List<Rule> result, Rule rule) 
        {
            for (int i = 0; i < result.Count; i++)
                if(result[i].IF == rule.IF&& result[i].THEN == rule.THEN) return i;
            
            return -1;
        }
    }
}
