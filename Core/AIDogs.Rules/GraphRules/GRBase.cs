﻿using AIDog.Graphs.BaseGraph;
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
    public class GRBase
    {
        public GraphWithVertex MainGraph { get; protected set; }

        /// <summary>
        /// Простая логика на графах
        /// </summary>
        public GRBase(IEnumerable<Rule> rules)
        {
            var rulArray = rules.ToArray();
            HashSet<string> names = new HashSet<string>();

            // Создание набора переменных
            for (int i = 0; i < rulArray.Length; i++)
            {
                if(!names.Contains(rulArray[i].IF)) names.Add(rulArray[i].IF);
                if (!names.Contains(rulArray[i].THEN)) names.Add(rulArray[i].THEN);
            }

            List<Vertex> vertices = new List<Vertex>(names.Count);

            foreach (var item in names)
            {
                vertices.Add(new Vertex(item));
            }

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
    }
}
