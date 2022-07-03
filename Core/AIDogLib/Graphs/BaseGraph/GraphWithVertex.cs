using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Graphs.BaseGraph
{
    [Serializable]
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

        long _countUpdate = 0;

        /// <summary>
        /// Граф со связями с вершинами
        /// </summary>
        /// <param name="vertices">Вершины</param>
        /// <param name="graph">Базовый граф</param>
        public GraphWithVertex(Graph graph, IEnumerable<Vertex> vertices) 
        {
            MainGraph = graph;
            Vertices = vertices.ToArray();
        }

        /// <summary>
        /// Создание графа с пустыми вершинами
        /// </summary>
        /// <param name="numVertex">Число вершин</param>
        public GraphWithVertex(int numVertex)
        {
            MainGraph = new Graph(numVertex);
            Vertices = new Vertex[numVertex];

            for (int i = 0; i < Vertices.Length; i++) 
                Vertices[i] = new Vertex(String.Empty);
        }

    

        /// <summary>
        /// Граф без связей с вершинами
        /// </summary>
        /// <param name="vertices">Вершины</param>
        public GraphWithVertex(IEnumerable<Vertex> vertices) 
        {
            Vertices = vertices.ToArray();
            MainGraph = new Graph(Vertices.Length);
            
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
        public Vector[] GetLaplasian(Vertex vertex) 
        {
            int ind = GetVertexIndex(vertex);
            if (ind == -1) return vertex.VertexVector;

            int[] inds = MainGraph.Adj(ind);
            Vector[] laplassian = new Vector[vertex.VertexVector.Length];

            for (int n = 0; n < laplassian.Length; n++)
            {
                laplassian[n] = vertex.VertexVector[n].Clone(); // Выбор вектора вершины

                for (int i = 0; i < inds.Length; i++)
                    laplassian[n] += MainGraph.GetW(ind, inds[i]) * Vertices[inds[i]].VertexVector[n]; // Вычисление Лаплассина
                
                laplassian[n] /= (inds.Length + 1); // Нормировка
            }

            return laplassian; 
            
        }

        /// <summary>
        /// Связные вершины
        /// </summary>
        /// <param name="vertex">Вершина истока</param>
        public Vertex[] Adj(Vertex vertex)
        {
            int ind = GetVertexIndex(vertex);
            int[] inds = MainGraph.Adj(ind);
            Vertex[] vertices = new Vertex[inds.Length];

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Vertices[inds[i]];

            return vertices;
        }

        /// <summary>
        /// Выдает конечные вершины через k шагов, возвращает вершины и вектор вероятностей
        /// </summary>
        public Tuple<Vertex[], Vector> GetVertexForKStep(Vertex startVertex, int kStep = 2)
        {
            int ind = GetVertexIndex(startVertex);
            var vertsVect = MainGraph.GetVertexForKStep(ind, kStep);
            int[] inds = vertsVect.Item1;
            Vertex[] vertices = new Vertex[inds.Length];

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Vertices[inds[i]];

            return new Tuple<Vertex[], Vector>(vertices, vertsVect.Item2);
        }


        /// <summary>
        /// Выдает конечные вершины через k шагов, возвращает вершины и вектор вероятностей
        /// </summary>
        public Tuple<Vertex[], Vector> GetVertexForKStep(Vertex[] startVertex, int kStep = 2)
        {
            int[] ind_vs = new int[startVertex.Length];
            for (int i = 0; i < ind_vs.Length; i++)
            {
                ind_vs[i] = GetVertexIndex(startVertex[i]);
            }

            var vertsVect = MainGraph.GetVertexForKStep(ind_vs, kStep);
            int[] inds = vertsVect.Item1;
            Vertex[] vertices = new Vertex[inds.Length];

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Vertices[inds[i]];

            return new Tuple<Vertex[], Vector>(vertices, vertsVect.Item2);
        }

        /// <summary>
        /// Выдает конечные вершины через k шагов, возвращает вершины и вектор вероятностей
        /// </summary>
        public Tuple<string[], Vector> GetVertexForKStep(string startVertex, int kStep = 2)
        {
            Vertex vertex = Vertex.FromName(Vertices, startVertex);
            int ind = GetVertexIndex(vertex);
            var vertsVect = MainGraph.GetVertexForKStep(ind, kStep);
            int[] inds = vertsVect.Item1;
            string[] vertices = new string[inds.Length];

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Vertices[inds[i]].Name;

            return new Tuple<string[], Vector>(vertices, vertsVect.Item2);
        }

        /// <summary>
        /// Выдает конечные вершины через k шагов, возвращает вершины и вектор вероятностей
        /// </summary>
        public Tuple<string[], Vector> GetVertexForKStep(string[] startVertex, int kStep = 2)
        {
            int[] ind_vs = new int[startVertex.Length];
            for (int i = 0; i < ind_vs.Length; i++)
            {
                Vertex vertex = Vertex.FromName(Vertices, startVertex[i]);
                ind_vs[i] = GetVertexIndex(vertex);
            }
            
            var vertsVect = MainGraph.GetVertexForKStep(ind_vs, kStep);
            int[] inds = vertsVect.Item1;
            string[] vertices = new string[inds.Length];

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Vertices[inds[i]].Name;

            return new Tuple<string[], Vector>(vertices, vertsVect.Item2);
        }

        /// <summary>
        /// Связные вершины
        /// </summary>
        /// <param name="vertex">Вершина истока</param>
        public string[] Adj(string name)
        {
            Vertex vertex = Vertex.FromName(Vertices, name);
            Vertex[] vertices = Adj(vertex);
            string[] names = new string[vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
                names[i] = vertices[i].Name;

            return names;
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
            if (Vertices[i].Name != name_i) Vertices[i].Name = name_i;
            if (Vertices[j].Name != name_j) Vertices[j].Name = name_j;

            MainGraph.AdjMatrix[i, j] = value_upd;
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
    }
}
