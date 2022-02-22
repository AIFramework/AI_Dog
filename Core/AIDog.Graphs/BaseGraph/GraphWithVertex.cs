using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Graphs.BaseGraph
{
    public class GraphWithVertex
    {
        /// <summary>
        /// Граф, модель связей в графе
        /// </summary>
        public Graph MainGraph { get; protected set; }
        /// <summary>
        /// Вершины
        /// </summary>
        public Vertex[] Vertices { get; protected set; }

        /// <summary>
        /// Граф со связями с вершинами
        /// </summary>
        /// <param name="vertices">Вершины</param>
        /// <param name="graph">Базовый граф</param>
        public GraphWithVertex(Graph graph, Vertex[] vertices) 
        {
            MainGraph = graph;
            Vertices = vertices;
        }

        /// <summary>
        /// Граф без связей с вершинами
        /// </summary>
        /// <param name="vertices">Вершины</param>
        public GraphWithVertex(Vertex[] vertices) 
        {
            int n = vertices.Length;
            MainGraph = new Graph(n);
            Vertices = vertices;
        }

        /// <summary>
        /// Установить дугу
        /// </summary>
        /// <param name="v1">Исток</param>
        /// <param name="v2">Сток</param>
        /// <param name="w">Вес</param>
        public void SetArc(Vertex v1, Vertex v2, double w)
        {
            int iv1 = GetVertexIndex(v1), iv2 = GetVertexIndex(v2);
            MainGraph.AddSetArc(iv1, iv2, w);
        }

        /// <summary>
        /// Получить вес связи вершин
        /// </summary>
        /// <param name="v1">Исток</param>
        /// <param name="v2">Сток</param>
        public double GetW(Vertex v1, Vertex v2)
        {
            int iv1 = GetVertexIndex(v1), iv2 = GetVertexIndex(v2);
            return MainGraph.GetW(iv1, iv2);
        }

        /// <summary>
        /// Получить индекс вершины
        /// </summary>
        public int GetVertexIndex(Vertex vertex) 
        {
            for (int i = 0; i < Vertices.Length; i++)
                if (Vertices[i].Name == vertex.Name) return i;

            return -1;
        }
        
        /// <summary>
        /// Получение лапласиана для вершины
        /// </summary>
        /// <param name="vertex">Опорная вершина</param>
        public Vector GetLaplasian(Vertex vertex) 
        {
            int ind = GetVertexIndex(vertex);
            if (ind == -1)
                return vertex.VertexVector;
    
            Vector laplassian = vertex.VertexVector;
            int[] inds = MainGraph.Adj(ind);

            for (int i = 0; i < inds.Length; i++)
            {
                laplassian = MainGraph.GetW(ind, inds[i]) * Vertices[inds[i]].VertexVector;
            }

            return laplassian / (inds.Length + 1);
            
        }
    }
}
