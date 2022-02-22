using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Graphs.BaseGraph
{
    public class Graph
    {
        public int NumberOfVertex { get; private set; }
        public int NumberOfArcs { get; protected set; } = 0;

        /// <summary>
        /// Матрица смежности
        /// </summary>
        Matrix _adjMatrix { get; set; }

        /// <summary>
        /// Создание графа
        /// </summary>
        /// <param name="nV">Число вершин</param>
        public Graph(int nV) 
        {
            _adjMatrix = new Matrix(nV, nV);
            NumberOfVertex = nV;
        }

        /// <summary>
        /// Создание обновление дуги
        /// </summary>
        /// <param name="v1">Исток</param>
        /// <param name="v2">Сток</param>
        /// <param name="w">Сила связи</param>
        public void AddSetArc(int v1, int v2, double w) 
        {
            double old = GetW(v1, v2);
            if (old == 0 && w != 0) NumberOfArcs++;
            if (old != 0 && w == 0) NumberOfArcs--;
            _adjMatrix[v1, v2] = w;
        }

        /// <summary>
        /// Удаление дуги
        /// </summary>
        /// <param name="v1">Исток</param>
        /// <param name="v2">Сток</param>
        public void DeleteArc(int v1, int v2) { AddSetArc(v1, v2, 0); }

        /// <summary>
        /// Получение силы связей 2х вершин
        /// </summary>
        public double GetW(int v1, int v2)
        {
            return _adjMatrix[v1, v2];
        }

        /// <summary>
        /// Вывод связанных вершин
        /// </summary>
        /// <param name="vertex">Вершина, для которой ищем связи</param>
        public int[] Adj(int vertex) 
        {
            List<int> verts = new List<int>();
            for (int i = 0; i < NumberOfVertex; i++)
            {
                if (GetW(vertex, i) != 0) verts.Add(i);
            }
            return verts.ToArray(); 
        }

        /// <summary>
        /// Степень вершины в графе(число связей)
        /// </summary>
        /// <param name="g">Граф</param>
        /// <param name="vertex">Номер вершины</param>
        public static int Degree(Graph g, int vertex)
        {
            return g.Adj(vertex).Length;
        }

        /// <summary>
        /// Максимальная степень вершины в графе(число связей)
        /// </summary>
        /// <param name="g">Граф</param>
        public static int MaxDegree(Graph g)
        {
            int[] ds = new int[g.NumberOfVertex];
            for (int i = 0; i < g.NumberOfVertex; i++) ds[i] = Degree(g, i);
            return ds.Max();
        }

        /// <summary>
        /// Среднее число связей
        /// </summary>
        /// <param name="g">Граф</param>
        public static double AverageDegree(Graph g) 
        {
            return g.NumberOfArcs / g.NumberOfVertex;
        }

        /// <summary>
        /// Число петлей в графе
        /// </summary>
        /// <param name="g">Граф</param>
        public static int CountLoop(Graph g) 
        {
            int count = 0;
            for (int i = 0; i < g.NumberOfVertex; i++)
            {
                int[] vs = g.Adj(i);
                for (int j = 0; j < vs.Length; j++)
                {
                    if (vs[i] == i) count++;
                }
            }

            return count;
        }
    }
}
